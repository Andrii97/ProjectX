using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    public GameObject settings;

    void Start()
    {
        Volume.GetVol();
        settings.SetActive(false);
    }   

    void Update()
    {
      if(settings.active == true)
        {
            Volume.GetVol();
        }
       
        Volume.SetMusic();
    }

    public void NewGame()
    {
        Application.LoadLevel(3);
    }

    public void Choose()
    {
        Application.LoadLevel(3);
    }

    public void Profile()
    {
        Application.LoadLevel(4);
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
        Application.LoadLevel(1);
    }
}
