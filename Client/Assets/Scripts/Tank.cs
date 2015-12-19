using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour {

    public static int lifes = 3;
    public GameObject BotRenderer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lifes == 0)
        {            
            BotRenderer.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                lifes = 3;
            }
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
