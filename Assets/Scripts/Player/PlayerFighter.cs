using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(GameStarter))]
[RequireComponent(typeof(PlayerDodger))]
public class PlayerFighter : Drummer
{
    private PlayerInput _input;
    private GameStarter _positionStarter;
    private PlayerDodger _dodger;

    private bool _isDodging = false;

    protected override void Awake()
    {
        base.Awake();
        _input = GetComponent<PlayerInput>();
        _dodger = GetComponent<PlayerDodger>();
        _positionStarter = GetComponent<GameStarter>();
    }

    private void OnEnable()
    {
        _input.Attacked += TryAttack;
        _dodger.DodgeBegining += OnDodgeBegining;
        _dodger.DodgeEnded += OnDodgeEnded;
    }

    private void OnDisable()
    {
        _input.Attacked -= TryAttack;
        _dodger.DodgeBegining -= OnDodgeBegining;
        _dodger.DodgeEnded -= OnDodgeEnded;
    }

    public override void TakeDamage(float damage)
    {
        if (_isDodging)
        {
            return;
        }

        base.TakeDamage(damage);
    }

    protected override void Die()
    {
        CreateNewHealth();
        _positionStarter.StartGame();
    }

    private void OnDodgeBegining() => _isDodging = true;

    private void OnDodgeEnded() => _isDodging = false;
}