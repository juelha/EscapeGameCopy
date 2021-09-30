using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // load the main game scene
        SceneManager.LoadScene("Escape Room");
    }

    public void Quit()
    {
        Debug.Log("Quit.");
        Application.Quit();
    }
}
