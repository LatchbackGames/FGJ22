using System.Net.Mail;
using TouchControlsKit;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    private GameObject player; // Player
    private bool pickable; // If something can be picked
    private bool usable; // If item can be used for something
    private bool winGame;
    private Item item; // Item which picking
    private Obstacles obs; // Obstacle tracking
    private PickUp text; // Interactable notification
    private GameObject pickup; // Is the pickup object which we turn off when pickedUp
    [HideInInspector]
    public Inventory inventory;

    public FadeToBlack fade;

    private GameObject lastOther;

    public TCKButton buttonPickUp;
    // Start is called before the first frame update
    void Start()
    {
        item = Item.Key;
        inventory = new Inventory(item); // Starting with No Items
        // Find player and instantiate
        player = GameObject.FindWithTag("Player");
        Debug.Log(buttonPickUp.identifier);
        
        //inventory.currentItem = item = Item.Key;

    }

    void Update()
    {
        if (winGame)
        {
            return;
        }

        if ((Input.GetKey(KeyCode.E) || buttonPickUp.isDOWN)  && (usable || pickable))
        {
            if (winGame)
            {
                Debug.Log("Won The Game!");
                fade.fadeBlack = FadeBlack.To;
            }
            // Inventory from player
            else if (pickable)
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
            var destroyItem = true;
            switch (item)
            {
                case Item.Bucket:
                    usedUp = Item.WaterBucket;
                    FindObjectOfType<AudioManager>().Play("Water");
                    Debug.Log("Filled water bucket");
                    break;
                case Item.Knife:
                    usedUp = Item.Vines;
                    FindObjectOfType<AudioManager>().Play("Vines");
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
                    FindObjectOfType<AudioManager>().Play("Fire");
                    Debug.Log("You Stopped Fires");
                    break;
                case Item.StepLadder:
                    var obstacle = lastOther.GetComponent<Obstacle>();
                    obstacle.Disables.SetActive(false);
                    obstacle.Enables.SetActive(true);
                    var trigger = lastOther.GetComponent<BoxCollider2D>();
                    trigger.enabled = false;
                    destroyItem = false;
                    usedUp = Item.None;
                    break;
                case Item.StickyVines:
                    var stickObstacle = lastOther.GetComponent<Obstacle>();
                    stickObstacle.Disables.SetActive(false);
                    stickObstacle.Enables.SetActive(true);
                    var stickTrigger = lastOther.GetComponent<BoxCollider2D>();
                    stickTrigger.enabled = false;
                    destroyItem = false;
                    FindObjectOfType<AudioManager>().Play("Sap");
                    usedUp = Item.None;
                    break;
                case Item.Key:
                    FindObjectOfType<AudioManager>().Play("UseKey");
                    usedUp = Item.None;
                    break;
                case Item.Unicorn:
                    usedUp = Item.Unicorn;
                    destroyItem = false;
                    break;
                //TODO? yes but functionality from ui and more info
                default:
                    Debug.Log("undefined");
                    break;
                    
            }
            if(destroyItem)
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
                if (item == Item.Unicorn)
                {
                    Debug.Log("Won The Game!");
                    fade.fadeBlack = FadeBlack.To;
                }
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
                if (x == Obstacles.ForestFire)
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
            case Item.StickyVines:
                if (x == Obstacles.Hole)
                {
                    usable = true;
                }
                break;
            case Item.Key:
                if (x == Obstacles.Unicorn)
                {
                    usable = true;
                }
                break;
            case Item.Unicorn:
                winGame = true;
                usable = true;
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
        usable = UsableItem(item, other.gameObject);
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
            }
        }
        // If item in hand can interact with Obs
        else if (inventory.currentItem != Item.None && UsableItem(inventory.currentItem,other.gameObject))
        {
            usable = true;
            text.pickableText.SetActive(true); // Di
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Unable the pickables of objectives
        pickable = false; // If inside trigger
        usable = false;
        text.pickableText.SetActive(false); // Text disabled
        
        
    }
}
