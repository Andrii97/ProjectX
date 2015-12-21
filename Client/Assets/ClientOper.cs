using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.ServiceModel;
using System.IO;
using Service;

static public class ClientOper{

    static public DatabaseClient client;

    static public void Start ()
    {
        client = new DatabaseClient(new BasicHttpBinding(), new EndpointAddress(
                        new System.Uri("http://localhost:8733/Design_Time_Addresses/Service/Database/1")));

        client.BDOpen();
    }

    static public bool Auth(string l, string p)
    {
        return client.Authorization(l, p);
    }

    static public bool AddP(string l, string p)
    {
        return client.AddPerson(l, p);
    }

    static public Statistic Info()
    {
        return client.ShowInfo(Data.pass);
    }

    static public void Close()
    {
        client.BDClose();
        client.Close();
    }
}
