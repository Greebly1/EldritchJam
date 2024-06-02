using AYellowpaper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class EnemyPath : MonoBehaviour, IEnemyPath, IEnemySpawner, IWaveSpawner
{
    [SerializeField] List<enemyWave> waves = new List<enemyWave>();
    [SerializeField] enemyWave emptyWave; //used for default behavior
    [SerializeField] SplineContainer path;

    #region private data
    private float pathLength = 0;
    #endregion

    private void Awake()
    {
        pathLength = path.Spline.GetLength(); //cache the path length
        SpawnWave(0, this);
    }

    #region IEnemyPath
    public Vector2 GetPosition(float distanceAlongPath)
    {
        Unity.Mathematics.float3 resultPosition = Vector3.zero;
        Unity.Mathematics.float3 resultTangent = Vector3.zero;
        Unity.Mathematics.float3 resultUp = Vector3.zero;
        path.Spline.Evaluate(distanceAlongPath, out resultPosition, out resultTangent, out resultUp);
        return new Vector2(resultPosition.x, resultPosition.y);
    }

    public float GetLength()
    {
        return pathLength;
    }
    #endregion

    #region IEnemySpawner
    //Spawns an enemy at the start of the path
    public Enemy SpawnEnemy(GameObject enemyPrefab)
    {
        Vector2 position2D = GetPosition(0);
        GameObject enemy = Instantiate(enemyPrefab, new Vector3(position2D.x, position2D.y, 0), Quaternion.identity);
        PathMover movementComponent = enemy.GetComponentInChildren<PathMover>();
        movementComponent.path = this;

        Enemy enemyComponent = enemy.GetComponentInChildren<Enemy>();
        if (enemyComponent != null) { enemyComponent.enemyPath = this; }
        return enemyComponent;
    }
    #endregion

    #region IWaveSpawner 
    public void SpawnWave(int waveNumber, IEnemySpawner spawner)
    {
        enemyWave chosenWave;
        if (waves.Count-1 < waveNumber || waveNumber < 0) //if the passed wave number is out of bounds of the list
        {
            chosenWave = emptyWave;//default behavior
        } else
        {
            chosenWave = waves[waveNumber];
        }
        StartCoroutine(SpawnWaveCoroutine(chosenWave, spawner));
    }

    IEnumerator SpawnWaveCoroutine(enemyWave WaveToSpawn, IEnemySpawner spawner)
    {
        foreach (HordeData horde in WaveToSpawn.enemyHordes) //for each enemy horde
        {
            //First wait out this horde's delay
            float timeUntilSpawn = horde.delay;
            while (timeUntilSpawn > 0) {
                yield return null; 
                timeUntilSpawn -= Time.deltaTime;
            }
            //Past this point the delay for this horde is over

            for (int amountSpawned = 0; amountSpawned < horde.amount; amountSpawned++) //for each enemy in this horde
            {
                spawner.SpawnEnemy(horde.enemyPrefab);
                yield return null;// this is a stupid way of saying, spawn an enemy then wait two frames
                yield return null;
            }
        }
    }

    
    #endregion
}
