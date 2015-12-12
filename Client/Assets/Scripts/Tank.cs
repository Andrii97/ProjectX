using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour
{

    public GameObject ammo;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newAmmo = (GameObject)Instantiate(ammo, transform.position, transform.rotation);

        }
    }
}
