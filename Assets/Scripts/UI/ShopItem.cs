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

    private InventoryItem inventoryItem;

    public void Setup(InventoryItem item)
    {
        this.inventoryItem = item;
        SetupInfo(item.Name, item.Sprite, item.Value, item.Description);
    }
    
    protected void SetupInfo(string itemName, Sprite itemImage, float itemValue, string itemDesc)
    {
        this.itemName.text = itemName;
        this.itemImage.sprite = itemImage;
        this.itemValue.text = itemValue.ToString();
        this.itemDescription.text = itemDesc;
    }

    public void OnPurchaseButtonClicked()
    {
        UserDataManager.Instance.TryPuchaseInventoryItem(this.inventoryItem, this.inventoryItem.Value, OnPurchaseSucces, OnPurchaseFailed);
    }

    private void OnPurchaseSucces()
    {
        Debug.Log("Purchase Success!");
    }

    private void OnPurchaseFailed()
    {
        Debug.Log("Purchase Failed!");
    }
}
