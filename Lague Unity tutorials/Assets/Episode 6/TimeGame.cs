using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeGame : MonoBehaviour
{
    //keep the spacebar press
    //have the player press spacebar to start new round
    //countdown to number reveal

    float roundStartDelayTime = 3f;

    public Vector2 timeRange = new Vector2(3, 11);

    float roundStartTime;
    int waitTime;
    int min, max;
    bool roundStarted;

    void Start()
    {
        //print("Press the spacebar once you think the allotted time is up.");
        min = Mathf.CeilToInt(timeRange.x);
        max = Mathf.CeilToInt(timeRange.y);
        Invoke("SetNewRandomTime", roundStartDelayTime);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && roundStarted)
        {
            InputReceived();
        }
    }

    void InputReceived()
    {
        roundStarted = false;
        float playerWaitTime = Time.time - roundStartTime;
        //make this sensitive to "too soon" and too long
        float error = Mathf.Abs(waitTime - playerWaitTime);

        //tell the player in UI
        print("You waited for " + playerWaitTime + " seconds. That's " + error + " seconds off.");
        print(GenerateMessage(error));
        Invoke("SetNewRandomTime", roundStartDelayTime);
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
        //show the player in UI
        print(waitTime + " seconds.");
    }

}
