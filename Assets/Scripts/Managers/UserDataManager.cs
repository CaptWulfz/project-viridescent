using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataManager : Singleton<UserDataManager>
{
    private UserData userData;

    private Inventory inventory;

    public void Initialize()
    {
        this.userData = new UserData();
        this.inventory = new Inventory();
        this.inventory.InitializeInventory();
    }

    public void AddLeaves(int leaves, Action onComplete = null)
    {
        this.userData.leaves += leaves;
        PostLeavesModifiedEvent(leaves);
        onComplete?.Invoke();
    }

    public void DeductLeaves(int leaves, Action onComplete = null)
    {
        this.userData.leaves -= leaves;
        PostLeavesModifiedEvent(leaves);
        onComplete?.Invoke();
    }

    #region Inventory Management
    public void AddToInventory(InventoryItem item)
    {
        this.inventory.AddInventoryItem(item);
    }

    public InventoryItemEntry GetInventoryItem(string name)
    {
        return this.inventory.GetInventoryItem(name);
    }

    public void TryPuchaseInventoryItem(InventoryItem item, int value, Action onSuccess = null, Action onFailure = null)
    {
        bool allowPurchase = false;

        if (this.userData.leaves < value)
        {
            onFailure?.Invoke();
            return;
        }

        InventoryItemEntry itemEntry = GetInventoryItem(item.Name);

        if (itemEntry != null)
        {
            Debug.Log("Current Stack: " + itemEntry.stack + " | Max Stacks: " + itemEntry.inventoryItem.MaxStacks);
            if (itemEntry.stack < itemEntry.inventoryItem.MaxStacks)
            {
                Debug.Log("Item not yet at limit. Allow");
                allowPurchase = true;
            } else
            {
                Debug.Log("Item at Limit. Restrict");
            }
        } else
        {
            Debug.Log("Item does not exist");
            allowPurchase = true;
        }

        if (allowPurchase)
        {
            AddToInventory(item);
            onSuccess?.Invoke();
        } else
        {
            onFailure?.Invoke();
        }
    }
    #endregion

    #region Eventbroadcasting
    private void PostLeavesModifiedEvent(int leaves)
    {
        Parameters param = new Parameters();
        param.AddParameter<int>(ParameterNames.LEAVES_VALUE, leaves);

        EventBroadcaster.Instance.PostEvent(EventNames.ON_LEAVES_MODIFIED, param);
    }

    private void PostWaterModifiedEvent(int water)
    {
        Parameters param = new Parameters();
        param.AddParameter<int>(ParameterNames.WATER_VALUE, water);

        EventBroadcaster.Instance.PostEvent(EventNames.ON_WATER_MODIFIED, param);
    }
    #endregion
}
