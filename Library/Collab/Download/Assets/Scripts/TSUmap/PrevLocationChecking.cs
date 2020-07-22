using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrevLocationChecking : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    void Start()
    {
        if (DataHolder.isIn2Campus)
        {
            player.transform.position = new Vector3(-32.36f, 74.15f, 8f);
            cam.transform.position = new Vector3(-32.36f, 74.15f, 0f);
            DataHolder.isIn2Campus = false;
        }
    }
}
