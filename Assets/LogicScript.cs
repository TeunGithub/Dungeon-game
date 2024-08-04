using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    private int playerScore;
    [SerializeField] private Text scoretext;

    /// <summary>
    /// Adds score to GUI
    /// </summary>
    public void AddScore()
    {
        playerScore++;
        scoretext.text = $"Exp picked up: {playerScore.ToString()}";
    }

    /// <summary>
    /// Closes the application if escape is pressed
    /// </summary>
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
