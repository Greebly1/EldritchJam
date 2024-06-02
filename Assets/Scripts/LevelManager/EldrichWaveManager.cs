using AYellowpaper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EldrichWaveManager : WaveManager
{


    public override void SpawnNextWave()
    {
        currentWave += 1;
        SpawnWave(currentWave);
    }
    public override void SpawnWave(int waveIndex)
    {
        foreach (InterfaceReference<IEnemyPath> enemypath in enemyPaths)
        {
            (enemypath as IWaveSpawner)?.SpawnWave(waveIndex, (enemypath as IEnemySpawner));
        }
    }
}
