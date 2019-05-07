using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    public LayerMask EnemyLayerMask;
    public float AttackDistance;
    private Inventory inventory;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
    }
    


    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Inventory"))
        {
            inventory.ToggleInventoryMenu();
        }
        if (Input.GetButtonDown("Attack"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, EnemyLayerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                if (hit.distance < AttackDistance)
                {
                    Debug.Log("ATTACK!");
                }
            }
        }
    }
}
