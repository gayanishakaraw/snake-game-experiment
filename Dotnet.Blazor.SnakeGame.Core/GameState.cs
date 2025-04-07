namespace Dotnet.Blazor.SnakeGame.Core
{
    public class GameState
    {
        public int Rows { get; }
        public int Columns { get; }
        public GridView[,] GameCanvas { get; }
        public Direction Dir { get; private set; }
        public int Score { get; set; } = 0;
        public bool IsGameOver { get; set; } = false;
        public bool IsGameStarted { get; set; } = false;
        public int Level { get; private set; } = 1;
        public int Speed { get; private set; } = 500;

        public bool IsGamePaused { get; set; } = false;

        private readonly Random _random = new Random();
        private readonly LinkedList<Position> _snakeCoordinates = new LinkedList<Position>();

        public GameState(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            GameCanvas = new GridView[rows, columns];
            Dir = Direction.Right;

            RenderSnake();
            RenderFood();
        }

        public Position? Head => _snakeCoordinates?.First?.Value;
        public Position? Tail => _snakeCoordinates?.Last?.Value;
        public IEnumerable<Position> SnakeCoordinates => _snakeCoordinates;

        public void ChangeDirection(Direction direction)
        {
            if (Dir.Opposite() != direction)
            {
                Dir = direction;
            }
        }

        public void PauseResumeGame()
        {
            IsGamePaused = !IsGamePaused;
        }

        public void Move()
        {
            Position head = Head?.Translate(Dir);
            GridView hit = WillHitOn(head);

            Level = Score switch
            {
                < 5 => 1,
                < 10 => 2,
                < 20 => 3,
                < 30 => 4,
                _ => 5
            };
            Speed = Level switch
            {
                1 => 500,
                2 => 400,
                3 => 300,
                4 => 200,
                _ => 100
            };

            if (hit == GridView.Wall || hit == GridView.Snake)
            {
                IsGameOver = true;
                return;
            }
            else if (hit == GridView.Empty)
            {
                RemoveTail();
                AddHead(head);
            }
            else if (hit == GridView.Food)
            {
                AddHead(head);
                Score++;
                RenderFood();
            }
        }

        private void RenderSnake()
        {
            int row = Rows / 3;
            for (int col = 1; col <= 3; col++)
            {
                GameCanvas[row, col] = GridView.Snake;
                _snakeCoordinates.AddFirst(new Position(row, col));
            }
        }

        private IEnumerable<Position> EmptyPositions()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    if (GameCanvas[row, col] == GridView.Empty)
                    {
                        yield return new Position(row, col);
                    }
                }
            }
        }

        private void RenderFood()
        {
            List<Position> emptyPositions = EmptyPositions().ToList();
            if (emptyPositions.Count == 0)
            {
                return;
            }
            int index = _random.Next(0, emptyPositions.Count);
            Position foodPosition = emptyPositions[index];
            GameCanvas[foodPosition.Row, foodPosition.Col] = GridView.Food;
        }

        private void AddHead(Position position)
        {
            _snakeCoordinates.AddFirst(position);
            GameCanvas[position.Row, position.Col] = GridView.Snake;
        }

        private void RemoveTail()
        {
            Position tail = _snakeCoordinates?.Last?.Value;
            _snakeCoordinates.RemoveLast();
            GameCanvas[tail.Row, tail.Col] = GridView.Empty;
        }

        private bool IsAWall(Position position)
        {
            return position.Row < 0 || position.Row >= Rows || position.Col < 0 || position.Col >= Columns;
        }

        private GridView WillHitOn(Position headPosition)
        {
            if (IsAWall(headPosition))
            {
                return GridView.Wall;
            }

            if (headPosition == Tail)
            {
                return GridView.Empty;
            }

            if (GameCanvas[headPosition.Row, headPosition.Col] == GridView.Snake)
            {
                return GridView.Snake;
            }

            if (GameCanvas[headPosition.Row, headPosition.Col] == GridView.Food)
            {
                return GridView.Food;
            }

            return GameCanvas[headPosition.Row, headPosition.Col];
        }
    }
}
