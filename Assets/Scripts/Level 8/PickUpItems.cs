using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    private Inventory inventory;
    public GameObject slotButton;

    public int itemId;
    public GameObject PressFPanel;

    private bool iftrig = false;

    public AudioSource TakeSound;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (iftrig)
            {
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.isFull[i] == false)
                    {
                        TakeSound.Play();
                        inventory.isFull[i] = true;
                        Instantiate(slotButton, inventory.slots[i].transform);
                        inventory.itemID[i] = itemId;
                        break;
                    }
                }
            }
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            iftrig = true;
            PressFPanel.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        iftrig = false;
        PressFPanel.SetActive(false);
    }
}
