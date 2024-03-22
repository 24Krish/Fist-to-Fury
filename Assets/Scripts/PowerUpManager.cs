using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public bool HasPowerUp;
    public float PowerUpDuration;
    private float CurrentPowerUpDuration;
    public void HandleCollectedPowerUp()
    {
        HasPowerUp = true;
        CurrentPowerUpDuration = PowerUpDuration;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HasPowerUp)
        {
            CurrentPowerUpDuration -= Time.deltaTime;
            if(CurrentPowerUpDuration <= 0 ) 
            {
                HasPowerUp = false;
            }
        }  
    }
}
