using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public Item item;
    public static int index = 0;

    public Inventory()
    {
        item = Item.None;
    }

    public void Start()
    {
        GameObject.FindWithTag("Player").AddComponent<Inventory>();
    }

    public bool AddToInventory(Item item)
    {
        if (item == Item.None)
        {
            item = this.item;
            return true;
        }

        return false;

    }
}
