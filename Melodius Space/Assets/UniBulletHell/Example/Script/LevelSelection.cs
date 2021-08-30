using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    int levelNumber;
    // Start is called before the first frame update
    public void LoadLevelOne() {
        levelNumber = 1;
        SceneManager.LoadScene("Level_1_Eden_Of_Denialv2",LoadSceneMode.Single);
    }

    public void LoadLevelTwo() {
        levelNumber = 2;
        SceneManager.LoadScene("Level_2_Sea_Of_Rage",LoadSceneMode.Single);
    }

    public void LoadLevelThree() {
        levelNumber = 3;
        SceneManager.LoadScene("Level_3_Factory_Of_Despair",LoadSceneMode.Single);
    }

    public void BackToMainMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1,LoadSceneMode.Single);
    }

    public int GetLevelNumber(int levelnumber) {
        levelnumber = levelNumber;
        return levelNumber;
    }
}
