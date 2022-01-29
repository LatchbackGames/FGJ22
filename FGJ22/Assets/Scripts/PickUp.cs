using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private static int id = 0;
    public int itemId;
    public GameObject pickableText;
    [SerializeField] private Use ability;

    public enum Use
    {
        Improve, // Bucket to Water Bucket
        SingleUse, // Ladder etc
        Combine, // ??
    }
    public PickUp(string name)
    {
        itemId = id;
        id++;
        this.name = name;
    }
}
