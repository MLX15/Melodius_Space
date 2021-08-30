using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingScreen : MonoBehaviour
{
    public GameObject continueText;
    GameObject _boss;
    UbhEmitter _Emitter;
    UbhEnemy _Enemy;
    UbhScore _Score;
    UbhManager _Manager;
    UbhSpaceship _Spaceship;
    LevelSelection _Selection;
    int currentWave;
    int totalWave;
    int level;
    float bossHp;
    // Start is called before the first frame update
    void Start()
    {
        continueText.SetActive(false);
        _Emitter = FindObjectOfType<UbhEmitter>();
        _Selection = FindObjectOfType<LevelSelection>();
        _Score = FindObjectOfType<UbhScore>();
        _Enemy = FindObjectOfType<UbhEnemy>();
        //this checks for current level
        if (SceneManager.GetActiveScene().name == "Level_2_Sea_Of_Rage") {
            level = 2;
        } else if (SceneManager.GetActiveScene().name == "Level_1_Eden_of_Denialv2") {
            level = 1;
        }
        Debug.Log("Level:" + level);
    }

    // Update is called once per frame
    void Update()
    {
        currentWave = _Emitter.CurrentWave;
        totalWave = _Emitter.TotalWave;
        _Manager = FindObjectOfType<UbhManager>();
        // this checks if boss is dead at boss stage
        if(currentWave == totalWave) {
            _boss = GameObject.FindGameObjectWithTag("Boss");
            if (_boss == null) {
                if (_Manager.IsPlaying() == true) {
                continueText.SetActive(true); //remove this from here later
                Debug.Log("End game");
                // use this part to load the cutscene. add in the continuetext to the new scene.
                if (level == 1) {
                } else if (level == 2) {
                 }
                if (Input.GetKeyDown(KeyCode.C)) {
                    SceneManager.LoadScene("MainMenu",LoadSceneMode.Single);
                    }
            } else {
                continueText.SetActive(false);
            }
            }
        }
        
    }
}
