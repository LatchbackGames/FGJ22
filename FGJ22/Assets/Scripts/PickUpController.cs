using System.Net.Mail;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    private GameObject player; // Player
    private bool pickable; // If something can be picked
    private bool usable; // If item can be used for something
    private Item item; // Item which picking
    private Obstacles obs; // Obstacle tracking
    private PickUp text; // Interactable notification
    private GameObject pickup; // Is the pickup object which we turn off when pickedUp
    [HideInInspector]
    public Inventory inventory;

    private GameObject lastOther;
    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory(Item.None); // Starting with No Items
        inventory.currentItem = Item.StepLadder;
        item = Item.StepLadder;
        // Find player and instantiate
        player = GameObject.FindWithTag("Player");
        

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E) && (usable || pickable))
        {
            // Inventory from player
            if (pickable)
            {
                PickUpItem();
            }

            else if (usable)
            {
                inventory.currentItem = UseItem();
                item = inventory.currentItem;
                //Used item
                Debug.Log("Current inventory is "+ inventory.currentItem);
            }
            
        }

        if (Input.GetKey(KeyCode.H))
        {
            Debug.Log("Inventory " + inventory.currentItem);
        }
    }

    // Uses item
    // Removed
    public Item UseItem()
    {
        Item usedUp = item; // which is used so like waterbucket on fire or filled bucket
        if (item != Item.None && UsableItem(item,lastOther))
        {
            switch (item)
            {
                case Item.Bucket:
                    usedUp = Item.WaterBucket;
                    Debug.Log("Filled water bucket");
                    break;
                case Item.Knife:
                    usedUp = Item.Knife;
                    Debug.Log("You cut Vines");
                    break;
                case Item.PixieDust:
                    usedUp = Item.None;
                    Debug.Log("Moved heavy boulder");
                    break;
                //TODO
                case Item.Vines:
                    usedUp = Item.StickyVines;
                    Debug.Log("StickyVines");
                    break;
                case Item.WaterBucket:
                    usedUp = Item.None;
                    Debug.Log("You Stopped Fires");
                    break;
                case Item.StepLadder:
                    usedUp = Item.None;
                    break;
                //TODO? yes but functionality from ui and more info
                default:
                    Debug.Log("undefined");
                    break;
                    
            }
            pickup.SetActive(false);
        }

        return usedUp;
    }
    public void PickUpItem()
    {
        if (item != Item.None)
        {
            if (inventory.AddToInventory(item))
            {
                FindObjectOfType<AudioManager>().Play(item.ToString()); //Play sound effect correctly maybe
                item = inventory.currentItem;
                Debug.Log(inventory.currentItem);
                pickup.SetActive(false); 
            }
        }
        
    }
    
    // If item has uses with obstacle allow use
    public bool UsableItem(Item item,GameObject other)
    {
        var x = other.GetComponent<PickUp>().obs; 
        //Debug.Log("x = "+x);
        bool usable = false;
        switch (item)
        {
            case Item.Bucket:
                if (x == Obstacles.Water)
                {
                    usable = true;
                }
                break;
            case Item.PixieDust:
                if (x == Obstacles.HeavyObject)
                {
                    usable = true;
                }
                break;
            //TODO
            case Item.Knife:
                if (x == Obstacles.Vines)
                {
                    usable = true;
                }
                break;
            case Item.Vines:
                if (x == Obstacles.Sap)
                {
                    usable = true;
                }
                    break;
            case Item.WaterBucket:
                if (x == Obstacles.Fire)
                {
                    usable = true;
                }
                break;
            case Item.StepLadder:
                if (x == Obstacles.Obstacle)
                {
                    usable = true;
                }
                break;
            case Item.None:
                break;
            default:
                break;
        }

        return usable;
    }

 
    // On Trigger add to inventory if possible
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        
        pickup = other.gameObject; // initializing pickup to be able to set non active
        lastOther = other.gameObject;
        text = other.GetComponent<PickUp>(); // GetText from child
        
        // If player not holding anything
        if (inventory.currentItem == Item.None) 
        {
            pickable = true;
            item = other.GetComponent<PickUp>().item; // For Item.Bucket etc.
            obs = other.GetComponent<PickUp>().obs;
            //if pickable and not obstacle and not null item
            if (pickable && (obs == Obstacles.None && item != Item.None))
            {
                text.pickableText.SetActive(true); // Di
            } else if (usable)
            {
                text.pickableText.SetActive(true); // Di
            }
        }
        usable = UsableItem(item, other.gameObject);
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Unable the pickables of objectives
        pickable = false; // If inside trigger
        usable = false;
        text.pickableText.SetActive(false); // Text disabled
        
        
    }
}
