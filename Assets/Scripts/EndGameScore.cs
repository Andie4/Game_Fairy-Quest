using UnityEngine;
using TMPro;

public class EndGameScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float totalTime = PlayerPrefs.GetFloat("TotalTime", 0f);
        scoreText.text = totalTime.ToString("F1") + "s";
        
        // inisialize the timer at 0
        PlayerPrefs.SetFloat("TotalTime", 0f);
    }
}

