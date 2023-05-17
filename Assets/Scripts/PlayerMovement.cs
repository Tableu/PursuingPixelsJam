using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterStats))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rgbdy;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private PlayerInputActions _playerInputActions;
    private Vector2 _direction;
    private CharacterStats _stats;

    private void Start()
    {
        _stats = GetComponent<CharacterStats>();
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Enable();
    }
    
    private void FixedUpdate()
    {
        _direction = _playerInputActions.Player.Movement.ReadValue<Vector2>();
        rgbdy.AddForce(_direction*_stats.speed,ForceMode2D.Impulse);
        var velocity = rgbdy.velocity;
        if (Mathf.Abs(velocity.x) > _stats.speed)
        {
            velocity.x = Mathf.Sign(velocity.x)*_stats.speed;
        }

        if (Mathf.Abs(velocity.y) > _stats.speed)
        {
            velocity.y = Mathf.Sign(velocity.y)*_stats.speed;
        }

        if (_direction.x == 0)
        {
            velocity.x = 0;
        }
        else
        {
            spriteRenderer.flipX = _direction.x < 0;
        }

        if (_direction.y == 0)
        {
            velocity.y = 0;
        }

        rgbdy.velocity = velocity;
    }
}
