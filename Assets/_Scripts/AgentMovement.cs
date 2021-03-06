using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class AgentMovement : MonoBehaviour
{
    protected Rigidbody2D rigidbody2d;

    [field : SerializeField]
    public MovementDataSO MovementData { get; set; }

    [SerializeField]
    protected float currentVelocity = 3;
    protected Vector2 movementDirection;

    private bool isKnockingBack = false;

    [field: SerializeField]
    public UnityEvent<float> OnVelocityChange { get; set; }

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void MoveAgent(Vector2 movementInput)
    {
        movementDirection = movementInput;
        currentVelocity = CalculateSpeed(movementInput);
    }

    private float CalculateSpeed(Vector2 movementInput)
    {
        if(movementInput.magnitude > 0)
        {
            currentVelocity += MovementData.acceleration * Time.deltaTime;
        }
        else
        {
            currentVelocity -= MovementData.deacceleration * Time.deltaTime;
        }

        return Mathf.Clamp(currentVelocity, 0, MovementData.maxSpeed);
    }

    private void FixedUpdate()
    {
        if(!isKnockingBack)
        {
            OnVelocityChange?.Invoke(currentVelocity);
            rigidbody2d.velocity = currentVelocity * movementDirection.normalized;
        }        
    }

    public void StopImmediately()
    {
        currentVelocity = 0;
        rigidbody2d.velocity = Vector2.zero;
    }

    public void KnockBack(Vector2 direction, float power, float duration)
    {
        if(isKnockingBack == false)
            StartCoroutine(KnockBackRoutine(direction, power, duration));
    }

    public void ResetKockBack()
    {
        StopCoroutine(nameof(KnockBackRoutine));
        isKnockingBack = false;
        rigidbody2d.velocity = Vector2.zero;
    }

    IEnumerator KnockBackRoutine(Vector2 direction, float power, float duration)
    {
        isKnockingBack = true;
        rigidbody2d.AddForce(direction * power, ForceMode2D.Impulse);
        yield return new WaitForSeconds(duration);
        ResetKockBack();
    }
}
