using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraRotator : MonoBehaviour {

    public GameObject mapGameObject;
    public bool allowOrientationOne = false;
    public bool allowOrientationTwo = false;
    public bool allowOrientationThree = false;
    public bool allowOrientationFour = false;

    Camera cam;
    Map map;

    private bool rotating;
    private int currentRotation;

	// Use this for initialization
	void Start () {
        rotating = false;
        currentRotation = 0;
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
        var toAngle = Quaternion.Euler(transform.eulerAngles) * Quaternion.Euler(byAngles);
        for (var t = 0f; t <=1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
        rotating = false;
    }

    void Update()
    {
        if (map.currentLevel != 4)
        {
            if (Input.GetKeyDown(KeyCode.E) && !rotating) {
                if((currentRotation == 0 && allowOrientationFour ) || 
                   (currentRotation == 1 && allowOrientationOne) || 
                   (currentRotation == 2 && allowOrientationTwo) || 
                   (currentRotation == 3 && allowOrientationThree)) {
                    currentRotation = currentRotation>0 ? (currentRotation-1) : 3;
                    StartCoroutine(RotateMe(new Vector3(0, -90f, 0), 0.3f));
                }
            } else if (Input.GetKeyDown(KeyCode.Q) && !rotating) {
                if ((currentRotation == 0 && allowOrientationTwo) ||
                    (currentRotation == 1 && allowOrientationThree) ||
                    (currentRotation == 2 && allowOrientationFour) ||
                    (currentRotation == 3 && allowOrientationOne))
                {
                    currentRotation = (currentRotation + 1) % 4;
                    StartCoroutine(RotateMe(new Vector3(0, 90f, 0), 0.3f));
                }
            }
        }
    }

    public void moveRotation(string key1, string key2)
    {
        if (Input.GetKeyDown(key1) && !rotating) {
            if((currentRotation == 0 && allowOrientationFour ) || 
               (currentRotation == 1 && allowOrientationOne) || 
               (currentRotation == 2 && allowOrientationTwo) || 
               (currentRotation == 3 && allowOrientationThree)) {
                currentRotation = currentRotation>0 ? (currentRotation-1) : 3;
                StartCoroutine(RotateMe(new Vector3(0, -90f, 0), 0.3f));
            }
        } else if (Input.GetKeyDown(key2) && !rotating) {
            if ((currentRotation == 0 && allowOrientationTwo) ||
                (currentRotation == 1 && allowOrientationThree) ||
                (currentRotation == 2 && allowOrientationFour) ||
                (currentRotation == 3 && allowOrientationOne))
            {
                currentRotation = (currentRotation + 1) % 4;
                StartCoroutine(RotateMe(new Vector3(0, 90f, 0), 0.3f));
            }
        }
    }
}