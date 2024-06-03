using System.Collections;
using System.Collections.Generic;
using UltEvents;
using UnityEngine;

/// <summary>
/// Semi confusing name
/// This manages global stats, such as currency (blood), health, insanity, etc.
/// it also publishes events for whenever those values change
/// </summary>
public class StatWallet : MonoBehaviour, IDamageAble
{
    //-----Health-----
    public UltEvent<int> HealthChanged = new UltEvent<int>();
    public UltEvent PlayerDied = new UltEvent();
    int _health;
    public int health { get { return _health; } 
        protected set { 
            int newval = Mathf.Clamp(value, -1, maxHealth); //negative minimum value in case people use health < 0
            if (_health != newval) //health changed
            {
                HealthChanged.Invoke(newval);
                _health = newval;
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
    public virtual void DamagePlayer(DamageData damage) { Debug.Log("base class does not implement DamagePlayer, use a concrete implementation"); }
    public virtual void HealPlayer(int amount) { Debug.Log("base class does not implement HealPlayer, use a concrete implementation"); }
    public int maxHealth = 10;


    //-----Insight-----
    public UltEvent<int> InsightChanged = new UltEvent<int>();
    int _insight;
    public int insight
    {
        get { return _insight; }
        set
        {
            int newval = Mathf.Clamp(value, 0, maxInsight);
            if (_insight != newval) //insight changed
            {
                InsightChanged.Invoke(newval);
                _insanity = newval;
            }
        }
    }
    public int maxInsight = 10;


    //-----Blood-----
    //before ever altering the blood value, please ensure that the player has enough blood first
    public UltEvent<int> BloodChanged = new UltEvent<int>();
    int _blood;
    public int blood
    {
        get { return _blood; }
        protected set
        {
            int newval = Mathf.Clamp(value, 0, maxBlood);
            if (_blood != newval) //blood changed
            {
                BloodChanged.Invoke(newval);
                _blood = newval;
            }
        }
    }
    public virtual void SpendBlood(int cost) { Debug.Log("base class does not implement SpendBlood, use a concrete implementation"); }
    public virtual void GainBlood(int amount) { Debug.Log("base class does not implement GainBlood, use a concrete implementation"); }
    public int maxBlood = 100;


    //-----Insanity-----
    public UltEvent<float> InsanityChanged = new UltEvent<float>();
    float _insanity;
    public float insanity
    {
        get { return _insanity; }
        set
        {
            float newval = Mathf.Clamp(value, 0, MAX_INSANITY);
            if (_insanity != newval) //insanity changed
            {
                InsanityChanged.Invoke(newval);
                _insanity = newval;
            }
        }
    }
    public readonly float MAX_INSANITY = 100;


    #region shorthand getters 
    public bool atMaxHealth
    {
        get { return health >= maxHealth; }
    }

    #endregion
}
