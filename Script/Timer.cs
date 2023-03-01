using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider timerSlider;
    public Text timerText;
    public float gameTime;
    public GameObject timeUpText;
    
    private bool stopTimer;

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    void Start()
    {
        stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        timeUpText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        float time = gameTime - Time.time;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60f);

        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        if (time <= 0)
        {
            stopTimer = true;
            timerSlider.interactable = false;
            timerText.gameObject.SetActive(false);
            timeUpText.SetActive(true);
            PauseGame();
        }
        if (stopTimer == false)
        {
            timerText.text = textTime;
            timerSlider.value = time;

        }
    }
}