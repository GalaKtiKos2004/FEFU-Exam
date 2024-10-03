using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMover : MonoBehaviour
{
    private readonly Quaternion _rightAngle = Quaternion.Euler(Vector3.zero);
    private readonly Quaternion _leftAngle = Quaternion.Euler(0f, 180f, 0f);

    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private PlayerInput _input;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 direction = new Vector2(_input.Move * _speed, _rigidbody.velocity.y);

        Rotate(direction.x);
        _rigidbody.velocity = direction;
    }

    private void Rotate(float direction)
    {
        if (direction > 0)
        {
            transform.rotation = _rightAngle;
        }
        else
        {
            transform.rotation = _leftAngle;
        }
    }
}