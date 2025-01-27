using System;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private Loader _loader;
    [SerializeField] private SaveController _saveController;

    private void Awake()
    {
        _saveController.InitializeStartPosition(transform.position);
    }

    public void StartGame()
    {
        _loader.Load();
    }
}
