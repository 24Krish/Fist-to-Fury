using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    public float StartingHealth;
    private float CurrentHealth;
    public Image PlayerOneHpImage;
    public Image PlayerTwoHpImage;
    private PlayerNumber playerNumber;
    private CharacterMovement Move;
    public CombatManager combatManager;
    public void FullMaxHP()
    {
        CurrentHealth = StartingHealth;
        if (playerNumber.AssignedPlayerNumber == 1)
        {
            PlayerOneHpImage.fillAmount = 1;
        }
        else
        {
            PlayerTwoHpImage.fillAmount = 1;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = StartingHealth;
        Move = GetComponent <CharacterMovement>();
        playerNumber = GetComponent<PlayerNumber>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float Damage)
    {
        StartCoroutine(DisableMovement());
        CurrentHealth -= Damage;
        if (playerNumber.AssignedPlayerNumber == 1)
        {
            PlayerOneHpImage.fillAmount = Mathf.Clamp01(CurrentHealth); 
        }
        else
        {
            PlayerTwoHpImage.fillAmount = Mathf.Clamp01(CurrentHealth);
        }
        if(CurrentHealth <= 0)
        {
            combatManager.RoundOver(gameObject);
        }
        
    }

    private IEnumerator DisableMovement()
    {
        Move.enabled = false;
        yield return new WaitForSeconds(0.1f);
        Move.enabled = true;
    }

    public void HandledSmallHealth()
    {
        CurrentHealth += 0.25f;
        CurrentHealth = Mathf.Clamp01(CurrentHealth);
        if (playerNumber.AssignedPlayerNumber == 1)
        {
            PlayerOneHpImage.fillAmount = CurrentHealth;
        }
        else
        {
            PlayerTwoHpImage.fillAmount = CurrentHealth;
        }
    }
}
