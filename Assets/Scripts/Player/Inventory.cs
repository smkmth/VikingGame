using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private Stats playerStats;
    public List<ItemSlot> itemSlots;
    public GameObject inventoryUI;
    public GameObject itemGrid;
    public Image[] itemImages;
    public TextMeshProUGUI[] itemText;
    public int MaxItemSlots;
    public int totalItemsStored;
    public Sprite emptySlot;

    public void Start()
    {
        itemImages = itemGrid.GetComponentsInChildren<Image>();
        itemText = itemGrid.GetComponentsInChildren<TextMeshProUGUI>();
        itemSlots = new List<ItemSlot>();
        playerStats = GetComponent<Stats>();
        totalItemsStored = 0;
        foreach(TextMeshProUGUI text in itemText)
        {
            text.text = "Empty";
        }
        
        for (int i = 0; i < MaxItemSlots; i++)
        {
            itemSlots.Add(new ItemSlot(null, 0, false));
        }
        DisplayInventory();
    }

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
                    playerStats.RestoreStamina(foodItem.staminaRestore);
                    RemoveItem(selectedItem);
                    break;
            }
        }
    }

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
                itemText[i].text = "Empty";
                itemImages[i].sprite = emptySlot;

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
            else
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
        //check we dont already have this item, if not, then add it, else increase the amount we have of it
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

//this class handles the item slot - wish it could be a struct, but quantity has to be mutable, so :(
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