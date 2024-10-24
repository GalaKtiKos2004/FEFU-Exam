using UnityEngine;

[RequireComponent(typeof(ColliderDetector))]
public abstract class Drummer : Fighter
{
    [SerializeField] private LayerMask _attackedLayer;
    [SerializeField] private Vector2 _colliderSize;
    [SerializeField] private float _damage;

    private ColliderDetector _detector;

    private Attacker _attacker;

    private void Awake()
    {
        _detector = GetComponent<ColliderDetector>();
        _attacker = new Attacker();
    }

    protected override void Attack()
    {
        if (_attacker.TryAttack(_damage, _detector, transform, _attackedLayer, _colliderSize))
        {
            
        }
    }
}
