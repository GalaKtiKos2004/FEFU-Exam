using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(GameStarter))]
public class PlayerFighter : Drummer
{
    private PlayerInput _input;
    private GameStarter _positionStarter;

    protected override void Awake()
    {
        base.Awake();
        _input = GetComponent<PlayerInput>();

        _positionStarter = GetComponent<GameStarter>();
    }

    private void OnEnable()
    {
        _input.Attacked += TryAttack;
    }

    private void OnDisable()
    {
        _input.Attacked -= TryAttack;
    }

    protected override void Die()
    {
        CreateNewHealth();
        _positionStarter.StartGame();
    }
}