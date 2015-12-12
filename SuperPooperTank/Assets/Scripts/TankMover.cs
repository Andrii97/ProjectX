using UnityEngine;
using System.Collections;

public class TankMover : MonoBehaviour {

    CharacterController cont;
    public float speed = 5f;
	// Use this for initialization
	void Start () {
        cont = GetComponent<CharacterController>();
        
	}
	
	// Update is called once per frame
	void Update () {
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
        if(col.gameObject.name == "Cube")
        {
            Destroy(gameObject);
        }
    }
}
