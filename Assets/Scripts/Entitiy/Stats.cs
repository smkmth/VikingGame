using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int Health;
    public float Stamina;
    public float StaminaDecayRate;
    public bool canLoseStamina;

    public effectType currentEffect;


    private void Update()
    {
        if (canLoseStamina)
        {
            if (Stamina > 0)
            {
                Stamina -= StaminaDecayRate * Time.deltaTime;

            }
          
        }

        switch (currentEffect) {
            case effectType.bleeding:

                break;

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

    public void DoDamage(int amount)
    {
        Health -= amount;
        if (Health <= 100)
        {
            Destroy(gameObject);
        }
     
    }

}
