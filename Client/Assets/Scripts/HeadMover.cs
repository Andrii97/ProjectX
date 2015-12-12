using UnityEngine;
using System.Collections;

public class HeadMover : MonoBehaviour {

    float x;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetMouseButton(1))
        {
            x += Input.GetAxis("Mouse X");
            transform.rotation = Quaternion.Euler(0f, x * 10f, 0f);
        }
	}
}
