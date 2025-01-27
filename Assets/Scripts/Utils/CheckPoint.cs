using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private string _checkPointID;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SaveController.Instance.SaveCheckPoint(_checkPointID, transform.position);
        }
    }
}
