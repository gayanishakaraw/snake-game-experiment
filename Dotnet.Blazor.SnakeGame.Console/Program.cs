using System;
using Dotnet.Blazor.SnakeGame.Core;

bool isGameOver = false;
bool isGameStarted = false;
int rows = 20;
int cols = 20;
int foodRefreshSpeed = 5000;
int snakeSpeed = 500;

Random _random = new Random();
int randomRow = _random.Next(0, rows);
int randomCol = _random.Next(0, cols);

GameState gameState = new GameState(rows, cols);
isGameOver = gameState.IsGameOver;

while (!isGameOver && true)
{
    int score = gameState.Score;
    int snakeLength = gameState.SnakeCoordinates.Count();

    Console.Clear();
    Console.WriteLine($"Score : {score}");
    Console.WriteLine($"Snake Level : {gameState.Level}");
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
        }
    }
    isGameOver = gameState.IsGameOver;
    Thread.Sleep(gameState.Speed);
}

Console.WriteLine();
Console.WriteLine("Game Over");
