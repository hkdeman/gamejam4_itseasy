using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

	Tale [,] map = new Tale [10, 2];

	private Character myCharacter;
	
	// Use this for initialization
	void Start () {
		createMap();
		myCharacter = new Character(new Position(0, 0));
		Debug.Log(myCharacter.myPosition.ToString());
		myCharacter.moveDown();
		Debug.Log(myCharacter.myPosition.ToString());


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void createMap()
	{
		for (int i = 0; i < 10; ++i)
		{
			for (int j = 0; j < 2; ++j)
			{
				map[i, j] = new Tale(new Position(i, j));
			}
		}
	}
}
