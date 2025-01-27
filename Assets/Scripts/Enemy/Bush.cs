using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _damage = 10f; // Урон врага
    [SerializeField] private Fighter _playerFighter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _playerFighter.TakeDamage(_damage);
    }
}
