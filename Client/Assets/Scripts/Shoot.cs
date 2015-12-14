using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public GameObject ammo;

    void Start () {
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 n = transform.position;
            n.y = +1.5f;
            n.z = +4;
            GameObject newAmmo = (GameObject)Instantiate(ammo, n, transform.rotation);
            newAmmo.GetComponent<Rigidbody>().AddForce(transform.forward * 500f, ForceMode.Force);

        }
	}
}
