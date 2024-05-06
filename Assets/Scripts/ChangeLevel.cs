using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    int nextScene;

    void OnTriggerEnter2D(Collider2D collider)
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (collider.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextScene);

            if (nextScene > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextScene);
            }
        }
    }
}
