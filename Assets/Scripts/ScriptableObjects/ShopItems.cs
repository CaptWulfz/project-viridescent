using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopItems.asset", menuName = "Database/Shop Items")]
public class ShopItems : ScriptableObject
{
    [field: SerializeField]
    public SeedItem[] seedItems;
}
