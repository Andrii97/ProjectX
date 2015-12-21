using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Profile : MonoBehaviour {

    Text id, login, all, win, lose;

    void Update()
    {

        ClientOper.Start();
        id.text = ClientOper.Info().id.ToString();
        login.text = ClientOper.Info().name.ToString();
        all.text = ClientOper.Info().all.ToString();
        win.text = ClientOper.Info().win.ToString();
        lose.text = ClientOper.Info().lose.ToString();
        ClientOper.Close();

    }

    void Start()
    {
        ClientOper.Start();

        id = GameObject.Find("/Canvas/Text (5)").GetComponent<Text>();
        login = GameObject.Find("/Canvas/Text (6)").GetComponent<Text>();
        all = GameObject.Find("/Canvas/Text (9)").GetComponent<Text>();
        win = GameObject.Find("/Canvas/Text (7)").GetComponent<Text>();
        lose = GameObject.Find("/Canvas/Text (8)").GetComponent<Text>();


        id.text = ClientOper.Info().id.ToString();
        login.text = ClientOper.Info().name.ToString();
        all.text = ClientOper.Info().all.ToString();
        win.text = ClientOper.Info().win.ToString();
        lose.text = ClientOper.Info().lose.ToString();

        ClientOper.Close();
    }

    public void Back_To_Menu()
    {
        Application.LoadLevel(1);
    }
}
