using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class Startup : MonoBehaviour
{
    [SerializeField] SplashScreen splashScreen;

    private void Start()
    {
        DontDestroyOnLoad(this);
        StartCoroutine(Initialize());
    }

    /// <summary>
    /// Initializes the different Game Managers and Assets needed before the game is properly displayed
    /// </summary>
    /// <returns></returns>
    private IEnumerator Initialize()
    {
        DataManager.Instance.Initialize();
        yield return new WaitUntil(() => { return DataManager.Instance.IsDone; });
        this.splashScreen.SetLoadingProgress(0.2f);

        AudioManager.Instance.Initialize();
        yield return new WaitUntil(() => { return AudioManager.Instance.IsDone; });
        this.splashScreen.SetLoadingProgress(0.4f);

        PopupManager.Instance.Initialize();
        yield return new WaitUntil(() => { return PopupManager.Instance.IsDone; });
        this.splashScreen.SetLoadingProgress(0.6f);

        InputManager.Instance.Initialize();
        yield return new WaitUntil(() => { return InputManager.Instance.IsDone; });
        this.splashScreen.SetLoadingProgress(0.8f);

        GameLoaderManager.Instance.Initialize();
        yield return new WaitUntil(() => { return GameLoaderManager.Instance.IsDone; });
        this.splashScreen.SetLoadingProgress(1.0f);

        yield return new WaitForSeconds(2f);

        this.splashScreen.Hide();
        GameLoaderManager.Instance.ToggleMainHud(true);
        GameLoaderManager.Instance.PlayMainTheme();
        this.gameObject.GetComponent<FocusHandler>().Initialize();
    }
}
