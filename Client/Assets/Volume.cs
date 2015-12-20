using UnityEngine;
using UnityEngine.UI;
using System.Collections;

static class Volume{

    public static float f;
    public static float fm;

    public static void GetVol()
    {
        f = GameObject.Find("Slider").GetComponent<Slider>().value;
        fm = GameObject.Find("Slider(1)").GetComponent<Slider>().value;
    }

    public static void SetVol()
    {
        GameObject.Find("Terrain").GetComponent<AudioSource>().volume *= f;
        GameObject.Find("MySound").GetComponent<AudioSource>().volume *= f;
        GameObject.Find("MyStartEngine").GetComponent<AudioSource>().volume *= f;
        GameObject.Find("MyEngineWorks").GetComponent<AudioSource>().volume *= f;
        GameObject.Find("BotSound").GetComponent<AudioSource>().volume *= f;
        GameObject.Find("BotStartEngine").GetComponent<AudioSource>().volume *= f;
        GameObject.Find("BotEngineWorks").GetComponent<AudioSource>().volume *= f;
        GameObject.Find("Fire").GetComponent<AudioSource>().volume *= f;
    }

    public static void SetMusic()
    {
        GameObject.Find("Music").GetComponent<AudioSource>().volume = fm;
    }

}
