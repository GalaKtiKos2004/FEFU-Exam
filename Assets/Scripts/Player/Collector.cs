using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Fighter _fighter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ICollectable collectable))
        {
            if (collectable is MedecineChest medecineChest)
            {
                if (_fighter.TryAddHealth(medecineChest.RecoverHealth) == false)
                {
                    return;
                }
            }

            collectable.Collect();
        }
    }
}
