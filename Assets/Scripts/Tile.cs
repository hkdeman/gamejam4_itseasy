using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public Position position;
    public bool status = false;

    public Tile(Position pos)
    {
        position = pos;
    }

    void OnCollisionEnter(Collision col)
    {
        status = !status;
        print(status);
    }

    public bool GetStatus()
    {
        return this.status;
    }
}
