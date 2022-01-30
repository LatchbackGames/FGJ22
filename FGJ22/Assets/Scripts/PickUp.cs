using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private static int id = 0; // for 
    //public int itemId; // 
    private Item pickUpItem; // As Item.None, etc.
    public Item item;
    public Obstacles obs;
    public GameObject pickableText; // Used in text display in Pickups

    public PickUp(Item item)
    {
        pickUpItem = item;
        id++;
    }

    // Excecute Ui Elements for load etc. when Prefab initiaites
    public void Start()
    {
       
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
    PixieDust,
    StickyVines,
    Key,

}

// Obstacles which are needed to be crossed
public enum Obstacles
{
    None, 
    Unicorn,
   WatchRoom,
   Fire,
   Sap,
   ForestFire,
   Water,
   Hole,
   HeavyObject,
   Vines,
   Obstacle,
   
}
