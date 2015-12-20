using UnityEngine;
using System.Collections;

public class MapController : MonoBehaviour {

    public GameObject BotTank, MyTank, MyAmmo, BotAmmo, MyRenderer, BotRenderer, ammo, Victory, Death;
    private Vector3 temp;
    public int status = 0, WinTrigger = 0;
    public float step, time = 0, vol = Volume.f;
    public Color EndMsgColor;
    public AudioSource BotShoot, MyShoot, BotMove;

    // Use this for initialization
    void Start () {
        Volume.SetVol();
        BotRenderer.SetActive(true);
        status = 0;
    }

    void Swap()
    {
        temp = BotTank.transform.position;
        BotTank.transform.position = MyTank.transform.position;
        MyTank.transform.position = temp;

    }

    void UpdTankPos(Vector3 pos, Vector3 rot)
    {
        if (BotTank.transform.position != pos || BotTank.transform.rotation != Quaternion.Euler(rot))
        {
            if (BotMove.volume < 0.45f)
                BotMove.volume += 0.01f*vol;
        }
        else if (BotMove.volume > 0f)
        {
            BotMove.volume -= 0.1f*vol;
        }
        BotTank.transform.position = pos;
        BotTank.transform.rotation = Quaternion.Euler(rot);
    }

    void CreateBotAmmo()
    {
        BotShoot.GetComponent<AudioSource>().Play();
        Vector3 force = BotAmmo.transform.forward;
        force.y += 0.05f;
        GameObject newAmmo = (GameObject)Instantiate(ammo, BotAmmo.transform.position, BotAmmo.transform.rotation);
        newAmmo.GetComponent<Rigidbody>().AddForce(force * 1000f, ForceMode.Force);
    }

    void CreateMyAmmo()
    {
        MyShoot.GetComponent<AudioSource>().Play();
        Vector3 force = MyAmmo.transform.forward;
        force.y += 0.05f;
        GameObject newAmmo = (GameObject)Instantiate(ammo, MyAmmo.transform.position, MyAmmo.transform.rotation);
        newAmmo.GetComponent<Rigidbody>().AddForce(force * 1000f, ForceMode.Force);
    }

    void EndMessage(GameObject obj)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {            
            Application.LoadLevel("menu");
            Unpause();
        }
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
            if (EndMsgColor.a < 0.5)
            {
                EndMsgColor.a += step / 1000;
                obj.GetComponent<Renderer>().material.SetColor("_TintColor", EndMsgColor);
            }
            else
                status = 2;
        }
    }   

	void Pause()
	{
		Time.timeScale = 0;
	}
    
    void Unpause()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update () {

        if (time > 0)
        {
            time --;
        }

        if (BotRenderer.activeSelf == false && WinTrigger == 0)
        {
			Pause();
            status = 1;
            WinTrigger = 1;
            EndMsgColor = Victory.GetComponent<Renderer>().material.GetColor("_TintColor");
        }

		if (MyRenderer.activeSelf == false && WinTrigger == 0)
        {
            Pause();
            status = 1;
            WinTrigger = 2;
            EndMsgColor = Death.GetComponent<Renderer>().material.GetColor("_TintColor");
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && WinTrigger == 0 && time == 0)
        {
            time = 100;
            CreateMyAmmo();
        }

        if (Input.GetKeyDown(KeyCode.F2) && WinTrigger == 0)
        {
            CreateBotAmmo();
        }

        if (WinTrigger == 1)
        {
            EndMessage(Victory);
        }

        else if (WinTrigger == 2)
        {
            EndMessage(Death);            
        }        
    }
}
