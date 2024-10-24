using UnityEngine;

public class GameStarter : MonoBehaviour
{
    private Vector3 _startPosition;

    private float _startHealth;

    private void Awake()
    {
        _startPosition = transform.position;
    }

    public void StartGame()
    {
        transform.position = _startPosition;
    }
}
