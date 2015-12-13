using UnityEngine;
using System.Collections;

public class Tank2 : MonoBehaviour
{

    public static int lifes = 3;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lifes == 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ammo")
        {
            lifes--;
        }
    }
}

