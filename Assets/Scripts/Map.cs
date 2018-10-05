using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

	Tale [,] map = new Tale [10, 2];
	
	// Use this for initialization
	void Start () {

		for (int i = 0; i < 10; ++i)
		{
			for (int j = 0; j < 2; ++j)
			{
				map[i, j] = new Tale(new Position(i, j));
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
