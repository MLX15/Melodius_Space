using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.UI;

public class EndingTest
{
    // Start is called before the first frame update
    [Test]
    public void EndingScreenTest() {
        UbhManager checkplaying;
        var obj = new GameObject();
        checkplaying = obj.AddComponent<UbhManager>();
        bool isplaying = checkplaying.IsPlaying();
        Debug.Log(isplaying);
        Assert.IsTrue(isplaying);
    }

    [Test]
    public void CurrentWaveTest() {
        UbhEmitter _Emitter;
        var obj = new GameObject();
        _Emitter = obj.AddComponent<UbhEmitter>();
        Assert.AreEqual(_Emitter.CurrentWave,1);
    }

    [Test]
    public void PauseMenuTest() {
        UbhManager checkplaying;
        PauseMenu checkpause;
        var obj = new GameObject();

        checkplaying = obj.AddComponent<UbhManager>();

        bool _gameispaused = PauseMenu.GameIsPaused;
        bool _isplaying = checkplaying.IsPlaying();
        Assert.AreNotEqual(_isplaying,_gameispaused);
    }

    [Test]
    public void LevelSelectionTest() {
        LevelSelection level;
        var obj = new GameObject();

        level = obj.AddComponent<LevelSelection>();

        Assert.AreEqual(0, level.GetLevelNumber(3));
    }

    [Test]
    public void SimpleBulletTest() {
        UbhSimpleBullet bullet;
        var obj = new GameObject();
        int damageOfABullet = 1;

        bullet = obj.AddComponent<UbhSimpleBullet>();
        Assert.AreEqual(damageOfABullet, bullet._Power);
    }

    [Test]
    public void FrameRateSettingTest() {
        UbhSetting setting;
        var obj = new GameObject();
        int defaultFrameRate = 60;

        setting = obj.AddComponent<UbhSetting>();
        Assert.AreEqual(defaultFrameRate, setting._FrameRate);
    }
    
}
