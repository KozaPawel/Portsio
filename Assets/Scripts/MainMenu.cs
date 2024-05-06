using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Button[] lvlButtons;
    private void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 1);

        for(int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 1 > levelAt)
            {
                lvlButtons[i].interactable = false;
            }
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Lvl1()
    {
        SceneManager.LoadScene(1);
    }
    public void Lvl2()
    {
        SceneManager.LoadScene(2);
    }

    public void Lvl3()
    {
        SceneManager.LoadScene(3);
    }

    public void Lvl4()
    {
        SceneManager.LoadScene(4);
    }

    public void Lvl5()
    {
        SceneManager.LoadScene(5);
    }
}
