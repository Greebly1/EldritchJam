using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// The most basic tower that fires a single projectile.
/// </summary>
public class Worshipper : Weapon
{
    protected override async Awaitable AttackPattern()
    {
        
    }

    protected override ITargetable GetTarget()
    {
        return null;
    }
}
