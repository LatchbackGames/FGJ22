using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public PickUpController character;
    private Item selectedItem;
    private Image img;
    public Dictionary<Item, Sprite> ItemList = new Dictionary<Item, Sprite>();

    public Sprite Bucket;
    public Sprite WaterBucket;
    public Sprite StepLadder;
    public Sprite Vines;
    public Sprite Knife;
    public Sprite PixieDust;
    public Sprite StickyVines;
    public Sprite Key;
    /*
     * None,
    Bucket,
    WaterBucket,
    StepLadder,
    Vines,
    Knife,
    PixieDust,
    StickyVines,
    Key
    */
    // Start is called before the first frame update
    void Start()
    {
        selectedItem = Item.None;
        img = GetComponent<Image>();
        img.enabled = false;
        ItemList.Add(Item.Bucket, Bucket);
        ItemList.Add(Item.WaterBucket, WaterBucket);
        ItemList.Add(Item.StepLadder, StepLadder);
        ItemList.Add(Item.Vines, Vines);
        ItemList.Add(Item.Knife, Knife);
        ItemList.Add(Item.PixieDust, PixieDust);
        ItemList.Add(Item.StickyVines, StickyVines);
        ItemList.Add(Item.Key, Key);
    }

    // Update is called once per frame
    void Update()
    {
        if (character.inventory.currentItem == selectedItem)
            return;
        if (selectedItem == Item.None)
            img.enabled = true;
        selectedItem = character.inventory.currentItem;
        if (selectedItem == Item.None)
            img.enabled = false;
        else
            img.sprite = ItemList[selectedItem];
    }
}
