using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotator : MonoBehaviour
{

    bool rotating;
    bool collected;
    // Use this for initialization
    void Start()
    {
        rotating = false;
        collected = false;
        StartCoroutine(RotateMe(Vector3.up * 180, 2.0f));
    }

    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        while (!collected)
        {
            for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
            {
                transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
                yield return null;
            }
        }
    }
}
