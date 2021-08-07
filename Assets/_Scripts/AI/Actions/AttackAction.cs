using System.Collections;
using UnityEngine;

public class AttackAction : AIAction
{
    public override void TakeAction()
    {
        aiMovementData.Direction = Vector2.zero;
        aiMovementData.PointOfInterest = enemyBrain.Target.transform.position;
        enemyBrain.Move(aiMovementData.Direction, aiMovementData.PointOfInterest);
        aiActionData.Attack = true;
        enemyBrain.Attack();
    }
}