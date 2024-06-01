using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EnemyWaveData")]
public class EnemyWaveData : ScriptableObject
{
    [SerializeField] GameObject EnemyPrefab;
    public GameObject enemyPrefab { get { return EnemyPrefab; } }

    [SerializeField] int Amount;
    public int amount { get { return Amount; } }

    [SerializeField] float Delay = 0;
    public float delay { get { return Delay; } }

}
