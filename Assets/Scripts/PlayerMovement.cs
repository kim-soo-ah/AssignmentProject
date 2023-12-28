using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerController _controller;
    private Rigidbody2D _rigidbody2D;
    private CharacterStatsHandler _stats;
    private Vector2 _movementDirection = Vector2.zero;
    public float moveSpeed;
    public float jumpPower;
    bool isJumpAvailable;

    private Vector2 _knockback = Vector2.zero;
    private float knockbackDuration = 0.0f;
    private void Awake()
    {
        _stats = GetComponent<CharacterStatsHandler>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _controller = GetComponent<PlayerController>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
        _controller.OnJumpEvent += Jump;
    }

    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
        if(knockbackDuration > 0.0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    

    private void Jump(bool isJump)
    {
        if (isJumpAvailable)
        {
            isJumpAvailable = false;
            _rigidbody2D.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
        }
        else return;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumpAvailable = true;
        }
    }

    public void ApplyKnockback(Transform other, float power, float duration)
    {
        knockbackDuration = duration;
        _knockback = -(other.position - transform.position).normalized * power;
    }

    public void ApplyMovement(Vector2 direction)
    {
        //direction = direction * _stats.CurrentStates.speed;
        //_rigidbody2D.velocity = direction;
        if (direction.x > 0)
        {
            _rigidbody2D.velocity = new Vector2(moveSpeed, _rigidbody2D.velocity.y);
        }
        else if (direction.x < 0)
        {
            _rigidbody2D.velocity = new Vector2((-1 * moveSpeed), _rigidbody2D.velocity.y);
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
        }

        if(knockbackDuration > 0.0f)
        {
            _rigidbody2D.velocity += new Vector2( _knockback.x, 0);
        }
    }
}
