using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuButtons : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene("Level_1_Eden_Of_Denialv2",LoadSceneMode.Single);
    }

    public void QuitGame () {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void LoadLevels() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1,LoadSceneMode.Single);
    }

    public void Instructions() {
        SceneManager.LoadScene("instructions",LoadSceneMode.Single);
    }

     public void Back() {
        SceneManager.LoadScene("MainMenu",LoadSceneMode.Single);
    }
}
