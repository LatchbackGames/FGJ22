using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    private GameObject player;
    private bool pickable;
    private Item item;
    private PickUp text;
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
        if (Input.GetKey(KeyCode.E) && pickable)
        {
            // Inventory from player
            if (inventory.AddToInventory(item))
            {
                item = item;
                pickup.SetActive(false); 
            }
            
        }
    }

    
    // On Trigger add to inventory if possible
    private void OnTriggerEnter2D(Collider2D other)
    {
        pickable = true;
        // PickUp from the pickup object
         text = other.GetComponent<PickUp>();
        text.pickableText.SetActive(true);
        pickup = other.gameObject;


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        pickable = false;
        text.pickableText.SetActive(false);
    }
}
