using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is empty right now, to be created
/// Dependents:
/// IEnemySpawner, EnemyManager, probably more
/// </summary>
public class Enemy : MonoBehaviour, ITargetable //should probably implement IDamagable, and ITargetable
{
    public static List<Enemy> AllActiveEnemies { get; private set; } = new List<Enemy>();

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    private void Awake()
    {
        AllActiveEnemies.Add(this);
    }

    private void OnDestroy()
    {
        AllActiveEnemies.Remove(this);
    }
}
