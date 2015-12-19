using UnityEngine;
using System.Collections;

public class Diffuse : MonoBehaviour
{

    public Color _color;
    public float step;
    public int status = 0;

    // Use this for initialization
    void Start()
    {
        _color = gameObject.GetComponent<Renderer>().material.GetColor("_TintColor");

    }

    void VictoryMessage()
    {
        if (status == 1)
        {
            if (_color.a < 0.5)
            {
                _color.a += step / 100;
                gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", _color);
            }
            else
                status = 2;
        }
        else if (status == 2)
        {
            if (_color.a > 0.4)
            {
                _color.a -= step / 1000;
                gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", _color);
            }
            else
                status = 3;
        }
        else if (status == 3)
        {
            if (_color.a < 0.5)
            {
                _color.a += step / 1000;
                gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", _color);
            }
            else
                status = 2;
        }
    }

    void DeathMessage()
    {

    }

    // Update is called once per frame
    void Update()
    {
        VictoryMessage();
        if (Input.GetKeyDown(KeyCode.F1))
        {
            status = 1;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(status != 0)
            {
            }
        }

    }
}
