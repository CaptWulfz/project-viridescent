using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [Header("Item Components")]
    [SerializeField] Text itemName;
    [SerializeField] Image itemImage;
    [SerializeField] Text itemValue;
    [SerializeField] Text itemDescription;
    
    public void SetupInfo(string itemName, Sprite itemImage, float itemValue, string itemDesc)
    {
        this.itemName.text = itemName;
        this.itemImage.sprite = itemImage;
        this.itemValue.text = itemValue.ToString();
        this.itemDescription.text = itemDesc;
    }

    public void OnPurchaseButtonClicked()
    {

    }
}
