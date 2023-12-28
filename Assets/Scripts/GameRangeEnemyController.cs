using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRangeEnemyController : GameEnemyController
{
    [SerializeField] private float followRange = 15f;
    [SerializeField] private float ShootRange = 10f;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        float distance = DistanceToTarget();
        Vector2 direction = DirectionToTarget();

        IsAttacking = false;
        if(distance <= followRange)
        {
            if(distance <= ShootRange)
            {
                int layerMaskTarget = Stats.CurrentStates.attackSO.target;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 11f, (1<< LayerMask.NameToLayer("Level")));

                if (hit.collider != null && layerMaskTarget  == (layerMaskTarget | (1 << hit.collider.gameObject.layer)))
                {
                    CallLookEvent(direction);
                    CallMoveEvent(Vector2.zero);
                    IsAttacking = true;
                }
                else
                {
                    CallMoveEvent(direction);
                }
            }
            else
            {
                CallMoveEvent(direction);
            }
        }
        else
        {
            CallMoveEvent(direction);
        }
    }
}
