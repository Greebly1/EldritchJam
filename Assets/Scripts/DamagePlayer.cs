using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int amountOfDamage = 1;
    public int insanityDamage = 1;

    public void DealDamage()
    {
        //deal damage to the player then destroy this enemy
        GameManager.Instance.currentLevel.GlobalStatTracker.Damage(new DamageData(amountOfDamage, this.gameObject, Team.Enemy));
        GameManager.Instance.currentLevel.GlobalStatTracker.insanity += insanityDamage;

        Destroy(this.gameObject);
    }
}
