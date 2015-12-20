using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour {

    public int lifes = 3;
    public GameObject BotRenderer, Name;
    public GameObject[] Lifes = new GameObject[3];

    // Use this for initialization
    void Start()
    {
        Name.GetComponent<TextMesh>().text = "Name";
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
            Lifes[lifes].SetActive(false);
        }
    }
}
