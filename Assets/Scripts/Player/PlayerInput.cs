using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const string Jump = "Jump";
    
    public float Move {  get; private set; }
    public bool IsJumping {  get; private set; }

    private void Awake()
    {
        Move = 0;
        IsJumping = false;
    }

    private void Update()
    {
        Move = Input.GetAxisRaw(Horizontal);
        IsJumping = Convert.ToBoolean(Input.GetButtonDown(Jump) || Input.GetButtonDown(Vertical));
    }
}
