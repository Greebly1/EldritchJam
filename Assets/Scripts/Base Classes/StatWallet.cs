using System.Collections;
using System.Collections.Generic;
using UltEvents;
using UnityEngine;

/// <summary>
/// Semi confusing name
/// This manages global stats, such as currency, health, insanity, etc.
/// it also publishes events for whenever those values change
/// </summary>
public abstract class StatWallet : MonoBehaviour, IDamageAble
{
    //-----Health-----
    public UltEvent<int> HealthChanged = new UltEvent<int>();
    public UltEvent PlayerDied = new UltEvent();
    int _health;
    public int health { get { return _health; } 
        protected set { 
            if (_health != value) //health changed
            {
                HealthChanged.Invoke(value);
                _health = value;
                if (_health <= 0)
                {
                    PlayerDied.Invoke();
                }
            }
        } 
    }
    public virtual int GetHealth()
    {
        return _health;
    }
    public virtual int Damage(DamageData damage)
    {
        DamagePlayer(damage);
        return health;
    }
    public abstract void DamagePlayer(DamageData damage);
    public abstract void HealPlayer(int amount);
    public int maxHealth = 10;


    //-----Insight-----
    public UltEvent<int> InsightChanged = new UltEvent<int>();
    int _insight;
    public int insight
    {
        get { return _insight; }
        set
        {
            if (_insight != value) //insight changed
            {
                InsightChanged.Invoke(value);
                _insanity = value;
            }
        }
    }
    public int maxInsight = 10;


    //-----Blood-----
    public UltEvent<int> BloodChanged = new UltEvent<int>();
    int _blood;
    public int blood
    {
        get { return _blood; }
        protected set
        {
            if (_blood != value) //blood changed
            {
                BloodChanged.Invoke(value);
                _blood = value;
            }
        }
    }
    public abstract void SpendBlood(int cost);
    public abstract void GainBlood(int amount);
    public int maxBlood = 100;


    //-----Insanity-----
    public UltEvent<float> InsanityChanged = new UltEvent<float>();
    float _insanity;
    public float insanity
    {
        get { return _insanity; }
        protected set
        {
            if (_insanity != value) //insanity changed
            {
                InsanityChanged.Invoke(value);
                _insanity = value;
            }
        }
    }
    public readonly float MAX_INSANITY = 100;


}
