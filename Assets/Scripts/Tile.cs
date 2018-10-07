using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tile : MonoBehaviour
{

    private AudioSource tileSource;
    public AudioClip landMovement;
    public AudioClip winSound;

    public Position position;
    public bool status;
    public Texture2D WIN, LOSE;
    public GameObject character;

    private Renderer m_Renderer;
    
    private float yVelocity = 0.0F;


    void Start()
    {
        tileSource = GetComponent<AudioSource>();
        m_Renderer = GetComponent<Renderer>();
        Map map = GameObject.FindWithTag("Map").GetComponent<Map>();
        if (map.currentLevel == 4) {
            RandomTileColor();
        } else {
            UpdateTileColor();
        }
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

    void RandomTileColor() {
        if (Mathf.RoundToInt(Random.Range(0, 2)) == 1)
        {
            status = true;
            m_Renderer.material.SetTexture("_MainTex", WIN);
        }
        else
        {
            status = false;
            m_Renderer.material.SetTexture("_MainTex", LOSE);
        }
    }


    void OnCollisionEnter(Collision col)
    {

        tileSource.clip = landMovement;
        tileSource.Play();

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
            tileSource.clip = winSound;
            tileSource.Play();

            Debug.Log("WINNN !");
            GameObject myCharacter = GameObject.Find("MainCharacter");
            myCharacter.GetComponent<Rigidbody>().velocity = Vector3.up * 7;
            Invoke("changeScene", 1);
            if (GameObject.Find("Map").GetComponent<Map>().currentLevel == 4)
            {
                Debug.Log("WIdsfsdNNN !");

                GameObject.Find("Listener").GetComponent<win>().won();
        
//                GameObject.Find("MainCharacter").GetComponent<Animator>().Play("Dance");
            }
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
