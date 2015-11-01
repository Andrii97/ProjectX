using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    public GameObject settings;

    public void NewGame()
    {
        Application.LoadLevel(1);
    }

    public void Choose()
    {
        Application.LoadLevel(2);
    }

    public void Profile()
    {
        Application.LoadLevel(3);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Settings()
    {
        settings.SetActive(!settings.activeSelf);
    }

    public void Back_To_Menu()
    {
        Application.LoadLevel(0);
    }
}
