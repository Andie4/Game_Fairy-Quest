using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CatchWingsMessageController : MonoBehaviour
{
    // trigger to detect the player on the floor
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("player finished gam");
            
            StartCoroutine(ChangeLevel());
        }
    }

    // time before change for the end panel
    IEnumerator ChangeLevel()
    {
        Debug.Log("waiting 2 seconds");
        yield return new WaitForSeconds(2f);

        Debug.Log(" load scene end game");
        SceneManager.LoadScene("EndGame");
    }
}
