using AYellowpaper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles spawning waves
/// </summary>
public abstract class WaveManager : MonoBehaviour
{
    int _currentWave = 0;
    public int currentWave
    {
        get { return _currentWave; }
        protected set { _currentWave = value; }
    }

    [SerializeField] protected List<InterfaceReference<IEnemyPath>> enemyPaths;

    public abstract void SpawnNextWave();
    public abstract void SpawnWave(int waveIndex);

    
}
