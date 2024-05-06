using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelName : MonoBehaviour
{
    private Text textField;

    void Start()
    {
        textField = GetComponent<Text>();
        Scene scene = SceneManager.GetActiveScene();
        textField.text = "" + SceneManager.GetActiveScene().name;
    }
}
