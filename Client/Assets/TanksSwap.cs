using UnityEngine;
using System.Collections;

public class TanksSwap : MonoBehaviour {

    public GameObject MyTank, BotTank;
    private Vector3 temp;

	// Use this for initialization
	void Start () {
	}

    void Swap()
    {
        BotTank = GameObject.Find("Tank");
        MyTank = GameObject.Find("MyTank");
        temp = BotTank.transform.position;
        BotTank.transform.position = MyTank.transform.position;
        MyTank.transform.position = temp;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
