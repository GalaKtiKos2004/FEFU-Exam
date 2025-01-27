public class SimpleEnemyFighter : Drummer
{
    public void Attack()
    {
        TryAttack();
    }
    protected override void Die()
    {
        Destroy(gameObject);
    }
}
