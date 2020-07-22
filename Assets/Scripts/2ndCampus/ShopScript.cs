using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public GameObject InventoryObject;
    private MainInventory inventory;
    
    public GameObject[] slotButton;
    public Text numOfSq;

    private void Start()
    {
        inventory = InventoryObject.GetComponent<MainInventory>();
        numOfSq.text = "Белочек: " + DataHolder.coinsCount + " шт";
    }

    public void Buying(int id)
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (DataHolder.itemID[i] == -1 && DataHolder.coinsCount >= 7)
            {
                Instantiate(slotButton[id], inventory.slots[i].transform);
                DataHolder.itemID[i] = id;
                DataHolder.coinsCount -= 7;
                numOfSq.text = "Белочек: " + DataHolder.coinsCount + " шт";
                break;
            }
        }
    }
}
