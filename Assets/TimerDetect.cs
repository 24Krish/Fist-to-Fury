using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerDetect : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    private float RoundTime = 15f;
    private float CurrentTime;
    public bool ShouldRun = false;
    public CombatManager CombatManager;
    public GameObject Fighter1;
    public GameObject Fighter2;
    public void ResetRoundTime() 
    { 
        CurrentTime = RoundTime + 1;
    }
    private void UpdateTimeDisplay()
    {
        CurrentTime = Mathf.Max(0, CurrentTime);
        int minutes = Mathf.FloorToInt(CurrentTime / 60);
        int seconds = Mathf.FloorToInt(CurrentTime % 60);
        TimerText.SetText(string.Format("{0:00}:{1:00}", minutes, seconds));
        if(CurrentTime <= 0)
        {
            var Fighter1HpManager = Fighter1.GetComponent<HPManager>();
            var Fighter2HpManager = Fighter2.GetComponent<HPManager>();
            if(Mathf.Abs(Fighter1HpManager.GetCurrentHealth - Fighter2HpManager.GetCurrentHealth) < Mathf.Epsilon)
            {
                CombatManager.RoundTie();
            }
            else if(Fighter1HpManager.GetCurrentHealth > Fighter2HpManager.GetCurrentHealth)
            {
                CombatManager.RoundOver(Fighter2);
            }
            else if (Fighter2HpManager.GetCurrentHealth > Fighter1HpManager.GetCurrentHealth)
            {
                CombatManager.RoundOver(Fighter1);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = RoundTime;
        UpdateTimeDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (CombatManager.IsGameOver)
        {
            return;
        }
        if (ShouldRun)
        {
            CurrentTime -= Time.deltaTime;
            UpdateTimeDisplay();
        }
    }
}
