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
        TouchHandler.Instance.RegisterStartTouchEvent(OnStartTouch);
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

    private void HandleTouchEvent()
    {
        if (this.readyForYield)
        {
            Debug.Log("Yield collected!");
            this.readyForYield = false;
            this.timeUntilNextYield = this.floraeModel.TimeUntilNextYield;
        } else
        {

        }
    }

    #region Touch Handler Events
    private void OnStartTouch(Vector2 position)
    {
        Vector2 tapPos = Camera.main.ScreenToWorldPoint(position);
        RaycastHit2D hit = Physics2D.Raycast(tapPos, Vector2.zero);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.GetInstanceID() == this.gameObject.GetInstanceID())
            {
                HandleTouchEvent();
            }
        }
    }
    #endregion
}
