using System;
using Gameplay;
using UnityEngine;
using Zenject;

public class GameCycle : IInitializable
{
    private ICoinSpawner _coinSpawner;
    public event Action OnWin;
    public event Action OnLose;
    public bool IsPlaying { get; private set; }

    public GameCycle(ICoinSpawner coinSpawner)
    {
        _coinSpawner = coinSpawner;
    }

    public void Initialize()
    {
        StartGame();
    }

    public void StartGame()
    {
        IsPlaying = true;
        _coinSpawner.CreateAt(new Vector2Int(0, 0));
    }

    public void WinGame()
    {
        IsPlaying = false;
        OnWin?.Invoke();
    }

    public void LoseGame()
    {
        IsPlaying = false;
        OnLose?.Invoke();
    }
}