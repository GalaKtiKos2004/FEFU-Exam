using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const string Jump = "Jump";

    private const KeyCode DodgeKey = KeyCode.C;
    private const KeyCode AttackKey = KeyCode.Z;

    public float Move { get; private set; }

    public event Action Jumped;
    public event Action Attacked;
    public event Action Dodged;

    private void Awake()
    {
        Move = 0;
    }

    private void Update()
    {
        Move = Input.GetAxisRaw(Horizontal);

        if (Input.GetButtonDown(Jump) || Input.GetButtonDown(Vertical))
        {
            Jumped?.Invoke();
        }

        if (Input.GetKeyDown(AttackKey))
        {
            Attacked?.Invoke();
        }

        if (Input.GetKeyDown(DodgeKey))
        {
            Dodged?.Invoke();
        }
    }
}