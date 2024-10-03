using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    public bool IsCollide(Transform checkpoint, LayerMask layerMask, Vector2 boxSize, out Collider2D hitCollider)
    {
        hitCollider = Physics2D.OverlapBox(checkpoint.position, boxSize, checkpoint.eulerAngles.z, layerMask);

        return hitCollider != null;
    }
}
