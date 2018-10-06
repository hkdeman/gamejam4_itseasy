﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public Position position;
    public bool status;
    public Texture2D WIN, LOSE;
    public GameObject character;

    private Renderer m_Renderer;

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
        status = !status;
        UpdateTileColor();
        Character.SetIsJumping(false);
        col.gameObject.GetComponent<Animator>().SetBool("IsJumping", false);
    }

    public bool GetStatus()
    {
        return this.status;
    }
}
