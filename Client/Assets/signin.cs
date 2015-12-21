using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.ServiceModel;
using System.IO;
using Service;

public class signin : MonoBehaviour
{
    public GameObject ErrorButton1, ErrorButton2;
    public InputField[] field = new InputField[2];
    public Button[] buttons = new Button[2];

    void Start()
    {
        ErrorButton1.SetActive(false);
        ErrorButton2.SetActive(false);
    }

    public void log()
    {

        /* DatabaseClient client = new DatabaseClient(new BasicHttpBinding(), new EndpointAddress(
                         new System.Uri("http://localhost:8733/Design_Time_Addresses/Service/Database/1")));

         client.BDOpen();*/

        ClientOper.Start();

        GameObject inputFieldGo1 = GameObject.Find("/Canvas/Fields/InputField");
        InputField inputFieldCo1 = inputFieldGo1.GetComponent<InputField>();

        GameObject inputFieldGo2 = GameObject.Find("/Canvas/Fields/InputField (1)");
        InputField inputFieldCo2 = inputFieldGo2.GetComponent<InputField>();




        if (inputFieldCo1.text == "" || inputFieldCo2.text == "")
        {
            //UnityEditor.EditorUtility.DisplayDialog("Ошибка", "Заполните все поля", "ОК");
            Error(ErrorButton2);
        }

        else if (ClientOper.Auth(inputFieldCo1.text, inputFieldCo2.text))
        {
            Data.pass = inputFieldCo1.text;
            Application.LoadLevel(1);
            Debug.Log("Good " + Data.pass);
        }
        else
        {
            //UnityEditor.EditorUtility.DisplayDialog("Ошибка " + "Неправильный логин или пароль");
            Error(ErrorButton1);
            Debug.Log("Bad");
        }

        /*  Statistic st = client.ShowInfo("vovaa");
          Debug.Log("id=" + st.id + " Name=" + st.name);*/
        ClientOper.Close();

    }

    public void Error(GameObject ErrorButton)
    {
        ErrorButton.SetActive(true);
        foreach (InputField i in field)
        {
            i.interactable = false;
        }
        foreach (Button b in buttons)
        {
            b.interactable = false;
        }
    }

    public void Disable(GameObject ErrorButton)
    {
        ErrorButton.SetActive(false);
    }

    public void regist()
    {
        Application.LoadLevel(5);
    }
}