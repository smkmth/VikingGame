using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ContainerType
{
    Interact,
    Pickup
}
public class ItemContainer : MonoBehaviour
{

    public Item containedItem;
    public ContainerType containerType;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<Inventory>().AddItem(containedItem);
            Destroy(gameObject);
        }
    }
}
