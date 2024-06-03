using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// A tower with an AOE attack.
/// </summary>
public class Wizard : Weapon
{
    [SerializeField]
    private GameObject fireballProjectile;
    [SerializeField]
    private float fireballRadius;

    protected override async Awaitable AttackPattern()
    {
        if (Enemy.AllActiveEnemies.Count > 0)
        {
            WizardProjectile projectile = Instantiate(fireballProjectile, transform.position, Quaternion.LookRotation(Vector3.forward, GetTarget().GetPosition() - transform.position)).GetComponent<WizardProjectile>();
            projectile.Init(damage * attachedTower.DamageMultiplier, fireballRadius, this);
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
