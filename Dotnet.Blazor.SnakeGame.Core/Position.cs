namespace Dotnet.Blazor.SnakeGame.Core
{
    public class Position(int row, int col) {
        public int Row { get; } = row;
        public int Col { get; } = col;
        public Position Translate(Direction direction) {
            return new Position(Row + direction.RowOffset, Col + direction.ColOffset);
        }

        public override bool Equals(object? obj) {
            if (obj is Position other) {
                return Row == other.Row && Col == other.Col;
            }
            return false;
        }

        public override int GetHashCode() {
            return HashCode.Combine(Row, Col);
        }

        public static bool operator ==(Position left, Position right) {
            return EqualityComparer<Position>.Default.Equals(left, right);
        }
        
        public static bool operator !=(Position left, Position right) {
            return !(left == right);
        }
    }
}