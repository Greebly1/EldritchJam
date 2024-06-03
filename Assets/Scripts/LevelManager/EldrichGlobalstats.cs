using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// concrete implementation of the Statwallet frontend
/// 
/// when this is what your backend looks like you have overengineered your system
/// </summary>
public class EldrichGlobalStats : StatWallet
{
    public float healthRegenSpeed = 2; //how many seconds it takes to regenerate 1 health, base value 2 -> 1hp/2seconds
    public float healthRegenDelay = 5; //how many seconds it takes to automatically begin health regen
    [SerializeField] bool _healthRegenEnabled = true;
    public bool healthRegenEnabled
    {
        get { return _healthRegenEnabled; }
        set { _healthRegenEnabled = value; 
            if (healthRegenEnabled) tryStartHealthRegen();
        }
    }

    public float insanityRegen = 0.1f; //how much insanity to regain per second
    [SerializeField] bool _insanityRegenEnabled = true;
    public bool insanityRegenEnabled
    {
        get { return _insanityRegenEnabled; }
        set { _insanityRegenEnabled = value;
            if (_insanityRegenEnabled) tryStartInsanityRegen();
        }
    }

    #region private data
    //used to ensure only one coroutine of each type can run at a time, also used to know when a coroutine is not running to check if we can start one
    bool regeneratingHealthCoroutineRunning = false;
    bool regeneratingInsanityCoroutineRunning = false;
    bool hasDied = false;
    #endregion

    #region Statwallet frontend
    public override void DamagePlayer(DamageData damage)
    {
        if (hasDied) { return; } //early out
        health -= damage.amount;
        tryStartHealthRegen(); //assuming the player lost health, we need to try to start regenerating health
    }

    public override void GainBlood(int amount)
    {
        blood += amount;
    }

    public override void HealPlayer(int amount)
    {
        if (hasDied) { return; } //early out
        health += amount;
        Debug.Log("healed " + amount);
    }

    public override void SpendBlood(int cost)
    {
        blood -= cost;
    }

    public void DamageDirect(int damage)
    {
        DamagePlayer(new DamageData(damage, this.gameObject, Team.None));
    }
    #endregion


    #region coroutines
    //checks if it is already regenerating health, if not then it starts regenerating health
    public void tryStartHealthRegen()
    {
        if (hasDied) { return; } //early out
        if (healthRegenEnabled && !regeneratingHealthCoroutineRunning)
        {
            StartCoroutine("C_HealthRegen");
        }
    }

    public void tryStartInsanityRegen()
    {
        if (hasDied) { return; } //early out
        if (insanityRegenEnabled && !regeneratingInsanityCoroutineRunning)
        {
            StartCoroutine("C_InsanityRegen");
        }
    }

    
    IEnumerator C_HealthRegen()
    {
        regeneratingHealthCoroutineRunning = true;
        yield return new WaitForSeconds(healthRegenDelay);

        while (healthRegenEnabled && !atMaxHealth)
        {
            yield return new WaitForSeconds(healthRegenSpeed);

            if (healthRegenEnabled && !atMaxHealth) { HealPlayer(1); } //since time passed we need to make sure we are still regenerating health before we apply the heal


            yield return null;
        }
        regeneratingHealthCoroutineRunning = true;
    }

    IEnumerator C_InsanityRegen()
    {
        while (insanityRegenEnabled && insanity > 0)
        {
            insanity -= Time.deltaTime * insanityRegen;
            yield return null;
        }
    }
    #endregion

    #region monobehavior callbacks
    private void Awake()
    {
        health = maxHealth;
        insanity = 0;
        blood = 0;
        insight = 0;
        nullfunc deathfunc = OnDeath;
        PlayerDied.AddPersistentCall(deathfunc);
    }
    private void Start()
    {
        healthRegenEnabled = healthRegenEnabled; //setters automatically handle some logic for checking if we should start regen coroutines
        insanityRegenEnabled = insanityRegenEnabled;
        GainBlood(50);
    }
    #endregion

    delegate void nullfunc();
    void OnDeath()
    {
        hasDied = true;
    }
}
