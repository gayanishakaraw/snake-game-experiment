namespace Dotnet.Blazor.SnakeGame.Core
{
    public class Direction(int rowOffset, int colOffset) {
        public readonly static Direction Up = new Direction(-1, 0);
        public readonly static Direction Down = new Direction(1, 0);
        public readonly static Direction Left = new Direction(0, -1);
        public readonly static Direction Right = new Direction(0, 1);

        public int RowOffset { get; } = rowOffset;
        public int ColOffset { get; } = colOffset;

        public Direction Opposite() {
            return new Direction(-RowOffset, -ColOffset);
        }

        public override bool Equals(object? obj) {
            if (obj is Direction other) {
                return RowOffset == other.RowOffset && ColOffset == other.ColOffset;
            }
            return false;
        }
        
        public override int GetHashCode() {
            return HashCode.Combine(RowOffset, ColOffset);
        }

        public static bool operator ==(Direction left, Direction right) {
            return EqualityComparer<Direction>.Default.Equals(left, right);
        }

        public static bool operator !=(Direction left, Direction right) {
            return !(left == right);
        }
    }
}