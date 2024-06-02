using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public static class Float3Extensions
{
    public static Vector3 ToVector3(this float3 value)
    {
        return new Vector3(value.x, value.y, value.z);
    }
}
