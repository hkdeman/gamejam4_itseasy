using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Position
{
    public int y;
    public int x;

    public Position(int x, int y)
    {
        this.y = y;
        this.x = x;
    }

    public String ToString()
    {
        return "x : " + this.x + " y : " + this.y;
    }
}
