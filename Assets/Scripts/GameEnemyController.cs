using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnemyController : PlayerController
{
    GameManager gameManager;

    protected Transform ClosetTarget { get; private set; }

    protected override void Awake()
    {
        base.Awake();
    }

    protected virtual void Start()
    {
        gameManager = GameManager.Instance;
        ClosetTarget = gameManager.Player;
    }

    protected virtual void FixedUpdate()
    {

    }

    protected float DistanceToTarget()
    {
        if(ClosetTarget == null)
        {
            gameManager.Player = GameObject.FindGameObjectWithTag("Player").transform;
            ClosetTarget = gameManager.Player;
        }
        return Vector3.Distance(transform.position, ClosetTarget.position);
    }

    protected Vector2 DirectionToTarget()
    {
        return (ClosetTarget.position - transform.position).normalized;
    }
}
