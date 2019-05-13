using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon, 
    Resource,
    KeyItem,
    Food,
    Equipment
}

public enum effectType
{
    nothing,
    poison,
    bleeding,
    instaKill,
    slowed
}

public enum equipmentSlotType
{
    Head,
    Legs,
    Torso,
    Arms,
    Weapon
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


[CreateAssetMenu(fileName = "Food", menuName = "FoodData", order = 52)]
public class Food : Item
{
    public int healthRestore;
    public float staminaRestore;

}

[CreateAssetMenu(fileName = "Equipment", menuName = "Equipment", order = 52)]
public class Equipment : Item
{
    public Mesh mesh;
    public equipmentSlotType equipmentSlot;
}

[CreateAssetMenu(fileName = "Weapon", menuName = "WeaponData", order = 52)]
public class Weapon : Equipment
{
    public int attackDamage;
    public SpecialEffect[] effect;
}


[CreateAssetMenu(fileName = "SpEffect", menuName = "SpEffect", order = 52)]
public class SpecialEffect : ScriptableObject
{

    public effectType thisEffectType;
    public int value;
}



