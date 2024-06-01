using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemySpawner
{
    public Enemy SpawnEnemy(GameObject enemyPrefab);
}
