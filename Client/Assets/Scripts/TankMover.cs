using UnityEngine;
using System.Collections;

public class TankMover : MonoBehaviour {
    CharacterController cont;
    public float speed = 5f;
    public static int lifes = 3;

    // Use this for initialization
    void Start()
    {
        cont = GetComponent<CharacterController>();


    }

    // Update is called once per frame
    void Update()
    {
        if (lifes == 0)
        {
            Destroy(gameObject);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x != 0)
            transform.Rotate(0f, x, 0f);
        if (z != 0)
        {

            Vector3 direction = new Vector3(0f, 0f, z * speed * Time.deltaTime);
            direction = transform.rotation * direction;
            cont.Move(direction);

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
