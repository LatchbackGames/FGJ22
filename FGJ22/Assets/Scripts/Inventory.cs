using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public Item currentItem;
    public static int index = 0;

    public Inventory(Item item)
    {
        currentItem = item;
    }

    public void Start()
    {
        GameObject.FindWithTag("Player").AddComponent<Inventory>();
    }

    
    
    public bool AddToInventory(Item item)
    {
        // If no item add to inventory
        if (currentItem == Item.None)
        {
            currentItem = item;
            return true;
        }

        return false;

    }
}
