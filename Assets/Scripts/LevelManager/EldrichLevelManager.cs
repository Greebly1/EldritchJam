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
    [SerializeField] bool BeginImmediately = true;



    public void BeginGame()
    {
        GameStarted.Invoke();
        waveManagerInstance.SpawnWave(0);
        levelState = LevelState.OngoingWave;
    }

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

    #region monobehavior callbacks 
    private void Awake()
    {
        
    }

    private void Start()
    {
        GameManager.Instance.currentLevel = this;

        if (BeginImmediately)
        {
            BeginGame();
        }
    }


    #endregion
}
