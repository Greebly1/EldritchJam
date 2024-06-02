using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    //==================Inspector Fields==================
    #region InspectorFields
    [SerializeField]
    [Tooltip("The base value for calculating this weapon's damage.")]
    protected float damage = 1;
    #endregion InspectorFields

    protected Tower attachedTower;

    private CancellationTokenSource attackLoopCancellationToken;

    public void Init(Tower tower)
    {
        attachedTower = tower;
    }

    protected abstract ITargetable GetTarget();

    public void StartAttackLoop()
    {
        attackLoopCancellationToken = new CancellationTokenSource();
        AttackLoop(attackLoopCancellationToken);
    }

    public void StopAttackLoop()
    {
        attackLoopCancellationToken.Cancel();
    }

    private async void AttackLoop(CancellationTokenSource cancellationToken) 
    {
        bool continueLooping = true;
        Awaitable attackPattern = null;
        
        cancellationToken.Token.Register(() =>
        {
            continueLooping = false;
            attackPattern.Cancel();
        });

        while (continueLooping)
        {
            attackPattern = AttackPattern();
            try
            {
                await attackPattern;
            }
            catch (OperationCanceledException) { } //OperationCanceledException is expected when StopAttackLoop is called, so we'll catch it and not do anything with the exception.

            await Awaitable.NextFrameAsync();
        }
    }

    protected abstract Awaitable AttackPattern();
}
