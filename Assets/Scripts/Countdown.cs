using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI resultText;
    private float remainingTime = 120f;
    int totalCubes = 5;

    void Start()
    {
        resultText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (remainingTime > 0)
            remainingTime -= Time.deltaTime;
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            resultText.gameObject.SetActive(true);
            if (totalCubes <= 0)
                resultText.text = "Well done";
            else
                resultText.text = "Game Over";                

        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            Destroy(other.gameObject);
            totalCubes--;
        }
    }
}
