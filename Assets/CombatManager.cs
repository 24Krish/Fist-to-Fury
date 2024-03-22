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
    public TimerDetect RoundTime;
    public GameObject RespawnPoint;
    public GameObject WinnerPanel;
    private TextMeshProUGUI WinnerText;
    public void RoundOver(GameObject Player)
    {
        int PlayerNumber = Player.GetComponent<CharacterMovement>().PlayerNumber;
        Player.GetComponent<HPManager>().FullMaxHP();
        RoundTime.ResetRoundTime();
        if(PlayerNumber == 2)
        {
            PlayerOneRoundToggles[PlayerOneToggleIndex].isOn = true;
            PlayerOneToggleIndex++;
            if(PlayerOneToggleIndex >= 2)
            {
                WinnerPanel.SetActive(true);
                WinnerText.SetText("Player 1 Wins");
            }
        }

        else
        {
            PlayerTwoRoundToggles[PlayerTwoToggleIndex].isOn = true; 
            PlayerTwoToggleIndex++;
            if (PlayerTwoToggleIndex >= 2)
            {
                WinnerPanel.SetActive(true);
                WinnerText.SetText("Player 2 Wins");
            }
        }

        CurrentRound++;
        RoundText.SetText("Round " + CurrentRound);
        Player.transform.position = RespawnPoint.transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        WinnerText = WinnerPanel.GetComponentInChildren<TextMeshProUGUI>();  
        WinnerPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
