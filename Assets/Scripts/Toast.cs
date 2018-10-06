using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toast : MonoBehaviour
{

	public GameObject toast;
	
	// Use this for initialization
	void Start () {
		createToast();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void createToast()
	{
		Debug.Log("aaaa");
		var myToast = Instantiate(toast, new Vector3(395.73f, 180f, 0f), toast.transform.rotation);
		myToast.transform.parent = GameObject.Find("Canvas").transform;
//		GameObject GOToast = GameObject.Find("Toast");
		toast.transform.position = new Vector3(395.73f, 180f, 0f);
//		StartCoroutine(animation());
	}
	
	public IEnumerator animation()
	{
		GameObject toast = GameObject.Find("Toast");
		while (toast.transform.position.y > 175f)
		{
			toast.transform.position -= new Vector3(0, 0.1f, 0);
			yield return null;
		}
	}
}
