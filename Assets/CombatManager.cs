using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    public CinemachineTargetGroup TargetGroup;
    private int CurrentRound = 1;
    public GameObject[] AvailibilityFighter;
    public Transform PlayerOneStartingPoint;
    public Transform PlayerTwoStartingPoint;
    private int CurrentPlayerSelecting = 1;
    private GameObject PlayerOneSelectingFighter;
    private GameObject PlayerTwoSelectingFighter;
    public GameObject MainMenuCanvas;
    public TextMeshProUGUI RoundText;
    public TextMeshProUGUI CurrentPlayerSelectingText;
    public Toggle[] PlayerOneRoundToggles;
    public Toggle[] PlayerTwoRoundToggles;
    private int PlayerOneToggleIndex;
    private int PlayerTwoToggleIndex;
    public TimerDetect RoundTime;
    public GameObject RespawnPoint;
    public GameObject WinnerPanel;
    private TextMeshProUGUI WinnerText;
    public void HandleSelectFighter(int FighterNumber) 
    {
        GameObject SelectedFighter = null;
       if (FighterNumber == 0)
        {
            SelectedFighter = AvailibilityFighter[0];
        }
       else if (FighterNumber == 1)
        {
             SelectedFighter = AvailibilityFighter[1];
        }
        else if (FighterNumber == 2)
        {
            SelectedFighter = AvailibilityFighter[2];
        }
        if(CurrentPlayerSelecting == 1)
        {
            PlayerOneSelectingFighter = SelectedFighter;
            PlayerOneSelectingFighter.SetActive(true);
            PlayerOneSelectingFighter.transform.position = PlayerOneStartingPoint.position;
            PlayerOneSelectingFighter.GetComponent<PlayerNumber>().AssignedPlayerNumber = CurrentPlayerSelecting;
            CurrentPlayerSelecting++;
            CurrentPlayerSelectingText.SetText("Player 2 Choose Fighter");
            TargetGroup.AddMember(PlayerOneSelectingFighter.transform, 1f, 0.5f);
        }
        else if(CurrentPlayerSelecting == 2)
        {
            PlayerTwoSelectingFighter = SelectedFighter;
            PlayerTwoSelectingFighter.SetActive(true);
            PlayerTwoSelectingFighter.transform.position = PlayerTwoStartingPoint.position;
            MainMenuCanvas.SetActive(false);
            RoundTime.ShouldRun = true;
            TargetGroup.AddMember(PlayerTwoSelectingFighter.transform, 1f, 0.5f);
            PlayerTwoSelectingFighter.GetComponent<PlayerNumber>().AssignedPlayerNumber = CurrentPlayerSelecting;
        }
    }
    
    public void RoundOver(GameObject Player)
    {
        int PlayerNumber = Player.GetComponent<PlayerNumber>().AssignedPlayerNumber;
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
        TargetGroup.m_Targets = new CinemachineTargetGroup.Target[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
