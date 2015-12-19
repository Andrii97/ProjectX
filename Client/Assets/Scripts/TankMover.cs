using UnityEngine;
using System.Collections;

public class TankMover : MonoBehaviour
{
    CharacterController cont;
    public float speed = 5f, step = 0.1f;
    public static int lifes = 3;
    public GameObject MyRenderer;
    public AudioSource Moving;
    public int sound = 0;
    private bool moving;

    // Use this for initialization
    void Start()
    {
        cont = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cont.isGrounded == false)
        {
            cont.Move(new Vector3(0, -0.1f, 0));
        }
        moving = false;
        if (lifes == 0)
        {
            MyRenderer.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                lifes = 3;
            }
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x != 0)
        {
            moving = true;
            if (sound != 1)
            {
                sound = 1;
            }
            transform.Rotate(0f, x, 0f);            
        }

        if (z != 0)
        {
            moving = true;
            if (sound != 1)
            {
                sound = 1;
            }
            Vector3 direction = new Vector3(0f, 0f, z * speed * Time.deltaTime);
            direction = transform.rotation * direction;
            cont.Move(direction);

        }

        if ( moving == false && (sound == 1 || sound == 0))
        {
            sound = 0;
            if (Moving.volume > 0f)
                Moving.volume -= step*4;
        }

        if (sound == 1 && Moving.volume < 0.45f)
        {
            Moving.volume += step;
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
