using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string _jumpTrigger = "isJumping";
    private const string _fallTrigger = "isFall";

    public void StartJumpAnimation()
    {
        _animator.SetTrigger(_jumpTrigger);
    }

    public void RockCollision()
    {
        _animator.SetTrigger(_fallTrigger);
    }
}
