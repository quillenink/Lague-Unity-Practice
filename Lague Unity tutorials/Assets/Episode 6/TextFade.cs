using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFade : MonoBehaviour
{
    TMP_Text textToFade;
    Color color;
    float fadeAmount;

    public float fadeMultiplier = 1f;
    [SerializeField] bool hasFadedIn = false;

    private void Start()
    {
        textToFade = this.gameObject.GetComponent<TMP_Text>();
        color = textToFade.color;
        fadeAmount = 0f;
        hasFadedIn = false;
        SetColor();
    }

    private void Update()
    {
        if(fadeAmount < 1f && !hasFadedIn)
        {
            fadeAmount += Time.deltaTime * fadeMultiplier;
            if(fadeAmount > 1f)
            {
                fadeAmount = 1f;
            }
        }
        if(fadeAmount > 0f && hasFadedIn)
        {
            fadeAmount -= Time.deltaTime * fadeMultiplier;
            if(fadeAmount < 0f)
            {
                fadeAmount = 0f;
            }
        }
        SetColor();
    }

    void SetColor()
    {
        textToFade.color = new Color(color.r, color.g, color.b, fadeAmount);
        if(fadeAmount == 1f)
        {
            hasFadedIn = true;
        }
        if(fadeAmount == 0f)
        {
            hasFadedIn = false;
        }
    }

}
