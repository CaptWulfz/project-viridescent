using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FloraeModel.asset", menuName = "Database/Florae Model")]
public class FloraeModel : Item, ISeasonal, IAudible
{
    [field: Header("Florae Model Details")]
    public FloraeStateAnimation[] FloraeStateAnimation;

    [field: SerializeField]
    public int WaterYield { get; set; }

    [field: SerializeField]
    public float TimeUntilNextYield { get; set; }

    [field: Header("Sound Details")]
    [field: SerializeField]
    public Sound[] Sounds { get; set; }

    [field: Header("Seasonal Details")]
    [field: SerializeField]
    public SeasonType SeasonType { get; set; }
}

[System.Serializable]
public class FloraeStateAnimation
{
    public FloraeState FloraeState;
    public AnimationClip AnimationClip;
}

public enum FloraeState
{
    IDLE,
    HAPPY,
    SAD,
    MAD
}
