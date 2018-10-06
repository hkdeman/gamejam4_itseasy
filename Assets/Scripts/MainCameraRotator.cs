using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraRotator : MonoBehaviour {

    public GameObject mapGameObject;

    Camera cam;
    Map map;

    private bool rotating;

	// Use this for initialization
	void Start () {
        rotating = false;
        map = mapGameObject.GetComponent<Map>();
        transform.position = new Vector3((map.ROWS/2)*map.SCALE, 0, (map.COLS/2)*map.SCALE-2);

        cam = GetComponentInChildren<Camera>();
        cam.transform.position = new Vector3(-2.0f, 4.0f, -7.0f);
        cam.transform.rotation = Quaternion.Euler(30, 20, 0);
    }

    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        rotating = true;
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
        rotating = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !rotating)
        {
            StartCoroutine(RotateMe(Vector3.up * 90.62f, 0.3f));
        }
    }
}