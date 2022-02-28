using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SeedItem.asset", menuName = "Database/Seed Item")]
public class SeedItem : InventoryItem, ISeasonal
{
    [field: Header("Seed Item Details")]
    [field: SerializeField]
    public FloraeName FloraeName;

    [field: Header("Seasonal Details")]
    [field: SerializeField]
    public SeasonType SeasonType { get; set; }
}
