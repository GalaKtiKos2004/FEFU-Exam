using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatroler : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _delay = 5f;
    [SerializeField] private List<Transform> _waypoints;

    private int _currentWaypoint = 0;

    private float _currentSpeed;

    private WaitForSeconds _wait;

    public event Action<float> Moved;

    private void Start()
    {
        _wait = new WaitForSeconds(_delay);
        _currentSpeed = _speed;
    }

    private void Update()
    {
        Move();

        if (transform.position.x == _waypoints[_currentWaypoint].position.x)
        {
            if (_currentWaypoint == _waypoints.Count - 1)
            {
                StartCoroutine(CountPatrolDelay());
            }
            else
            {
                _currentWaypoint++;
            }
        }
    }

    private void Move()
    {
        Moved?.Invoke(_currentSpeed);
        transform.position = new Vector3(
            Mathf.MoveTowards(transform.position.x, _waypoints[_currentWaypoint].position.x, _currentSpeed * Time.deltaTime),
            transform.position.y, transform.position.z);
    }

    private IEnumerator CountPatrolDelay()
    {
        Vector3 rotation = new Vector3(0f, 180f, 0f);

        _currentSpeed = 0;

        _waypoints.Reverse();
        _currentWaypoint = 0;

        yield return _wait;

        transform.Rotate(rotation);
        _currentSpeed = _speed;
    }
}
