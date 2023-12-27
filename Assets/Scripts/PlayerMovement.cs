using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerController _controller;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _movementDirection = Vector2.zero;
    public float moveSpeed;
    public float jumpPower;
    bool isJumpAvailable;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
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
            Debug.Log("adsfasdfasdfasdf");
        }
    }

    public void ApplyMovement(Vector2 direction)
    {
        if (direction.x > 0)
        {
            _rigidbody2D.velocity = new Vector2(moveSpeed, _rigidbody2D.velocity.y);
            //_spriteRenderer.flipX = false;
        }
        else if (direction.x < 0)
        {
            _rigidbody2D.velocity = new Vector2((-1 * moveSpeed), _rigidbody2D.velocity.y);
            //_spriteRenderer.flipX = true;
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
        }
    }
}
