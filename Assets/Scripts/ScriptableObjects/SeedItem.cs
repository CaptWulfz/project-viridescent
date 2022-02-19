using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SeedItem.asset", menuName = "Database/Seed Item")]
public class SeedItem : Item, ISeasonal
{
    [field: SerializeField]
    public SeasonType SeasonType { get; set; }
}
