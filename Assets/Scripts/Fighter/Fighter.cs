using UnityEngine;

public abstract class Fighter : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;

    private Health _health;

    private void Awake()
    {
        _health = new Health(_maxHealth);
    }

    private void OnEnable()
    {
        _health.Died += Die;
    }

    private void OnDisable()
    {
        _health.Died -= Die;
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
    }

    public bool TryAddHealth(float recoverHealth)
    {
        if (_health.TryAddHealth(recoverHealth))
        {
            return true;
        }

        return false;
    }

    protected virtual void Attack() { }

    protected virtual void Die() { }
}
