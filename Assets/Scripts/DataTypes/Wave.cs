using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName ="ScriptableObjects/Wave")]
public class Wave : ScriptableObject
{
    [SerializeField] List<EnemyWaveData> EnemyHordes;
    public List<EnemyWaveData> enemyHordes
    {
        get { return EnemyHordes; }
    }
}
