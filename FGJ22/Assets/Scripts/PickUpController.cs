using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    private GameObject player;
    private bool pickable;
    private PickUp item;
    private PickUp current;
    private GameObject pickup;

    private Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory();
        // Find player and instantiate
        player = GameObject.FindWithTag("Player");
        

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.C) && pickable)
        {
            Debug.Log(item.name);
            // Inventory from player
            if (inventory.AddToInventory(item))
            {
                current = item;
                pickup.SetActive(false); 
            }
            
        }
    }

    
    // On Trigger add to inventory if possible
    private void OnTriggerEnter2D(Collider2D other)
    {
        pickable = true;
        // PickUp from the pickup object
        item = other.GetComponent<PickUp>();
        pickup = other.gameObject;


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        pickable = false;
    }
}
