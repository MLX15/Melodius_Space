using UnityEngine;
using System.Collections;

public class UbhEmitter : UbhMonoBehaviour
{
    [SerializeField]
    GameObject[] _Waves;
    int _CurrentWave;
    UbhManager _Manager;

    IEnumerator Start ()
    {
        if (_Waves.Length == 0) {
            yield break;
        }

        _Manager = FindObjectOfType<UbhManager>();

        while (true) {

            Debug.Log("Total waves:" + _Waves.Length);
            Debug.Log("Current wave:" + (_CurrentWave+1));
            Debug.Log(CurrentWave);

            while (_Manager.IsPlaying() == false) {
                yield return 0;
            }

            GameObject wave = (GameObject) Instantiate(_Waves[_CurrentWave], transform.position, Quaternion.identity);

            wave.transform.parent = transform;

            while (0 < wave.transform.childCount) {
                yield return 0;
            }

            Destroy(wave);

            if (_CurrentWave+1f == _Waves.Length) {
                break;
            }

            _CurrentWave = (int) Mathf.Repeat(_CurrentWave+1f, _Waves.Length);
        }
    }

    public int CurrentWave {
        get {return _CurrentWave+1;}
    }

    public int TotalWave {
        get {return _Waves.Length;}
    }
}