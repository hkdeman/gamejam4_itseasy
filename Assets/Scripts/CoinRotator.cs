using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotator : MonoBehaviour
{
    AudioSource collectibleSource;

    bool rotating;
    bool collected;

    GameObject mapObject;
    GameObject timerGameObject;
    TimerManager timer;
    Map map;

    public GameObject particles;

    // Use this for initialization
    void Start()
    {
        collectibleSource = GameObject.Find("CollectibleAudioSource").GetComponent<AudioSource>();

        rotating = false;
        collected = false;
        StartCoroutine(RotateMe(Vector3.up * 180, 2.0f));
        mapObject = GameObject.FindWithTag("Map");
        map = mapObject.GetComponent<Map>();
        //particles = GameObject.FindWithTag("ParticleSystem");
        timerGameObject = GameObject.FindWithTag("Timer");
        timer = timerGameObject.GetComponent<TimerManager>();
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

    private void OnTriggerEnter(Collider other)
    {

        collectibleSource.Play();

        Instantiate(particles, gameObject.transform.position, gameObject.transform.rotation);
        if (map.currentLevel == 4)
        {
            timer.time += 15.0f;
            float x = GetAValueApartFrom(0, map.COLS - 2, Mathf.RoundToInt(other.gameObject.transform.position.x)) * map.SCALE;
            float z = GetAValueApartFrom(0, map.COLS - 2, Mathf.RoundToInt(other.gameObject.transform.position.z)) * map.SCALE;
            Instantiate(gameObject, new Vector3(x, 2f, z), gameObject.transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        map.score++;
        map.text.text = map.score.ToString();
    }

    private int GetAValueApartFrom(int min, int max, int avoid)
    {
        int value = 0;
        while (true)
        {
            value = UnityEngine.Random.Range(min, max - 1);
            if (value != avoid) break;
        }
        return value;
    }

}
