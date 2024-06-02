using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is empty right now, to be created
/// Dependents:
/// IEnemySpawner, EnemyManager, probably more
/// </summary>
public class Enemy : MonoBehaviour, ITargetable, IDamageAble //should probably implement IDamagable, and ITargetable
{
    public static List<Enemy> AllActiveEnemies { get; protected set; } = new List<Enemy>();

    [SerializeField]
    [Tooltip("The starting health of this enemy.")]
    [Min(1)]
    private int startHealth;

    private int currentHealth;

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    private void Awake()
    {
        AllActiveEnemies.Add(this);
        currentHealth = startHealth;
    }

    private void OnDestroy()
    {
        AllActiveEnemies.Remove(this);
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public int Damage(DamageData damage)
    {
        if(damage.teamSource == Team.Player)
        {
            currentHealth -= damage.amount;
            if(currentHealth < 0)
            {
                Die();
            }
        }

        return currentHealth;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public IEnemyPath enemyPath;
}
