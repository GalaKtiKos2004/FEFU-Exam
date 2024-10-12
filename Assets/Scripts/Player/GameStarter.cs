using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private DeathChecker _deathChecker;

    private Vector3 _startPosition;

    private void Awake()
    {
        _startPosition = transform.position;
    }

    private void OnEnable()
    {
        _deathChecker.Death += StartGame;
    }

    private void OnDisable()
    {
        _deathChecker.Death -= StartGame;
    }

    private void StartGame()
    {
        transform.position = _startPosition;
    }
}
