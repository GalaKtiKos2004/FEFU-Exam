using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatroler : MonoBehaviour, IMovable
{
    [SerializeField] private Transform _player;
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private PlayerFinder _finder;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _delay = 5f;
    [SerializeField] private float _attackDistance = 1.5f; // Дистанция для остановки перед игроком
    [SerializeField] private SimpleEnemyFighter _enemyFighter;

    private Transform _target;
    private Coroutine _patrolDelayCoroutine;
    private Quaternion _rotationLeftAngle = Quaternion.Euler(0f, 0f, 0f);
    private Quaternion _rotationRightAngle = Quaternion.Euler(0f, 180f, 0f);
    private WaitForSeconds _wait;
    private float _currentSpeed;
    private int _currentWaypoint = 0;

    public event Action<float> Moved;

    private void OnEnable()
    {
        _finder.Collide += ChangeTarget;
    }

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
        _currentSpeed = _speed;
        _target = _waypoints[_currentWaypoint];
    }

    private void Update()
    {
        Move();

        if (_target == null || _target == _player) return;

        if (transform.position.x == _waypoints[_currentWaypoint].position.x)
        {
            if (_currentWaypoint == _waypoints.Count - 1)
            {
                _patrolDelayCoroutine = StartCoroutine(CountPatrolDelay());
            }
            else
            {
                _currentWaypoint++;
                _target = _waypoints[_currentWaypoint];
            }
        }
    }

    private void OnDisable()
    {
        _finder.Collide -= ChangeTarget;
    }

    private void Move()
    {
        if (_target == null) return;

        FlipTowardsTarget();

        // Проверка дистанции, если цель - игрок
        if (_target == _player && Vector3.Distance(transform.position, _player.position) <= _attackDistance)
        {
            // Враг останавливается перед игроком
            _currentSpeed = 0;
            Moved?.Invoke(_currentSpeed);
            Attack();
        }
        else
        {
            // Если цель не в зоне атаки, продолжаем движение
            _currentSpeed = _speed;
            Moved?.Invoke(_currentSpeed);

            transform.position = new Vector3(
                Mathf.MoveTowards(transform.position.x, _target.position.x, _currentSpeed * Time.deltaTime),
                transform.position.y, transform.position.z);
        }
    }

    private void FlipTowardsTarget()
    {
        if (_target == null)
            return;

        if (_target.position.x > transform.position.x)
        {
            transform.rotation = _rotationRightAngle;
        }
        else if (_target.position.x < transform.position.x)
        {
            transform.rotation = _rotationLeftAngle;
        }
    }

    private void ChangeTarget()
    {
        Debug.Log("ChangeTarget");

        if (_target.TryGetComponent(out Waypoint _))
        {
            _waypoints.Reverse();
            _currentWaypoint = 0;

            _currentSpeed = _speed;

            if (_patrolDelayCoroutine != null)
            {
                StopCoroutine(_patrolDelayCoroutine);
            }

            _target = _player.transform;
        }
        else
        {
            _target = _waypoints[_currentWaypoint];
        }
    }
    
    private void Attack()
    {
        _enemyFighter.Attack();
    }

    private IEnumerator CountPatrolDelay()
    {
        _currentSpeed = 0;
        _currentWaypoint = 0;
        Moved?.Invoke(_currentSpeed);

        yield return _wait;

        _waypoints.Reverse();
        _currentSpeed = _speed;
        Moved?.Invoke(_currentSpeed);
    }
}
