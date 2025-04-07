using Dotnet.Blazor.SnakeGame.Core;

bool isGameOver = false;
int rows = 20;
int cols = 20;

GameState gameState = new GameState(rows, cols);
isGameOver = gameState.IsGameOver;

while (!isGameOver)
{
    Console.Clear();
    Console.WriteLine($"Score : {gameState.Score}");
    Console.WriteLine($"Level : {gameState.Level}");

    if (gameState.IsGamePaused)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Game Paused! Press Space to Resume.");
        Console.ResetColor();
    }
    else
    {
        gameState.Move();

        int canvasRows = gameState.Rows;
        int canvasCols = gameState.Columns;

        Console.Write(".");
        for (int i = 0; i < canvasCols; i++)
        {
            Console.Write("_.");
        }
        Console.WriteLine();
        for (int i = 0; i < canvasRows; i++)
        {
            Console.Write("|");
            for (int j = 0; j < canvasCols; j++)
            {
                if (gameState.GameCanvas[i, j] == GridView.Snake)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("S");
                    Console.ResetColor();
                    Console.Write("|");
                }
                else if (gameState.GameCanvas[i, j] == GridView.Food)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*");
                    Console.ResetColor();
                    Console.Write("|");
                }
                else if (gameState.GameCanvas[i, j] == GridView.Wall)
                {
                    Console.Write("#|");
                }
                else
                {
                    Console.Write("_|");
                }
            }
            Console.WriteLine();
        }
    }

    if (Console.KeyAvailable)
    {
        var key = Console.ReadKey();
        switch (key.Key)
        {
            case ConsoleKey.UpArrow:
                gameState.ChangeDirection(Direction.Up);
                break;
            case ConsoleKey.DownArrow:
                gameState.ChangeDirection(Direction.Down);
                break;
            case ConsoleKey.LeftArrow:
                gameState.ChangeDirection(Direction.Left);
                break;
            case ConsoleKey.RightArrow:
                gameState.ChangeDirection(Direction.Right);
                break;
            case ConsoleKey.Spacebar:
                gameState.PauseResumeGame();
                break;
        }
    }
    isGameOver = gameState.IsGameOver;
    Thread.Sleep(gameState.Speed);
}

Console.WriteLine();
Console.WriteLine("Game Over!");
