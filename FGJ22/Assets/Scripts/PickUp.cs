using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private static int id = 0; // for 
    public int itemId; // 
    private Item pickUpItem; // As Item.None, etc.
    public Item item;
    public GameObject pickableText; // Used in text display in Pickups

    public PickUp(Item item)
    {
        pickUpItem = item;
        id++;
    }
}
public enum Item
{
    None,
    Bucket,
    WaterBucket,
    StepLadder
}
