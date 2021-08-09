using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIDecision : MonoBehaviour
{
    protected AIActionData aiActionData;
    protected AIMovementData aiMovementData;
    protected EnemyAIBrain enemyBrain;

    private void Awake()
    {
        aiActionData = transform.GetComponentInParent<AIActionData>();
        aiMovementData = transform.GetComponentInParent<AIMovementData>();
        enemyBrain = transform.GetComponentInParent<EnemyAIBrain>();
    }

    public abstract bool MakeADecision();
}
