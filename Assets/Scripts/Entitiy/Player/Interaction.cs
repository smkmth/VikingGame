using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    public LayerMask EnemyLayerMask;
    public float AttackDistance;
    private Inventory inventory;
    public EquipmentHolder equipmentHolder;


    private void Start()
    {
        inventory = GetComponent<Inventory>();
        equipmentHolder = GetComponent<EquipmentHolder>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    void SetCursorState(CursorLockMode wantedMode)
    {
        Cursor.lockState = wantedMode;
        // Hide cursor when locking
        Cursor.visible = (CursorLockMode.Locked != wantedMode);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetCursorState(CursorLockMode.None);
        }
    

        if (Input.GetButtonDown("Inventory"))
        {
            inventory.ToggleInventoryMenu();
        }
        if (Input.GetButtonDown("Attack"))
        {
            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100.0f, Color.yellow);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    if (equipmentHolder.equipedWeapon != null)
                    {
                        hit.transform.gameObject.GetComponent<Stats>().DoDamage(equipmentHolder.equipedWeapon.attackDamage);

                        Debug.Log("ATTACK!");
                    }
                    else
                    {
                        Debug.Log("No Weapon Equiped");
                    }


                }
                else if (hit.transform.gameObject.tag == "NPC")
                {



                }
            }
        }
    }
}
