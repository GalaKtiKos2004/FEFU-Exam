using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerDodger : MonoBehaviour
{
    [SerializeField] private Color _dodgeColor;
    [SerializeField] private float _cooldownTime;
    [SerializeField] private float _dodgeTime;

    private SpriteRenderer _spriteRenderer;
    private WaitForSeconds _cooldownWait;
    private WaitForSeconds _dodgeWait;
    private PlayerInput _input;
    private Color _normalColor;

    private bool _isCooldown = false;
    private bool _isDodge = false;

    public event Action DodgeBegining;
    public event Action DodgeEnded;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _input = GetComponent<PlayerInput>();
        _cooldownWait = new(_cooldownTime);
        _dodgeWait = new(_dodgeTime);
        _normalColor = _spriteRenderer.color;
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
        if (_isCooldown || _isDodge)
        {
            return;
        }

        StartCoroutine(DodgeTime());
    }

    private IEnumerator DodgeTime()
    {
        _isDodge = true;
        _spriteRenderer.color = _dodgeColor;
        DodgeBegining?.Invoke();

        yield return _dodgeWait;

        _isDodge = false;
        _spriteRenderer.color = _normalColor;
        StartCoroutine(DodgeCooldown());
    }

    private IEnumerator DodgeCooldown()
    {
        _isCooldown = true;

        yield return _cooldownWait;

        _isCooldown = false;
        DodgeEnded?.Invoke();
    }
}
