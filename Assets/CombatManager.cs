using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    private int CurrentRound = 1;
    public TextMeshProUGUI RoundText;
    public Toggle[] PlayerOneRoundToggles;
    public Toggle[] PlayerTwoRoundToggles;
    private int PlayerOneToggleIndex;
    private int PlayerTwoToggleIndex;
    public void RoundOver(int PlayerNumber)
    {
        if(PlayerNumber == 1)
        {
            PlayerOneRoundToggles[PlayerOneToggleIndex].isOn = true;
            PlayerOneToggleIndex++;
        }

        else
        {
            PlayerTwoRoundToggles[PlayerTwoToggleIndex].isOn = true; 
            PlayerTwoToggleIndex++;
        }

        CurrentRound++;
        RoundText.SetText("Round " + CurrentRound);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
