using System;
using UnityEngine;

public class DeathChecker : MonoBehaviour
{
    public event Action Death;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMover _))
        {
            Death?.Invoke();
        }
    }
}
