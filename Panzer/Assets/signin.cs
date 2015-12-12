using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.ServiceModel;
using System.IO;
using Service;

public class signin : MonoBehaviour {

    public void log()
    {
        DatabaseClient client = new DatabaseClient(new BasicHttpBinding(), new EndpointAddress(
                        new System.Uri("http://localhost:8733/Design_Time_Addresses/Service/Database/1")));
       
        GameObject inputFieldGo1 = GameObject.Find("/Canvas/InputField");
        InputField inputFieldCo1 = inputFieldGo1.GetComponent<InputField>();
        
        GameObject inputFieldGo2 = GameObject.Find("/Canvas/InputField (1)");
        InputField inputFieldCo2 = inputFieldGo2.GetComponent<InputField>();

        client.BDOpen();
        if (client.Authorization(inputFieldCo1.text, inputFieldCo2.text))
        {
            Application.LoadLevel(1);
            Debug.Log("Good");
        }
        else if (!client.Authorization(inputFieldCo1.text, inputFieldCo2.text) || inputFieldCo1.text != "" || inputFieldCo2.text != "")
        {
            UnityEditor.EditorUtility.DisplayDialog("Ошибка", "Неправильный логин или пароль", "ОК");
            Debug.Log("Bad");
        }

        else if (inputFieldCo1.text == "" || inputFieldCo2.text == "")
        {
            UnityEditor.EditorUtility.DisplayDialog("Ошибка", "Заполните все поля", "ОК");
        }
        /*  Statistic st = client.ShowInfo("vovaa");
          Debug.Log("id=" + st.id + " Name=" + st.name);*/
        client.BDClose();
        client.Close();
    
    }

    public void regist()
    {
        Application.LoadLevel(5);
    }
}
