using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public void PlayGame() // Start the game from the main the menu button
    {
        SceneManager.LoadScene("Game"); 
    }
    public void QuitGame() // Quit the game Button
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
