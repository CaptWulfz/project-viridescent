using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoaderManager : Singleton<GameLoaderManager>
{
    private const string MAIN_HUD_PATH = "Prefabs/UI/MainHud";

    private Canvas mainCanvas;

    private MainHud mainHud;
    private GameCamera gameCamera;

    private bool isMainHudLoaded = false;

    private bool isDone = false;
    public bool IsDone
    {
        get { return this.isDone; }
    }

    #region Initialization
    public void Initialize()
    {
        this.mainCanvas = GameObject.FindGameObjectWithTag(TagNames.MAIN_CANVAS).GetComponent<Canvas>();
        this.gameCamera = GameObject.FindGameObjectWithTag(TagNames.MAIN_CAMERA).GetComponent<GameCamera>();
        this.gameCamera.Initialize();

        StartCoroutine(LoadFirstScene());
    }

    private IEnumerator LoadFirstScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneNames.GARDEN_SCENE, LoadSceneMode.Single);

        LoadMainHud();

        yield return new WaitUntil(() => { return asyncLoad.isDone && this.isMainHudLoaded; });

        this.isDone = true;
    }

    private void LoadMainHud()
    {
        GameObject mainHud = Resources.Load<GameObject>(MAIN_HUD_PATH);
        GameObject hud = Instantiate(mainHud, mainCanvas.transform);
        hud.SetActive(false);
        this.mainHud = hud.GetComponent<MainHud>();
        this.isMainHudLoaded = true;
    }
    #endregion

    /// <summary>
    /// Plays the Main Theme of the Game
    /// </summary>
    public void PlayMainTheme()
    {
        this.gameCamera.PlayMainTheme();
    }

    /// <summary>
    /// Toggles the Main Hud on or off
    /// </summary>
    /// <param name="active">Main Hud active value to be set. true or false</param>
    public void ToggleMainHud(bool active)
    {
        this.mainHud.gameObject.SetActive(active);
    }
}
