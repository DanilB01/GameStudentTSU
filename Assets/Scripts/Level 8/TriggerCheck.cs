using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    public int serverID;
    private Inventory inventory;
    public bool IsNecessaryDetailExist = false;

    private ServerStatus servstat;

    
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        servstat = GameObject.FindGameObjectWithTag("Servers").GetComponent<ServerStatus>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (inventory.ifDetailExist(servstat.whichDetailNeed[serverID]))
            {
                IsNecessaryDetailExist = true;
            }
        }

    }

}
