using System;
using UnityEngine;

public class DeathChecker : MonoBehaviour
{
    [SerializeField] private GameStarter _starter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMover _))
        {
            _starter.StartGame();
        }
    }
}
