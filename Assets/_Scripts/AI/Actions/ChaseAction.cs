using System.Collections;
using UnityEngine;

namespace Assets._Scripts.AI.Actions
{
    public class ChaseAction : AIAction
    {
        public override void TakeAction()
        {
            var direction = enemyBrain.Target.transform.position - transform.position;
            aiMovementData.Direction = direction.normalized;
            aiMovementData.PointOfInterest = enemyBrain.Target.transform.position;
            enemyBrain.Move(aiMovementData.Direction, aiMovementData.PointOfInterest);
        }
    }
}