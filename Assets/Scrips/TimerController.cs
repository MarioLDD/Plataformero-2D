using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    [SerializeField] private int min;
    [SerializeField] private int seg;
    [SerializeField] private int timeAlert;
    [SerializeField] private TMP_Text timeText;

    private float currentTime;
    private bool timeOn;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = (min * 60) + seg;
        timeOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeOn)
        {
            currentTime -= Time.deltaTime;
            if (currentTime < timeAlert)
            {
                timeText.color = Color.red;
            }
            if (currentTime < 1)
            {

                Debug.Log("Tiempo finalizado");
                timeOn = false;
                GameManager.gameOver = true;
            }
            int tempMin = Mathf.FloorToInt(currentTime / 60);
            int tempSeg = Mathf.FloorToInt(currentTime % 60);
            timeText.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);

        }
    }
}
