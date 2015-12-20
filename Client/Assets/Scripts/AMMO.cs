﻿using UnityEngine;
using System.Collections;

public class AMMO : MonoBehaviour {
    float timer = 0f;
    public GameObject fire;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (timer < 100f)
            timer += 1f;
        else Destroy(gameObject);

    }

    void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);
        Vector3 fireplace = gameObject.transform.forward;
        GameObject newFire = (GameObject)Instantiate(fire, gameObject.transform.position, gameObject.transform.rotation);
        newFire.GetComponent<Rigidbody>();
    }
}
