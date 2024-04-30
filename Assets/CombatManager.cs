using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public Image PlayerOnePowerUpImage;
    public Image PlayerTwoPowerUpImage;
    public static bool IsGameOver;
    public float FireAreaOffTime;
    public float FireAreaOnTime;
    private float CurrentFireAreaTimer;
    public GameObject FireArea;
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
            var characterAttack = PlayerOneSelectingFighter.GetComponent<CharacterAttack>();
            characterAttack.playerPowerUpImage = PlayerOnePowerUpImage; 
            CurrentPlayerSelecting++;
            RoundTime.Fighter1 = SelectedFighter;
            HitDetection[] hitDetections = SelectedFighter.GetComponentsInChildren<HitDetection>();
            foreach (HitDetection hitDetection in hitDetections)
            {
                hitDetection.PowerUpImage = PlayerOnePowerUpImage;
                hitDetection.ImageChangeAmount = 0.1f;
            }
            CurrentPlayerSelectingText.SetText("Player 2 Choose Fighter");
            TargetGroup.AddMember(PlayerOneSelectingFighter.transform, 1f, 0.5f);
        }
        else if(CurrentPlayerSelecting == 2)
        {
            PlayerTwoSelectingFighter = SelectedFighter;
            PlayerTwoSelectingFighter.SetActive(true);
            var characterAttack = PlayerTwoSelectingFighter.GetComponent<CharacterAttack>();
            characterAttack.playerPowerUpImage = PlayerTwoPowerUpImage;
            RoundTime.Fighter2 = SelectedFighter;
            PlayerTwoSelectingFighter.transform.position = PlayerTwoStartingPoint.position;
            HitDetection[] hitDetections = SelectedFighter.GetComponentsInChildren<HitDetection>();
            foreach (HitDetection hitDetection in hitDetections)
            {
                hitDetection.PowerUpImage = PlayerTwoPowerUpImage;
                hitDetection.ImageChangeAmount = 0.1f;
            }
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
                DisableFighters(1);
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
                DisableFighters(2);
            }
        }

        CurrentRound++;
        RoundText.SetText("Round " + CurrentRound);
        Player.transform.position = RespawnPoint.transform.position;
    }

    private void DisableFighters(int WinningPlayerNumber)
    {
        Vector3 TargetPosition = Camera.main.transform.position;
        if(WinningPlayerNumber == 1) 
        {
            TargetGroup.RemoveMember(PlayerTwoSelectingFighter.transform);
            PlayerTwoSelectingFighter.SetActive(false);
            Vector3 LookPosition = TargetPosition - PlayerOneSelectingFighter.transform.position;
            LookPosition.y = 0;
            Quaternion Rotation = Quaternion.LookRotation(LookPosition);
            PlayerOneSelectingFighter.transform.rotation = Rotation;
            PlayerOneSelectingFighter.GetComponent<AnimationManager>().VictoryEmote();
        }
        else
        {
            TargetGroup.RemoveMember(PlayerOneSelectingFighter.transform);
            PlayerOneSelectingFighter.SetActive(false);
            PlayerTwoSelectingFighter.GetComponent<AnimationManager>().VictoryEmote();
            Vector3 LookPosition = TargetPosition - PlayerTwoSelectingFighter.transform.position;
            LookPosition.y = 0;
            Quaternion Rotation = Quaternion.LookRotation(LookPosition);
            PlayerTwoSelectingFighter.transform.rotation = Rotation;
        }
        Destroy(FireArea);
        IsGameOver = true;
    }
    public void RestartScene()
    {
        IsGameOver = false;
        SceneManager.LoadScene(0);
    }
    // Start is called before the first frame update
    void Start()
    {
        WinnerText = WinnerPanel.GetComponentInChildren<TextMeshProUGUI>();  
        WinnerPanel.SetActive(false);
        TargetGroup.m_Targets = new CinemachineTargetGroup.Target[0];
        PlayerOnePowerUpImage.fillAmount = 0;
        PlayerTwoPowerUpImage.fillAmount = 0;
        CurrentFireAreaTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (MainMenuCanvas.activeSelf || IsGameOver)
        {
            return;
        }
        CurrentFireAreaTimer += Time.deltaTime;
        if (FireArea != null)
        {


            if (FireArea.activeSelf && CurrentFireAreaTimer >= FireAreaOnTime)
            {
                FireArea.SetActive(false);
                CurrentFireAreaTimer = 0;
            }
            if (!FireArea.activeSelf && CurrentFireAreaTimer >= FireAreaOffTime)
            {
                FireArea.SetActive(true);
                CurrentFireAreaTimer = 0;
            }
        }
    }

    internal void RoundTie()
    {
        PlayerOneSelectingFighter.transform.position = PlayerOneStartingPoint.position;
        PlayerTwoSelectingFighter.transform.position = PlayerTwoStartingPoint.position;
        PlayerOneSelectingFighter.GetComponent<HPManager>().FullMaxHP();
        PlayerTwoSelectingFighter.GetComponent<HPManager>().FullMaxHP();
    }
}
