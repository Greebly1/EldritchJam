using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName ="ScriptableObjects/Wave")]
public class enemyWave : ScriptableObject
{
    [SerializeField] List<HordeData> EnemyHordes;
    public List<HordeData> enemyHordes
    {
        get { return EnemyHordes; }
    }
}
