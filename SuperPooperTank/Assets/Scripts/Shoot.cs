using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public GameObject ammo;
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newAmmo = (GameObject)Instantiate(ammo, transform.position, transform.rotation);
            newAmmo.GetComponent<Rigidbody>().AddForce(transform.forward * 500f, ForceMode.Force);
        }
	}
}
