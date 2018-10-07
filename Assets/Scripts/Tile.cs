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
        col.gameObject.transform.position = new Vector3(transform.position.x, col.gameObject.transform.position.y, transform.position.z);
        Character.isJumping = false;
        
        status = !status;
        UpdateTileColor();
        CallWinCodition();
    }

    private void CallWinCodition()
    {
        
        if (GameObject.Find("Map").GetComponent<Map>().CheckWinCondition())
        {
            Debug.Log("WINNN !");
            GameObject myCharacter = GameObject.Find("MainCharacter");
            myCharacter.GetComponent<Rigidbody>().velocity = Vector3.up * 7;
            Invoke("changeScene", 1);
//            StartCoroutine(Lefting());
        }
    }

    public bool GetStatus()
    {
        return this.status;
    }

    public void changeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
