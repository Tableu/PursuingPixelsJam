using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponInput : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void FixedUpdate()
    {
        if (Mouse.current.leftButton.isPressed && !animator.GetCurrentAnimatorStateInfo(0).IsName("Sword Animation"))
        {
            animator.SetTrigger("Attack");
        }
    }
}
