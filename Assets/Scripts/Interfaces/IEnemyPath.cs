using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IEnemyPath
{
    public Vector2 GetPosition(float distanceAlongPath);
}