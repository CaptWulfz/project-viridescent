using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusHandler : MonoBehaviour
{
    private bool isReady = false;
    public void Initialize()
    {
        this.isReady = true;
    }

    #region Focus Handling
#if UNITY_EDITOR
    // For Android, this function is called when the on-screen keyboard is brought up
    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            OnGameOutOfFocus();
        } else
        {
            OnReturnToGame();
        }
    }
#endif

#if UNITY_ANDROID && !UNITY_EDITOR
    // For Android, this function is called when the user presses the home screen
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            OnGamePause();
        } else
        {
            OnReturnToGame();
        }
    }
#endif

    private void OnApplicationQuit()
    {
        OnGameExit();
    }
    #endregion

    #region Functions
    private void OnGameOutOfFocus()
    {
        StoreTimeOnExit();
    }

    private void OnGamePause()
    {
        StoreTimeOnExit();
    }

    private void OnGameExit()
    {
        StoreTimeOnExit();
    }

    private void OnReturnToGame()
    {
        EvalauteTimeOnReturn();
    }
    #endregion

    #region Helpers
    private void StoreTimeOnExit()
    {
        if (!isReady)
            return;

        string currDateTime = DateTime.UtcNow.ToString();
        PlayerPrefs.SetString(PlayerPrefNames.DATE_TIME_ON_EXIT, currDateTime);
    }

    private void EvalauteTimeOnReturn()
    {
        if (!isReady)
            return;

        //LoadingOverlay.Instance.ShowOverlay("Lmao");
        string currDateTime = PlayerPrefs.GetString(PlayerPrefNames.DATE_TIME_ON_EXIT, "");
        if (!String.IsNullOrEmpty(currDateTime))
        {
            DateTime date = DateTime.Parse(currDateTime);
            
        }
    }
    #endregion
}
