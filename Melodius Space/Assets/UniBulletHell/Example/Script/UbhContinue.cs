using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UbhContinue : MonoBehaviour
{
    // Start is called before the first frame update
    public Text _DisplayScore;
    int _currentscore;
    UbhScore _Score;
    void Start ()
    {
        _Score = FindObjectOfType<UbhScore>();
    }

    void Update ()
    {
        _DisplayScore.text = "HighScore: " + _Score.Score;
    }
}
