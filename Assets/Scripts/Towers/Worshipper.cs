using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// The most basic tower that fires a single projectile.
/// </summary>
public class Worshipper : Weapon
{
    [SerializeField]
    private GameObject worshipperProjectile;

    protected override async Awaitable AttackPattern()
    {
        if (Enemy.AllActiveEnemies.Count > 0)
        {
            CultistProjectile projectile = Instantiate(worshipperProjectile, transform.position, Quaternion.LookRotation(Vector3.forward, GetTarget().GetPosition() - transform.position)).GetComponent<CultistProjectile>();
            projectile.Init(damage * attachedTower.DamageMultiplier, this);
            await Awaitable.WaitForSecondsAsync(attachedTower.AttackSpeedMultiplier * attackSpeed);
        }
    }

    protected override ITargetable GetTarget()
    {
        return Enemy.AllActiveEnemies[0];

        foreach (Enemy enemy in Enemy.AllActiveEnemies)
        {

        }
    }
}
