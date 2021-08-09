using System.Collections;
using UnityEngine;

public abstract class AIAction : MonoBehaviour
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

    public abstract void TakeAction();
}