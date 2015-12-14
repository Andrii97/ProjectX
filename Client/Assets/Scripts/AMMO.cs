using UnityEngine;
using System.Collections;

public class AMMO : MonoBehaviour {
    float timer = 0f;
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
        if (col.gameObject.tag == "wall" || col.gameObject.tag == "player")
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }
}
