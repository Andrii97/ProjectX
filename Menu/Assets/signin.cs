using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class signin : MonoBehaviour {

    public void log()
    {
        string username = "ProjectX";
        string password = "1";
        GameObject inputFieldGo1 = GameObject.Find("/Canvas/InputField");
        InputField inputFieldCo1 = inputFieldGo1.GetComponent<InputField>();
        
        GameObject inputFieldGo2 = GameObject.Find("/Canvas/InputField (1)");
        InputField inputFieldCo2 = inputFieldGo2.GetComponent<InputField>();
       

        if (inputFieldCo1.text == username && inputFieldCo2.text == password)
        {
            Application.LoadLevel(1);
        }

        if (inputFieldCo1.text != username && inputFieldCo1.text != "" || inputFieldCo2.text != password && inputFieldCo2.text != "")
        {
           UnityEditor.EditorUtility.DisplayDialog("Ошибка", "Неправильный логин или пароль", "ОК");
        }

        else if (inputFieldCo1.text == "" || inputFieldCo2.text == "")
        {
            UnityEditor.EditorUtility.DisplayDialog("Ошибка", "Заполните все поля", "ОК");
        }
    }

    public void regist()
    {
        Application.LoadLevel(5);
    }
}
