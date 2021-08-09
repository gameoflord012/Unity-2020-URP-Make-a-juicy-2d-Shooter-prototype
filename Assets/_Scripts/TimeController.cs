using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static TimeController instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void ResetTimeScale()
    {
        StopAllCoroutines();
        Time.timeScale = 1;
    }

    public void ModifyTimeScale(float endTimeValue, float timeToWait, Action OnCompleteCallback = null)
    {
        StartCoroutine(TimeScaleRoutine(endTimeValue, timeToWait, OnCompleteCallback));
    }

    IEnumerator TimeScaleRoutine(float endTimeValue, float timeToWait, Action OnCompleteCallback = null)
    {
        yield return new WaitForSeconds(timeToWait);
        Time.timeScale = endTimeValue;
        OnCompleteCallback?.Invoke();
    }
}
