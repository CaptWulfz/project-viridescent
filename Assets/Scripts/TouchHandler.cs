using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchHandler : Singleton<TouchHandler>
{
    public delegate void StartTouchEvent(Vector2 position);
    public event StartTouchEvent OnStartTouch;

    public delegate void EndTouchEvent(Vector2 position);
    public event EndTouchEvent OnEndTouch;

    private Controls touchControls;

    private void Start()
    {
        this.touchControls = InputManager.Instance.GetControls();
        this.touchControls.Player.Enable();
        this.touchControls.Player.TouchPress.started += ctx => StartTouch(ctx);
        this.touchControls.Player.TouchPress.canceled += ctx => EndTouch(ctx);
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        if (OnStartTouch != null)
            OnStartTouch(this.touchControls.Player.TouchPosition.ReadValue<Vector2>());
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        if (OnEndTouch != null)
            OnEndTouch(this.touchControls.Player.TouchPosition.ReadValue<Vector2>());
    }

    #region Injectors
    public void RegisterStartTouchEvent(StartTouchEvent touchEvent)
    {
        this.OnStartTouch += touchEvent;
    }

    public void UnregistertartTouchEvent(StartTouchEvent touchEvent)
    {
        this.OnStartTouch -= touchEvent;
    }
    #endregion
}
