using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //==================Inspector Fields==================
    #region Inspector Fields
    [SerializeField]
    [Tooltip("All weapons attached to this tower.")]
    private List<Weapon> weapons;

    [Header("Tower Data")]
    [SerializeField]
    [Tooltip("The amount of currency the player gets by selling a placed tower.")]
    private int sellValue;
    [SerializeField]
    [Tooltip("The amount of currency the player loses by placing a tower.")]
    public int placeCost;

    [Header("Weapon Data")]
    [SerializeField]
    [Tooltip("A damage multiplier that applies to all weapons on this tower.")]
    private float damageMultiplier = 1.0f;
    [SerializeField]
    [Tooltip("An attack speed multiplier that applies to all weapons on this tower.")]
    private float attackSpeedMultiplier = 1.0f;
    [SerializeField]
    [Tooltip("A range multiplier that applies to all weapons' targeting on this tower.")]
    private float rangeMultiplier = 1.0f;
    #endregion Inspector Fields

    //==================Weapon Modifiers==================
    // Values to buff or debuff towers.
    #region WeaponModifiers
    /// <summary>
    /// Multiplies the damage done by this tower.
    /// </summary>
    public float DamageMultiplier
    {
        get
        {
            return Mathf.Max(damageMultiplier, 0);
        }
        set
        {
            damageMultiplier = Mathf.Max(damageMultiplier + value, 0);
        }
    }

    /// <summary>
    /// Multiplies how fast the tower attacks.
    /// </summary>
    public float AttackSpeedMultiplier
    {
        get
        {
            return Mathf.Max(attackSpeedMultiplier, 0);
        }
        set
        {
            attackSpeedMultiplier = Mathf.Max(attackSpeedMultiplier + value, 0);
        }
    }

    /// <summary>
    /// Multiplies the targeting range of the tower.
    /// </summary>
    public float TargetRangeMultiplier
    {
        get
        {
            return Mathf.Max(rangeMultiplier, 0);
        }
        set
        {
            rangeMultiplier = Mathf.Max(rangeMultiplier + value, 0);
        }
    }
    #endregion WeaponModifiers

    private void Awake()
    {
        foreach(Weapon weapon in weapons)
        {
            weapon.Init(this);
            weapon.StartAttackLoop();
        }
    }
}
