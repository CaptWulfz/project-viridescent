using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    [field: Header("Item Details")]
    [field: SerializeField]
    public string Id { get; set; }

    [field: SerializeField]
    public string Name { get; set; }

    [field: SerializeField]
    [field: TextArea]
    public string Description { get; set; }

    [field: SerializeField]
    public Sprite Sprite { get; set; }
}