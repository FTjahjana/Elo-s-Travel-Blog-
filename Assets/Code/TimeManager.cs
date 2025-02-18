using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    private static TimeManager _instance;
    public static TimeManager Instance => _instance;
    public TextMeshProUGUI dayDisplay;

    private int currentDay = 0;
    private int currentTime = 6;

    void Awake()
        {  if (_instance != null && _instance != this)
            { Destroy(gameObject);  // Destroy any duplicates to make sure this is the only TimeManager
                return; }
            _instance = this;  }

    public void SetTime(int time)  {  currentTime = time;  }

    public void AddTime(int time)
    {
        currentTime += time;

        while (currentTime >= 24) 
        {  currentTime -= 24;
            currentDay++;   }

        UpdateTimeDisplay();
    }


    public int GetTime() { return currentTime; }
    public int GetDay() { return currentDay; }
  
    private void UpdateTimeDisplay()
    {   string dayOrNight = currentTime >= 6 && currentTime < 18 ? "Day" : "Night";
        dayDisplay.text = $"{dayOrNight} {currentDay}";   }

    public void endDay()
    {   currentDay++; currentTime =0; UpdateTimeDisplay();}
}
