using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    [field: SerializeField]
    public string Name { get; set; }

    [field: SerializeField]
    public bool isStackable { get; set; }

    [field: SerializeField]
    public int Value { get; set; }

    [field: SerializeField]
    [field: TextArea]
    public string Description { get; set; }
}
