using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private static int id = 0;
    public int itemId;
    public Item item;
    public GameObject pickableText;

    public PickUp()
    {
        item = item;
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
