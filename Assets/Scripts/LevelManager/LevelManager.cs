using AYellowpaper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// public facing interface for the level manager concrete implementations
/// 
/// Concrete implementations:
///     EldrichLevelManager
///     TestLevelManager TODO
/// </summary>
public abstract class LevelManager : MonoBehaviour
{
    [SerializeField] WaveManager WaveManagerInstance;
    public WaveManager waveManagerInstance
    {
        get => WaveManagerInstance;
    }

    [SerializeField] StatWallet _GlobalStats;
    public StatWallet GlobalStatTracker
    {
        get => _GlobalStats;
    }


    LevelState _levelState = LevelState.Waiting;
    public LevelState levelState { get => _levelState; protected set { _levelState = value; } }

    public abstract void StartWaveDelay();
    public abstract void StartWaveImmediate();
    public float waveDelay = 10;
    [HideInInspector] public float timeUntilNextWave = 0; //the number of seconds until the next wave, this variable will countdown with time
}
