using UnityEngine;
using System.ServiceModel;
using UnityEngine.UI;
using System.Collections;

public class singup : MonoBehaviour {

    public GameObject ErrorButton1, ErrorButton2;
    public InputField[] field = new InputField[3];
    public Button[] buttons = new Button[2];

    void Start()
    {
        ErrorButton1.SetActive(false);
        ErrorButton2.SetActive(false);
    }
    
    public void regist()
    {

        DatabaseClient client = new DatabaseClient(new BasicHttpBinding(), new EndpointAddress(
                        new System.Uri("http://localhost:8733/Design_Time_Addresses/Service/Database/1")));

        client.BDOpen();
        GameObject inputFieldGo1 = GameObject.Find("/Canvas/Fields/InputField");
        InputField inputFieldCo1 = inputFieldGo1.GetComponent<InputField>();
       
        GameObject inputFieldGo2 = GameObject.Find("/Canvas/Fields/InputField (1)");
        InputField inputFieldCo2 = inputFieldGo2.GetComponent<InputField>();

        GameObject inputFieldGo3 = GameObject.Find("/Canvas/Fields/InputField (2)");
        InputField inputFieldCo3 = inputFieldGo3.GetComponent<InputField>();

        if (inputFieldCo3.text == inputFieldCo2.text && inputFieldCo3.text != "" && inputFieldCo2.text != "" && inputFieldCo1.text != "")
        {
            client.AddPerson(inputFieldCo1.text, inputFieldCo2.text);
            Application.LoadLevel(1);
        }

        if (inputFieldCo3.text != inputFieldCo2.text && inputFieldCo3.text != "" && inputFieldCo2.text != "" && inputFieldCo1.text != "")
        {
            //   UnityEditor.EditorUtility.DisplayDialog("Ошибка", "Пароли не совпадают", "ОК");
            inputFieldCo1.text = "";
            inputFieldCo2.text = "";
            inputFieldCo3.text = "";
            Error(ErrorButton1);
        }

        else if (inputFieldCo1.text == "" || inputFieldCo2.text == "" || inputFieldCo3.text == "")
        {
            //     UnityEditor.EditorUtility.DisplayDialog("Ошибка", "Заполните все поля", "ОК");
            inputFieldCo1.text = "";
            inputFieldCo2.text = "";
            inputFieldCo3.text = "";
            Error(ErrorButton2);
        }

            client.BDClose();
        client.Close();
    }

    public void Error(GameObject ErrorButton)
    {
        ErrorButton.SetActive(true);
        foreach(InputField i in field)
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
     
    public void Back()
    {
        Application.LoadLevel(0);
    }
}
