using UnityEngine;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour
{
    private GameObject[] gameObjects;
   [SerializeField] private List<GameObject> Platform;

   public float timer = 0f;



    void Start()
    {
        //    Debug.Log(Platform);
        
    }

    void Update()
    {
        timer += Time.deltaTime;


        if (timer < 5f)
        {
            desapear();
            // Debug.Log(timer);
        }
         else if (timer >= 5f)
        {

            appear();
            // Debug.Log(timer);

        }
         if (timer >= 10f)
        {
            resetTimer();
        }
    }

    private void desapear()
    {
        foreach (GameObject platform in Platform)
        {
            platform.SetActive(false); 
            // Debug.Log(GameObject);

        }
    }

    private void appear()
    {
        foreach (GameObject platform in Platform)
        {
            platform.SetActive(true); 
        }
    }

    private void resetTimer()
    {
        timer = 0f;
    }
}