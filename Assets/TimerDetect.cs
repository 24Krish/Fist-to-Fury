using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerDetect : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    private float RoundTime = 150f;
    private float CurrentTime;
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
        CurrentTime -= Time.deltaTime;
        UpdateTimeDisplay();
    }
}
