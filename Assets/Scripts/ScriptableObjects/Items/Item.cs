using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon, 
    Resource,
    KeyItem,
    Food
}
[CreateAssetMenu(fileName = "Item", menuName = "ItemData", order = 51)]
public class Item : ScriptableObject 
{
    public int id;
    public string title;
    public string description;
    public Sprite icon;
    public ItemType type;



}

