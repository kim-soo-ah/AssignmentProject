using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAnimationController : GameAnimations
{
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int IsHit = Animator.StringToHash("IsHit");

    
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        _playerController.OnAttackEvent += Attacking;
        _playerController.OnMoveEvent += Move;
    }

    private void Move(Vector2 obj)
    {
        _animator.SetBool(IsRunning, obj.magnitude > .5f);
    }

    private void Attacking(AttackSO obj)
    {
        _animator.SetTrigger(Attack);
    }

    private void Hit()
    {
        _animator.SetBool(IsHit, true);
    }

    private void InvincibilityEnd()
    {
        _animator.SetBool(IsHit, false);
    }
}
