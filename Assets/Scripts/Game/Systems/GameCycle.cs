using System;
using Zenject;

public class GameCycle : IInitializable
{
    public event Action OnWin;
    public event Action OnLose;
    public bool IsPlaying { get; private set; }

    public void Initialize()
    {
        StartGame();
    }

    public void StartGame()
    {
        IsPlaying = true;
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