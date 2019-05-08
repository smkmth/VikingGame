using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// here is the class which handles all inventory stuff. it should be player agnoistic
/// so npcs, chests, shops or whatever could use a similar / modifed version of this class
/// </summary>
public class Inventory : MonoBehaviour
{
    private Stats stats;
    private Interaction interaction;

    public List<ItemSlot> itemSlots;

    //set up in editor!
    public GameObject inventoryUI;
    public GameObject itemGrid;

    public int MaxItemSlots;
    public int totalItemsStored;

    //array of the images
    private Image[] itemImages;
    private TextMeshProUGUI[] itemText;

    //how we should display empty inventory slots 
    public Sprite emptySprite;
    public string emptyString;


    public void Start()
    {
        totalItemsStored = 0;
        itemSlots = new List<ItemSlot>();

        for (int i = 0; i < MaxItemSlots; i++)
        {
            itemSlots.Add(new ItemSlot(null, 0, false));
        }


        itemImages = itemGrid.GetComponentsInChildren<Image>();
        foreach (Image image in itemImages)
        {
            image.sprite = emptySprite;
        }
        itemText = itemGrid.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (TextMeshProUGUI text in itemText)
        {
            text.text = emptyString;
        }

        
        stats = GetComponent<Stats>();     
        interaction = GetComponent<Interaction>();     
        DisplayInventory();
        inventoryUI.SetActive(false);

    }

    //turn on and off inventory menu
    public void ToggleInventoryMenu()
    {
        
        if (inventoryUI.activeSelf == false)
        {
            inventoryUI.SetActive(true);
        }
        else
        {
            inventoryUI.SetActive(false);
        }

    }
    
    //gets called by the ui button on click method. FIXME later make this less dependent on editor
    public void SelectInventorySlot(string buttonIndex)
    {
        int selectedIndex = int.Parse(buttonIndex);
        if (itemSlots[selectedIndex].filled)
        {
            Debug.Log("you selected " + selectedIndex + " which corisponds to " + itemSlots[selectedIndex].item.name +
                " You have " + itemSlots[selectedIndex].quantity + " of this item ");

            Item selectedItem = itemSlots[selectedIndex].item;

            switch (selectedItem.type)
            {
                case ItemType.Food:
                    Food foodItem = (Food)selectedItem;
                    stats.RestoreStamina(foodItem.staminaRestore);
                    RemoveItem(selectedItem);
                    break;

                case ItemType.Weapon:
                    Weapon weaponItem = (Weapon)selectedItem;
                    interaction.equipedWeapon = weaponItem;

                    break;
            }
            
        }
    }
    
    //JUST update the visuals of the inventory- dont implement any inventory management stuff here please future danny
    public void DisplayInventory()
    {
       
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (itemSlots[i].filled)
            {
                itemImages[i].sprite = itemSlots[i].item.icon;
                itemText[i].text = itemSlots[i].item.title + "(" + itemSlots[i].quantity + ")";

            }
            else
            {
                itemText[i].text = emptyString;
                itemImages[i].sprite = emptySprite;

            }
        }
        
    }

    public void AddItem(Item itemToAdd)
    {
        //check we dont already have this item, if not, then add it, else increase the amount we have of it

        for (int i = 0; i < MaxItemSlots; ++i)
        {

            if (itemSlots[i].filled)
            {
                if (itemSlots[i].item.id == itemToAdd.id)
                {
                    itemSlots[i].quantity += 1;
                    totalItemsStored += 1;
                    DisplayInventory();
                    return;
                }

            }
        }
        for (int i = 0; i < MaxItemSlots; ++i)
        {


            if (!itemSlots[i].filled)
            {
                totalItemsStored += 1;
                itemSlots[i].item = itemToAdd;
                itemSlots[i].quantity += 1;
                itemSlots[i].filled = true;
                DisplayInventory();
                return;

            }

        }
     
        Debug.Log("Inventory full!");


    }

    public void RemoveItem(Item itemToRemove)
    {
        if (itemSlots.Count > 0)
        {
            for (int i = 0; i < itemSlots.Count; ++i)
            {
                if (itemSlots[i].item.id == itemToRemove.id)
                {
                    itemSlots[i].quantity -= 1;
                    totalItemsStored -= 1;

                    if (itemSlots[i].quantity <= 0)
                    {
                        itemSlots[i].filled = false;
                        itemSlots[i].item = null;
                     
                    }
                    DisplayInventory();
                    return;
                }
            }
        }
        


    }
}

//this class handles the item slot - wish it could be a struct, but quantity and filled have to be mutable, so :(
public class ItemSlot
{
    public Item item;
    public int quantity;
    public bool filled;

    public ItemSlot(Item item, int quantity, bool filled)
    {
        this.item = item;
        this.quantity = quantity;
        this.filled = filled;
    }
}