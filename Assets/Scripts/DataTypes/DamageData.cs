using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DamageData
{
    public GameObject damageSource;
    public Team teamSource;
    public int amount;

    public DamageData (int Amount, GameObject DamageSource, Team TeamSource)
    {
        damageSource = DamageSource;
        teamSource = TeamSource;
        amount = Amount;
    }
}