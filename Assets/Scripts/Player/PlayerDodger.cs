using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerDodger : MonoBehaviour
{
    [SerializeField] private float _cooldownTime;

    private WaitForSeconds _wait;
    private PlayerInput _input;

    private bool _isCooldown = false;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _wait = new(_cooldownTime);
    }

    private void OnEnable()
    {
        _input.Dodged += Dodge;
    }

    private void OnDisable()
    {
        _input.Dodged -= Dodge;
    }

    private void Dodge()
    {
        if (_isCooldown)
        {
            return;
        }
    }

    private IEnumerator DodgeCooldown()
    {
        _isCooldown = true;

        yield return _wait;

        _isCooldown = false;
    }
}
