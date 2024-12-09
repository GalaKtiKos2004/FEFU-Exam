using System;
using UnityEngine;

public class PlayerFinder : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;

    private bool _inZone;

    public event Action Collide;

    private void Awake()
    {
        _inZone = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((_playerLayer & (1 << collision.gameObject.layer)) != 0 && _inZone == false)
        {
            Debug.Log("Trigger Enter");
            _inZone = true;
            Collide?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((_playerLayer & (1 << collision.gameObject.layer)) != 0 && _inZone)
        {
            _inZone = false;
            Debug.Log("Trigger Exit");
            Collide?.Invoke();
        }
    }
}