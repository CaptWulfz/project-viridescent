using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{
    [SerializeField] SplashScreen splashScreen;

    private void Start()
    {
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
        splashScreen.SetLoadingProgress(0.33f);


        AudioManager.Instance.Initialize();
        yield return new WaitUntil(() => { return AudioManager.Instance.IsDone; });
        splashScreen.SetLoadingProgress(0.66f);

        GameManager.Instance.Initialize();
        yield return new WaitUntil(() => { return GameManager.Instance.IsDone; });
        splashScreen.SetLoadingProgress(1.0f);

        yield return new WaitForSeconds(2f);

        this.splashScreen.gameObject.SetActive(false);
        GameManager.Instance.PlayMainTheme();
    }
}
