using UnityEngine;

[RequireComponent(typeof(Animator), typeof(EnemyMovement))]
public class EnemyAnimator : MonoBehaviour
{
    private Animator _animator;
    private EnemyMovement _enemyMovement;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemyMovement = GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        _animator.SetBool(EnemyAnimatorData.Params.IsFalling, _enemyMovement.IsFalling);
    }
}
