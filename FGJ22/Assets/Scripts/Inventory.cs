using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public PickUp[] items;
    public static int index = 0;

    public Inventory()
    {
        items = new PickUp[1];
    }

    public void Start()
    {
        GameObject.FindWithTag("Player").AddComponent<Inventory>();
    }

    public bool AddToInventory(PickUp item)
    {
        if (index < items.Length)
        {
            items[Inventory.index++] = item;
            return true;
        }

        return false;

    }

    public void DisplayInventory()
    {
        for (int i = 0; i < items.Length -1; i++)
        {
            if (items[i] != null)
            {
                Debug.Log(items[i].name);
            }
           
            
        }
    }
}
