using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

/// <summary>
/// Holds information related to how towers target enemies.
/// </summary>
public interface ITargetable
{
    public Vector3 GetPosition();
}
