using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelController : MonoBehaviour
{
    // trigger to detect the player on the floor
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("player finished level 1");
            
            StartCoroutine(ChangeLevel());
        }
    }

    // time before change the scnee for level 2
    IEnumerator ChangeLevel()
    {
        Debug.Log("waiting 2 seconds");
        yield return new WaitForSeconds(2f);

        Debug.Log(" load scene level 2");
        SceneManager.LoadScene("Level 2");
    }
}