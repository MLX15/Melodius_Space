using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UbhManager : UbhMonoBehaviour
{
    public const int BASE_SCREEN_WIDTH = 600;
    public const int BASE_SCREEN_HEIGHT = 450;
    public bool _ScaleToFit = false;
    [SerializeField]
    GameObject _PlayerPrefab;
    [SerializeField]
    GameObject _GoTitle;
    [SerializeField]
    GameObject _GoLetterBox;
    [SerializeField]
    UbhScore _Score;

    void Start ()
    {
        _GoLetterBox.SetActive(!_ScaleToFit);
    }

    void Update ()
    {
        
        if (UbhUtil.IsMobilePlatform()) {
            /*
            for (int i = 0; i < Input.touchCount; i++) {
                Touch touch = Input.GetTouch (i);

                if (IsPlaying () == false && touch.phase == TouchPhase.Began) {
                    GameStart ();
                }
            }
            */
            if (IsPlaying() == false && Input.GetMouseButtonDown(0)) {
                GameStart();
            }

        } else {
            if (IsPlaying() == false && Input.GetKeyDown(KeyCode.X)) {
                GameStart();
            }
        }
    }

    void GameStart ()
    {
        if (_Score != null) {
            _Score.Initialize();
        }
        if (_GoTitle != null) {
            _GoTitle.SetActive(false);
        }

        CreatePlayer();
    }

    public void GameOver ()
    {
        _GoLetterBox.SetActive(false);
        _GoTitle.SetActive(true);
        if (_Score = null) {
            // for UBH_ShotShowcase scene.
            CreatePlayer();
        }
    }

    void CreatePlayer ()
    {
        Instantiate(_PlayerPrefab, _PlayerPrefab.transform.position, _PlayerPrefab.transform.rotation);
    }

    public bool IsPlaying ()
    {
        if (_GoTitle != null) {
            return _GoTitle.activeSelf == false;
        } else {
            // for UBH_ShotShowcase scene.
            return true;
        }
    }
}
