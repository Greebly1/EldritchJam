using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWaveSpawner
{
    public void SpawnWave(int waveNumber, IEnemySpawner spawner);
}
