using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class EnemyPath : MonoBehaviour, IEnemyPath
{
    [SerializeField] SplineContainer path;

    #region private data
    private float pathLength = 0;
    #endregion

    private void Awake()
    {
        pathLength = path.Spline.GetLength();
        Debug.Log(pathLength);
    }

    public Vector2 GetPosition(float distanceAlongPath)
    {
        Unity.Mathematics.float3 resultPosition = Vector3.zero;
        Unity.Mathematics.float3 resultTangent = Vector3.zero;
        Unity.Mathematics.float3 resultUp = Vector3.zero;
        path.Spline.Evaluate(distanceAlongPath, out resultPosition, out resultTangent, out resultUp);
        return new Vector2(resultPosition.x, resultPosition.y);
    }

    public float GetLength()
    {
        return pathLength;
    }
}
