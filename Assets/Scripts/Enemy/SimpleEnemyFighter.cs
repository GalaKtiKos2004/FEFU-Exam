using UnityEngine;

public class SimpleEnemyFighter : Drummer
{
    private void Update()
    {
        TryAttack();
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
}
