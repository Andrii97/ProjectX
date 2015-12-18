using UnityEngine;
using System.Collections;

public class MapController : MonoBehaviour {

    public GameObject BotTank, MyTank, ammo, test, Victory, Death;
    private Vector3 temp;
    public int status = 0, WinTrigger;
    public float step;
    public Color EndMsgColor;

    // Use this for initialization
    void Start () {
        
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

    void EndMessage(GameObject obj)
    {
        if (status == 1)
        {
            if (EndMsgColor.a < 0.5)
            {
                EndMsgColor.a += step / 100;
                obj.GetComponent<Renderer>().material.SetColor("_TintColor", EndMsgColor);
            }
            else
                status = 2;
        }
        else if (status == 2)
        {
            if (EndMsgColor.a > 0.4)
            {
                EndMsgColor.a -= step / 1000;
                obj.GetComponent<Renderer>().material.SetColor("_TintColor", EndMsgColor);
            }
            else
                status = 3;
        }
        else if (status == 3)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                status = 0;
                WinTrigger = 0;
                EndMsgColor.a = 0;
                obj.GetComponent<Renderer>().material.SetColor("_TintColor", EndMsgColor);
                Application.LoadLevel("menu");
            }
            else if (EndMsgColor.a < 0.5)
            {
                EndMsgColor.a += step / 1000;
                obj.GetComponent<Renderer>().material.SetColor("_TintColor", EndMsgColor);
            }
            else
                status = 2;
        }
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.F1) && WinTrigger == 0)
        {
            status = 1;
            WinTrigger = 1;
            EndMsgColor = Victory.GetComponent<Renderer>().material.GetColor("_TintColor");
        }

        if (Input.GetKeyDown(KeyCode.F2) && WinTrigger == 0)
        {
            status = 1;
            WinTrigger = 2;
            EndMsgColor = Death.GetComponent<Renderer>().material.GetColor("_TintColor");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateMyAmmo();
        }
        
        if (WinTrigger == 1)
        {
            EndMessage(Victory);
        }
        else
        {
            EndMessage(Death);            
        }        
    }
}
