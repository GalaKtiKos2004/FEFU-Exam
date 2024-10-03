using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerJumper : MonoBehaviour
{
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
        if (_input.IsJumping)
        {
            _isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        if (_isJumping)
        {
            Debug.Log(1);

            _rigidbody.AddForce(new Vector2(0f, _force), ForceMode2D.Impulse);
            _isJumping = false;
        }
    }
}