using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraRotator : MonoBehaviour {

    public GameObject mapGameObject;

    Camera cam;
    Map map;

	// Use this for initialization
	void Start () {
        map = mapGameObject.GetComponent<Map>();
        transform.position = new Vector3((map.ROWS/2)*map.SCALE, 0, (map.COLS/2)*map.SCALE-2);

        cam = GetComponentInChildren<Camera>();
        cam.transform.position = new Vector3(-2.0f, 4.0f, -7.0f);
        cam.transform.rotation = Quaternion.Euler(30, 20, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.E)) {
            transform.rotation *= Quaternion.Euler(0, 90, 0);
        }
    }
}
