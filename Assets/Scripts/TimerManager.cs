using UnityEngine;
using TMPro;
using sceneManagement = UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour

{
    public float time; 
    public TextMeshProUGUI timerText;


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timerText.text = time.ToString("F1"); 

        // récupérer le temps du level 1 sur la deuxième scène 
        if (sceneManagement.SceneManager.GetActiveScene().name == "Level 2")
        {
            float timeLevel1 = PlayerPrefs.GetFloat("TimeLevel1", 0f);
            timerText.text = "Time Level 1: " + timeLevel1.ToString("F1") + "s";
        }
    }
}
