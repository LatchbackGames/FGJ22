using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    private GameObject player; // Player
    private bool pickable; // If something can be picked
    private Item item; // Item which picking
    private PickUp text; // Interactable notification
    private GameObject pickup; // Is the pickup object which we turn off when pickedUp
    private Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory(Item.None); // Starting with No Items
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
                item = inventory.currentItem;
                Debug.Log(inventory.currentItem);
                pickup.SetActive(false); 
            }
            
        }
    }

    
    // On Trigger add to inventory if possible
    private void OnTriggerEnter2D(Collider2D other)
    {
        pickable = true; // If inside trigger / pickable
        // PickUp from the pickup object
        item = other.GetComponent<PickUp>().item; // For Item.Bucket etc.
        text = other.GetComponent<PickUp>(); // GetText from child
        text.pickableText.SetActive(true); // Di
        pickup = other.gameObject; // initializing pickup to be able to set non active


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        pickable = false; // If inside trigger
        text.pickableText.SetActive(false); // Text disabled
    }
}
