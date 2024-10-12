using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerJumper : MonoBehaviour
{
    [SerializeField] LayerMask _groundLayer;
    [SerializeField] Vector2 _colliderSize;
    [SerializeField] ColliderDetector _detector;
    [SerializeField] private float _force;

    private Rigidbody2D _rigidbody;
    private PlayerInput _input;

    private bool _isJumping;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (_input.IsJumping && _detector.IsCollide(transform, _groundLayer, _colliderSize, out _))
        {
            _isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        TryJump();
    }

    private void TryJump()
    {
        if (_isJumping)
        {
            _rigidbody.AddForce(new Vector2(0f, _force), ForceMode2D.Impulse);
            _isJumping = false;
        }
    }
}