using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public float time; 
    public TextMeshProUGUI timerText;


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timerText.text = time.ToString("F1"); 
    }
}
