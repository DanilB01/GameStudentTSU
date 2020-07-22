using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainInventory : MonoBehaviour
{
    public GameObject[] slots;
    public GameObject empty_slot;
    public GameObject[] productSlots;

    private void Start()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (DataHolder.itemID[i] != -1)
            {
                Instantiate(productSlots[DataHolder.itemID[i]], slots[i].transform);
            }
        }
    }

    public bool isFoodExist(int lvlNum, string whatToDo)
    {
        if (DataHolder.isFoodNeed[lvlNum - 1])
        {
            int foodID = -1;
            switch (lvlNum)
            {
                case 1:
                    foodID = 0;
                    break;
                case 2:
                    foodID = 1;
                    break;
                case 3:
                    foodID = 7;
                    break;
                case 4:
                    foodID = 6;
                    break;
                case 5:
                    foodID = 3;
                    break;
                case 6:
                    foodID = 4;
                    break;
                case 7:
                    foodID = 2;
                    break;
                case 8:
                    foodID = 5;
                    break;
            }
            for (int i = 0; i < slots.Length; i++)
            {
                if(DataHolder.itemID[i] == foodID)
                {
                    if (whatToDo == "remove")
                    {
                        Instantiate(empty_slot, slots[i].transform);
                        DataHolder.itemID[i] = -1;
                    }
                    return true;
                }
            }
            return false;
        }
        else
            return false;
    }

   
}
