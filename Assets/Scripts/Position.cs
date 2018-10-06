using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Position
{
    public int z;
    public int x;

    public Position(int x, int z)
    {
        this.z = z;
        this.x = x;
    }

    public String ToString()
    {
        return "x : " + this.x + " z : " + this.z;
    }
}
