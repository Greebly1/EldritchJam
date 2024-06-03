using AYellowpaper;
using System.Collections;
using System.Collections.Generic;
using UltEvents;
using UnityEngine;

/// <summary>
/// This is the singleton, for the map/level
/// 
/// Contains level logic and api for interacting with the entire level
/// </summary>
public class EldrichLevelManager : LevelManager
{
    IEnumerator WaveDelayTimer()
    {
        timeUntilNextWave = waveDelay;
        while (timeUntilNextWave > 0)
        {
            timeUntilNextWave -= Time.deltaTime;
            yield return null;
        }

        StartWaveImmediate();
    }

    public override void StartWaveDelay()
    {
        levelState = LevelState.Waiting;
        StartCoroutine("WaveDelayTimer");
    }

    public override void StartWaveImmediate()
    {
        levelState = LevelState.OngoingWave;
        waveManagerInstance.SpawnNextWave();
    }

    private void Start()
    {
        GameManager.Instance.currentLevel = this;
    }

    private void OnEnable()
    {
        GameManager.Instance.currentLevel = this;

        BeginGame();
    }
}
