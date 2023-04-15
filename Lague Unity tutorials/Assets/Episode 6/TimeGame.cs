using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeGame : MonoBehaviour
{
    //countdown to number reveal
    //some juicy animations for press start and result?

    public TMP_Text numberToGuess, timeWaitedText, amountOffText, spaceToStartText, resultText;
    public float roundStartDelayTime = 3f;
    public Vector2 timeRange = new Vector2(3, 11);

    float roundStartTime;
    int waitTime;
    int min, max;
    bool roundStarted;

    void Start()
    {
        min = Mathf.CeilToInt(timeRange.x);
        max = Mathf.CeilToInt(timeRange.y);
        numberToGuess.text = "";
        timeWaitedText.text = "";
        amountOffText.text = "";
        resultText.text = "";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (roundStarted)
            {
                InputReceived();
                return;
            }
            if (!roundStarted)
            {
                Invoke("SetNewRandomTime", roundStartDelayTime);
            }
        }
    }

    void InputReceived()
    {
        roundStarted = false;
        float playerWaitTime = Time.time - roundStartTime;
        //make this sensitive to "too soon" and too long
        float error = Mathf.Abs(waitTime - playerWaitTime);

        timeWaitedText.text = "Waited for " + playerWaitTime + " seconds.";
        amountOffText.text = error + " seconds off.";
        resultText.text = GenerateMessage(error);
        print(GenerateMessage(error));
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
        waitTime = Random.Range(min, max);
        roundStartTime = Time.time;
        roundStarted = true;
        numberToGuess.text = "" + waitTime;
        timeWaitedText.text = "";
        amountOffText.text = "";
        spaceToStartText.text = "";
        resultText.text = "";
    }

}
