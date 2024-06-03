using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// The most basic tower that fires a single projectile.
/// </summary>
public class WormShooter : Weapon
{
    [SerializeField]
    private GameObject wormProjectile;

    [SerializeField]
    [Min(1)]
    private int wormCount = 1;

    [SerializeField]
    [Min(0.1f)]
    private float attackRadius = 1;

    protected override async Awaitable AttackPattern()
    {
        if (IsEnemyInRange())
        {
            for(int i = 0; i < wormCount; i++)
            {
                WormProjectile projectile = Instantiate(wormProjectile, transform.position, Quaternion.AngleAxis(360 * i / wormCount, Vector3.forward)).GetComponent<WormProjectile>();
                projectile.transform.position += projectile.transform.up * 0.1f;
                projectile.Init(damage * attachedTower.DamageMultiplier, this, attackRadius * attachedTower.TargetRangeMultiplier);
            }
            await Awaitable.WaitForSecondsAsync(attachedTower.AttackSpeedMultiplier * attackSpeed);
        }
    }

    private bool IsEnemyInRange()
    {
        foreach(Enemy enemy in Enemy.AllActiveEnemies)
        {
            if(Vector2.Distance(enemy.transform.position, transform.position) < attackRadius * attachedTower.TargetRangeMultiplier)
            {
                return true;
            }
        }

        return false;
    }

    //Not used
    protected override ITargetable GetTarget()
    {
        return null;
    }
}
