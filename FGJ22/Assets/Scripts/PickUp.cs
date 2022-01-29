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
// Items which are needed
public enum Item
{
    None,
    Bucket,
    WaterBucket,
    StepLadder,
    Vines,
    Knife,
    Sap,
    PixieDust,

}

// Obstacles which are needed to be crossed
public enum Obstacles
{
   Unicorn,
   WatchRoom,
   Fire,
   ForestFire,
   Water,
   Hole,
   HeavyObject,
   


}
