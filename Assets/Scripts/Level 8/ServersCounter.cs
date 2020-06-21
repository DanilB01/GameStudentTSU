using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServersCounter : MonoBehaviour
{
    Text txt;
    public static float serversCounter;
    private ServerStatus servstat;
    void Start()
    {
        txt = GetComponent<Text>();
        servstat = GameObject.FindGameObjectWithTag("Servers").GetComponent<ServerStatus>();
    }
    void Update()
    {
        txt.text = "Серверов: " + servstat.AliveServers() + "/12";
    }
}
