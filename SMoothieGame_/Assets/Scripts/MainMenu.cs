using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Load the game scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }
}