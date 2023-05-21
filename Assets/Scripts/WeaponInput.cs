using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponInput : MonoBehaviour
{
    [SerializeField] private WeaponStats stats;
    [SerializeField] private Animator animator;
    private int _counter;

    public void Start()
    {
        _counter = (int)stats.cooldown;
    }

    public void FixedUpdate()
    {
        if (_counter >= (int)stats.cooldown && Mouse.current.leftButton.isPressed && !animator.GetCurrentAnimatorStateInfo(0).IsName("Sword Animation"))
        {
            animator.SetTrigger("Attack");
            _counter = 0;
        }
        else
        {
            _counter++;
        }
    }
}
