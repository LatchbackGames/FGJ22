using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private static int id = 0;
    public int itemId;

    public PickUp(string name)
    {
        itemId = id;
        id++;
        this.name = name;
    }
}
