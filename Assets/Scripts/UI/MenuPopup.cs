using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPopup : Popup
{
    #region Unity Button Events
    public void OnInventoryButtonClicked()
    {
        
    }
    
    public void OnShopButtonClicked()
    {
        ShopPopup popup = PopupManager.Instance.ShowPopup<ShopPopup>(PopupNames.SHOP_POPUP);
        popup.Setup();
        popup.Show();
        Hide();
    }
    
    public void OnDiaryButtonClicked()
    {
        
    }
    
    public void OnSettingsButtonClicked()
    {
        SettingsPopup popup = PopupManager.Instance.ShowPopup<SettingsPopup>(PopupNames.SETTINGS_POPUP);
        popup.Show();
    }
    #endregion
}
