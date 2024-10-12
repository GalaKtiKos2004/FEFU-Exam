using System;
using UnityEngine;

public class Health
{
    private float _maxHealth;

    public event Action Died;

    public Health(float maxHealth)
    {
        _maxHealth = maxHealth;
    }

    public float CurrentHealth { get; private set; }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            Died?.Invoke();
        }
    }

    public bool TryAddHealth(float recoverHealth)
    {
        if (CurrentHealth == _maxHealth)
        {
            return false;
        }
        else
        {
            CurrentHealth = Mathf.Clamp(recoverHealth, CurrentHealth, _maxHealth);
            return true;
        }
    }
}
