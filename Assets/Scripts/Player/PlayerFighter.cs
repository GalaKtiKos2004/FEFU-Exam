using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(GameStarter))]
public class PlayerFighter : Drummer
{
    private PlayerInput _input;

    private GameStarter _starter;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _starter = GetComponent<GameStarter>();
    }

    private void Update()
    {
        if (_input.IsAttack)
        {
            Attack();
        }
    }

    protected override void Die()
    {
        _starter.StartGame();
        base.Die();
    }
}
