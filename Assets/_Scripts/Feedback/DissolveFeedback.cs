using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DissolveFeedback : Feedback
{
    [SerializeField]
    private SpriteRenderer spriteRenderer = null;

    [SerializeField]
    private float duration = .05f;

    [field: SerializeField]
    public UnityEvent DealthCallback { get; set; }

    public override void CreateFeedback()
    {
        spriteRenderer.DOComplete();
        spriteRenderer.material.DOComplete();
    }

    public override void CompletePreviousFeedback()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(spriteRenderer.material.DOFloat(0, "_Dissolve", duration));
        if(DealthCallback != null)
        {
            sequence.AppendCallback(() => DealthCallback?.Invoke());
        }
    }
}
