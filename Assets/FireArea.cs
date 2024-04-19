using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArea : MonoBehaviour
{
    private float TimeBetweenDamage = 1f;
    private float CurrentTimeBetweenDamage = 0f;
    private void OnTriggerStay(Collider other)
    {
        var playerhealth = other.GetComponent<HPManager>();
        if (playerhealth != null)
        {
            CurrentTimeBetweenDamage += Time.deltaTime;
            if (CurrentTimeBetweenDamage >= TimeBetweenDamage)
            {
                CurrentTimeBetweenDamage = 0;
                playerhealth.TakeDamage(0.01f);
            }
        }
    }
}
