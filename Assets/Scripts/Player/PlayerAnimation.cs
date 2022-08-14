using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void StartJumpAnimation()
    {
        _animator.SetTrigger("isJumping");
    }

    public void RockCollision()
    {
        _animator.SetTrigger("isFall");
    }
}
