using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeGame : MonoBehaviour
{

    //some juicy animations for press start and result?

    public TMP_Text numberToGuess, timeWaitedText, amountOffText, spaceToStartText, resultText;
    public GameObject countdownLine;
    public float roundStartDelayTime = 3f, maxScale = 30f;
    public Vector2 timeRange = new Vector2(3, 11);

    float roundStartTime, delayCountdown, scaleIncrement, xScale = 1f;
    int waitTime;
    int min, max;
    bool roundStarted, roundStartDelay;

    void Start()
    {
        min = Mathf.CeilToInt(timeRange.x);
        max = Mathf.CeilToInt(timeRange.y);
        numberToGuess.text = "";
        timeWaitedText.text = "";
        amountOffText.text = "";
        resultText.text = "";
        delayCountdown = roundStartDelayTime;
        scaleIncrement = maxScale / roundStartDelayTime;
    }

    void Update()
    {
        if (roundStartDelay)
        {
            if(delayCountdown <= 0f)
            {
                SetNewRandomTime();
                xScale = 1f;
                roundStartDelay = false;
                delayCountdown = roundStartDelayTime;
            }
            delayCountdown -= Time.deltaTime;
            xScale += scaleIncrement * Time.deltaTime;
            countdownLine.GetComponent<RectTransform>().localScale = new Vector3(xScale, 1f, 1f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !roundStartDelay)
        {
            if (roundStarted)
            {
                InputReceived();
                return;
            }
            if (!roundStarted)
            {
                roundStartDelay = true;
                timeWaitedText.text = "";
                amountOffText.text = "";
                resultText.text = "";
                spaceToStartText.text = "";
                countdownLine.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                countdownLine.SetActive(true);
            }
        }
    }

    void InputReceived()
    {
        roundStarted = false;
        float playerWaitTime = Time.time - roundStartTime;
        float error = Mathf.Abs(waitTime - playerWaitTime);

        timeWaitedText.text = "Waited for " + playerWaitTime + " seconds.";
        amountOffText.text = error + " seconds off.";
        resultText.text = GenerateMessage(error);
        numberToGuess.text = "";
        spaceToStartText.text = "Press the spacebar to start.";
    }

    string GenerateMessage(float error)
    {
        string message = "";
        if (error < .15f)
        {
            message = "Outstanding!";
        }
        else if (error < 1.1f)
        {
            message = "Good job!";
        }
        else if (error < 2f)
        {
            message = "Not bad.";
        }
        else
        {
            message = "That's a miss...";
        }
        return message;
    }

    void SetNewRandomTime()
    {
        countdownLine.SetActive(false);
        waitTime = Random.Range(min, max);
        roundStartTime = Time.time;
        roundStarted = true;
        numberToGuess.text = "" + waitTime;
    }

}
