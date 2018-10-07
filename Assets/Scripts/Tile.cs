using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tile : MonoBehaviour
{

    public Position position;
    public bool status;
    public Texture2D WIN, LOSE;
    public GameObject character;

    private Renderer m_Renderer;
    
    private float yVelocity = 0.0F;


    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
        UpdateTileColor();
    }

    void UpdateTileColor() {
        if (status)
        {
            m_Renderer.material.SetTexture("_MainTex", WIN);
        }
        else
        {
            m_Renderer.material.SetTexture("_MainTex", LOSE);
        }
    }


    void OnCollisionEnter(Collision col)
    {
            
        Debug.Log(col.gameObject.transform.position);
        Debug.Log(transform.position);
        
        col.gameObject.transform.position = new Vector3(transform.position.x, col.gameObject.transform.position.y, transform.position.z);
        
        
        status = !status;
        UpdateTileColor();
        CallWinCodition();
        Character.SetIsJumping(false);
        col.gameObject.GetComponent<Animator>().SetBool("IsJumping", false);
    }

    private void CallWinCodition()
    {
        
        if (GameObject.Find("Map").GetComponent<Map>().CheckWinCondition())
        {
            Debug.Log("WINNN !");
            StartCoroutine(Lefting());
        }
    }

    public bool GetStatus()
    {
        return this.status;
    }
    
    public IEnumerator Lefting()
    {
        GameObject character = GameObject.Find("MainCharacter");
        while (character.transform.position.y < 2.5f)
        {
            character.transform.position += new Vector3(0, 0.1f, 0);
            yield return null;
        }
        GameObject.Find("SceneManager").GetComponent<Scene>().loadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
