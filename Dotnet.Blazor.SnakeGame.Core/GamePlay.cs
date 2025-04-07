namespace Dotnet.Blazor.SnakeGame.Core;

public class GamePlay
{
    public int Rows { get; set; }
    public int Cols { get; set; }
    public int Speed { get; set; }
    public int Score { get; set; }
    public bool IsGameOver { get; set; }
    public bool IsStarted { get; set; }

    public GameState GameState { get; set; }
    public GamePlay(int rows, int cols, int speed = 100)
    {
        Rows = rows;
        Cols = cols;
        Speed = speed;
        Score = 0;
        IsGameOver = false;
        IsStarted = false;

        GameState = new GameState(rows, cols);
    }
    
    public void StartGame()
    {
        IsStarted = true;
        GameState.IsGameStarted = true;
    }

    public void StopGame()
    {
        IsStarted = false;
        GameState.IsGameStarted = false;
    }

    public void RestartGame()
    {
        GameState = new GameState(Rows, Cols);
        Score = 0;
        IsGameOver = false;
        IsStarted = false;
    }
    public GameState GetGameState()
    {
        return GameState;
    }
}
