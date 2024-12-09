using System;
using UnityEngine;

public class Health
{
    public event Action Died;
    public event Action<float, float> Changed;

    public Health(float maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
    }

    public float MaxHealth { get; private set; }

    public float CurrentHealth { get; private set; }

    public void TakeDamage(float damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth);

        if (CurrentHealth == 0)
        {
            Died?.Invoke();
        }
    }

    public bool TryTreated(float recoverHealth)
    {
        if (CurrentHealth + recoverHealth > MaxHealth)
        {
            return false;
        }
        else
        {
            CurrentHealth += recoverHealth;
            Changed?.Invoke(CurrentHealth, MaxHealth);
            return true;
        }
    }
}