using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private const string MAIN_SOURCE = "MAIN_SOURCE";

    private AudioSource mainSource;

    private bool isDone = false;
    public bool IsDone
    {
        get { return this.isDone; }
    }

    #region Initialization
    public void Initialize()
    {
        this.mainSource = this.gameObject.AddComponent<AudioSource>();
        AudioManager.Instance.RegisterAudioSource(AudioKeys.MUSIC, MAIN_SOURCE, mainSource);
        StartCoroutine(LoadFirstScene());
    }

    private IEnumerator LoadFirstScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneNames.GARDEN_SCENE, LoadSceneMode.Additive);

        yield return new WaitUntil(() => { return asyncLoad.isDone; });

        this.isDone = true;
    }
    #endregion

    /// <summary>
    /// Plays the Main Theme of the Game
    /// </summary>
    public void PlayMainTheme()
    {
        AudioManager.Instance.PlayAudio(AudioKeys.MUSIC, MAIN_SOURCE, MusicKeys.MAIN_THEME);
        AudioManager.Instance.SetAudioGroupVolume(AudioKeys.MUSIC, 0.5f);
        AudioManager.Instance.ToggleAudioGroupLoop(AudioKeys.MUSIC, true);
    }
}
