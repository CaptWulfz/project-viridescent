using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Florae : MonoBehaviour
{
    [Header("Main Components")]
    [SerializeField] SpriteRenderer spriteRenderer;

    public void Setup() 
    {
        
    }

    private void Update()
    {
       HandleMouseEvent();
    }

    private void HandleMouseEvent()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePos), Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == this.gameObject)
        {
            Debug.Log("QQQ Hit: " + hit.collider.gameObject.name + " | This: " + this.gameObject.name);
            Debug.Log("QQQ Equality Check: " + (hit.collider.gameObject == this.gameObject ? true : false));
        }
    }
}
