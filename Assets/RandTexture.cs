using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandTexture : MonoBehaviour {

    Map currentMap;
    int[] randomTexture;
    public Texture2D WIN, LOSE;
    Renderer m_Renderer;

    // Use this for initialization
    void Start () {
        currentMap = GetComponent<Map>();
        for(int i = 0; i< 64; i++)
        {
            randomTexture[i] = Mathf.RoundToInt(UnityEngine.Random.Range(0, 1));

            if(randomTexture[i] == 1)
            {
                m_Renderer.material.SetTexture("_MainTex", WIN);
            }
            else
            {
                m_Renderer.material.SetTexture("_MainTex", LOSE);
            }

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
