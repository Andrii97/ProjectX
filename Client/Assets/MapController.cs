using UnityEngine;
using System.Collections;

public class MapController : MonoBehaviour {

    public GameObject BotTank, MyTank, ammo, test;
    private Vector3 temp;

    // Use this for initialization
    void Start () {

        CreateChild();
    }

    void Swap()
    {
        MyTank = GameObject.Find("MyTank");
        BotTank = GameObject.Find("Tank");
        temp = BotTank.transform.position;
        BotTank.transform.position = MyTank.transform.position;
        MyTank.transform.position = temp;

    }

    void UpdTankPos(Vector3 pos, Vector3 rot)
    {
        BotTank = GameObject.Find("Tank");
        BotTank.transform.position = pos;
        BotTank.transform.rotation = Quaternion.Euler(rot); ;
    }

    void CreateBotAmmo()
    {
        BotTank = GameObject.Find("BotAmmo");
        Vector3 force = BotTank.transform.forward;
        force.y += 0.1f;
        GameObject newAmmo = (GameObject)Instantiate(ammo, BotTank.transform.position, BotTank.transform.rotation);
        newAmmo.GetComponent<Rigidbody>().AddForce(force * 500f, ForceMode.Force);
    }

    void CreateMyAmmo()
    {
        MyTank = GameObject.Find("MyAmmo");
        Vector3 force = MyTank.transform.forward;
        force.y += 0.1f;
        GameObject newAmmo = (GameObject)Instantiate(ammo, MyTank.transform.position, MyTank.transform.rotation);
        newAmmo.GetComponent<Rigidbody>().AddForce(force * 500f, ForceMode.Force);
    }
    
    void CreateChild()
    {
        GameObject canvas = GameObject.Find("Canvas");
        GameObject button = Instantiate(test) as GameObject;
        button.transform.parent = canvas.transform;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateMyAmmo();
        }
    }
}
