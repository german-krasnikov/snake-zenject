using System;
using Gameplay;
using Modules;
using Zenject;

public class GameCycle : IInitializable
{
    public event Action OnStartGame;
    public event Action OnWin;
    public event Action OnLose;
    
    private readonly ICoinSpawner _coinSpawner;
    private readonly IDifficulty _difficulty;

    public bool IsPlaying { get; private set; }

    public GameCycle(ICoinSpawner coinSpawner, IDifficulty difficulty)
    {
        _coinSpawner = coinSpawner;
        _difficulty = difficulty;
    }

    public void Initialize()
    {
        StartGame();
    }

    public void StartGame()
    {
        IsPlaying = true;
        _difficulty.Next(out int difficulty);
        OnStartGame?.Invoke();
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