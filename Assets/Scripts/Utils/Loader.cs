using UnityEngine;

public class Loader : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private void Start()
    {
        Load();
    }

    public void Load()
    {
        Vector3? lastPosition = SaveController.Instance.LoadLastCheckPointPosition();
        if (lastPosition.HasValue)
        {
            _player.position = lastPosition.Value;
            Debug.Log($"Loaded player position: {lastPosition}");
        }
    }
}
