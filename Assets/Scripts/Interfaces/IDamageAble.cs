using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageAble
{
    public int GetHealth();
    public int Damage(DamageData damage);
}

