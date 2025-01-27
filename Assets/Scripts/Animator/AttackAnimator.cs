using System.Collections;
using UnityEngine;

public class AttackAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private static readonly int IsAttackingParam = Animator.StringToHash("IsAttacking");

    private float _speed;
    private bool _isAttacking;

    public void Attack()
    {
        if (_isAttacking) return;

        _isAttacking = true;
        _animator.SetTrigger(IsAttackingParam);
        
        StartCoroutine(ResetAttackState());
    }

    private IEnumerator ResetAttackState()
    {
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        _isAttacking = false;
        _animator.ResetTrigger(IsAttackingParam);
    }
}
