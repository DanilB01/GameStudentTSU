using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public GameObject empty_slot;
    public int[] itemID = new int[6];

    public bool ifDetailExist(int id)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (itemID[i] == id)
            {
                Instantiate(empty_slot, slots[i].transform);
                isFull[i] = false;
                itemID[i] = -1;
                return true;
            }
        }
        return false;
    }
}
