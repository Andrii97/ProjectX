using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class singup : MonoBehaviour {

    public void regist()
    {
        GameObject inputFieldGo1 = GameObject.Find("/Canvas/InputField");
        InputField inputFieldCo1 = inputFieldGo1.GetComponent<InputField>();
       
        GameObject inputFieldGo2 = GameObject.Find("/Canvas/InputField (1)");
        InputField inputFieldCo2 = inputFieldGo2.GetComponent<InputField>();

        GameObject inputFieldGo3 = GameObject.Find("/Canvas/InputField (2)");
        InputField inputFieldCo3 = inputFieldGo3.GetComponent<InputField>();

        if (inputFieldCo3.text == inputFieldCo2.text && inputFieldCo3.text != "" && inputFieldCo2.text != "")
        {
            Application.LoadLevel(1);
        }

        if (inputFieldCo3.text != inputFieldCo2.text && inputFieldCo3.text != "" && inputFieldCo2.text != "")
        {
            UnityEditor.EditorUtility.DisplayDialog("Ошибка", "Пароли не совпадают", "ОК");
        }

        else if (inputFieldCo1.text == "" || inputFieldCo2.text == "" || inputFieldCo3.text == "")
        {
            UnityEditor.EditorUtility.DisplayDialog("Ошибка", "Заполните все поля", "ОК");
        }
    }
}
