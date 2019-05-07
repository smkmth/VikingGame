using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int Health;
    public float Stamina;
    public float StaminaDecayRate;
    public bool canLoseStamina;


    private void Update()
    {
        if (canLoseStamina)
        {
            if (Stamina > 0)
            {
                Stamina -= StaminaDecayRate * Time.deltaTime;

            }
          
        }
    }

    public void RestoreStamina(float amount)
    {
        Stamina += amount;
        if (Stamina > 100)
        {
            Stamina = 100;
        }
    }

}
