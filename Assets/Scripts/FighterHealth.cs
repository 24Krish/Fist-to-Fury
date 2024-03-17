using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterHealth : MonoBehaviour
{
    public float StartingHealth;
    private float CurrentHealth;
    public Image HPImage;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = StartingHealth;     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage (float Damage) 
    {
        CurrentHealth -= Damage;   
    }
}
