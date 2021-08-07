using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentInput : MonoBehaviour, IAgentInput
{
    private Camera mainCamera;

    [field: SerializeField]
    public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }

    [field: SerializeField]
    public UnityEvent<Vector2> OnPointerPositionChange { get; set; }

    [field: SerializeField]
    public UnityEvent OnFireButtonPressed { get; set; }

    [field: SerializeField]
    public UnityEvent OnFireButtonReleased { get; set; }

    private bool fireButtonDown = false;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        GetMovementInput();
        GetPointerInput();
        GetFireInput();
    }

    private void GetFireInput()
    {
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            if (fireButtonDown == false)
            {
                fireButtonDown = true;
                OnFireButtonPressed?.Invoke();
            }
        }
        else
        {
            if (fireButtonDown == true)
            {
                fireButtonDown = false;
                OnFireButtonReleased?.Invoke();
            }
        }
    }

    private void GetPointerInput()
    {
        var mouseInWorldSpace = mainCamera.ScreenToWorldPoint(new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            mainCamera.nearClipPlane));
        OnPointerPositionChange?.Invoke(mouseInWorldSpace);
    }

    private void GetMovementInput()
    {
        OnMovementKeyPressed?.Invoke(new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"))
            );
    }
}
