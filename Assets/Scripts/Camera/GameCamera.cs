using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    private AudioSource musicSource;

    private string musicSourceName;

    public void Initialize()
    {
        this.musicSource = GetComponent<AudioSource>();
        this.musicSourceName = string.Format("Music-Source@{0}", this.gameObject.GetInstanceID());

        AudioManager.Instance.RegisterAudioSource(AudioKeys.MUSIC, this.musicSourceName, this.musicSource);
    }

    public void PlayMainTheme()
    {
        AudioManager.Instance.PlayAudio(AudioKeys.MUSIC, this.musicSourceName, MusicKeys.MAIN_THEME);
        AudioManager.Instance.SetAudioGroupVolume(AudioKeys.MUSIC, 0.5f);
        AudioManager.Instance.ToggleAudioGroupLoop(AudioKeys.MUSIC, true);
    }
}
