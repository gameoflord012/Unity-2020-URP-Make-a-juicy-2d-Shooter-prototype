using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFreezeFeedback : Feedback
{
    [SerializeField]
    private float freezeTimeDelay = .01f, unfreezeTimeDelay = .02f;

    [SerializeField]
    [Range(0, 1)]
    private float timeFreezeValue = .02f;

    public override void CompletePreviousFeedback()
    {
        if(TimeController.instance != null)
            TimeController.instance.ResetTimeScale();
    }

    public override void CreateFeedback()
    {
        TimeController.instance.ModifyTimeScale(timeFreezeValue, freezeTimeDelay, () =>
        TimeController.instance.ModifyTimeScale(1, unfreezeTimeDelay));
    }
}
