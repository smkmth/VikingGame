using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Food", menuName = "FoodData", order = 52)]
public class Food : Item
{
    public int healthRestore;
    public float staminaRestore;

}



[CreateAssetMenu(fileName = "Weapon", menuName = "WeaponData", order = 52)]
public class Weapon : Item
{
    public int attackDamage;
    public Mesh whatItLooksLike;
    public SpecialEffect[] effect;
}


public enum effectType
{
    poison,
    bleeding,
    instaKill,
    butts
}
[CreateAssetMenu(fileName = "Weapon", menuName = "SpEffect", order = 52)]
public class SpecialEffect : ScriptableObject
{
    
    public effectType thisEffectType;
    public int value;
}