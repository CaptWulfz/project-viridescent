using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Florae : MonoBehaviour
{
    private FloraeModel floraeModel;

    private SpriteRenderer spriteRenderer;

    private AudioSource audioSource;
    private string sourceName;

    private bool readyForYield;
    private float timeUntilNextYield;

    public void Initialize()
    {
        this.gameObject.name = this.floraeModel.Name;
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.spriteRenderer.sprite = this.floraeModel.Sprite;
        this.readyForYield = false;
        this.timeUntilNextYield = this.floraeModel.TimeUntilNextYield;
        InitializeAudioSettings();
    }

    private void InitializeAudioSettings()
    {
        this.audioSource = GetComponent<AudioSource>();
        this.sourceName = string.Format("{0}@{1}", this.floraeModel.Name, this.gameObject.GetInstanceID());
        AudioManager.Instance.RegisterAudioSource(AudioKeys.SFX, this.sourceName, this.audioSource);
    }

    private void PlayAudioClip(string clipName)
    {
        Sound sound = Array.Find<Sound>(this.floraeModel.Sounds, (x) => { return x.Name == clipName; });
        AudioManager.Instance.PlayAudioWithClip(AudioKeys.SFX, this.sourceName, sound.AudioClip);
    }

    public void SetFloraeModel(FloraeModel floraeModel)
    {
        this.floraeModel = floraeModel;
    }

    private void Update()
    {
        if (this.readyForYield)
            return;

        if ((int)this.timeUntilNextYield > 0)
            this.timeUntilNextYield -= Time.deltaTime;
        else
        {
            this.readyForYield = true;
            Debug.Log("Ready for Yield!");
        }
    }


}
