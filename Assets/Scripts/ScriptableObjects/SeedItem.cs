using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SeedItem.asset", menuName = "Database/Seed Item")]
public class SeedItem : Item
{
    [field: SerializeField]
    public SeasonType[] SeasonTypes { get; set; }
}

public enum SeasonType
{
    SPRING,
    SUMMER,
    FALL,
    WINTER
}
