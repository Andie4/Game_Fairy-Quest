using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    public float time; 
    public TextMeshProUGUI timerText;

    void Start()
    {
        // result of the 2 levels
        time = PlayerPrefs.GetFloat("TotalTime", 0f);
    }
    
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timerText.text = time.ToString("F1");
    }

    void OnDestroy()
    {
        // save the timer before leave the scene 
        PlayerPrefs.SetFloat("TotalTime", time);
    }
}