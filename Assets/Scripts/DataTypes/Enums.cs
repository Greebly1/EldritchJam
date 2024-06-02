using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum Team
{
    Player,
    Enemy,
    None
}

public enum LevelState
{
    OngoingWave,
    Waiting
}