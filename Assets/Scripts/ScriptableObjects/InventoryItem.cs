using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : Item
{
    [field: Header("Inventory Item Details")]
    [field: SerializeField]
    public bool IsStackable { get; set; }

    [field: SerializeField]
    public int MaxStacks { get; set; }

    [field: SerializeField]
    public int Value { get; set; }
}
