
namespace SnakeGame
{
    public class SnakeGameplayState : BaseGameState
    {
        public struct Cell
        {
            public int X, Y;
            public Cell(int x, int y) => (X, Y) = (x, y);
        }

        public enum SnakeDir { Up, Down, Left, Right }

        public List<Cell> Body { get; private set; } = new List<Cell>();
        private SnakeDir currentDir = SnakeDir.Right;
        private float timeSinceLastMove = 0f;
        private const float moveInterval = 0.2f; // Интервал времени для перемещения (200 мс)

        public override void Reset()
        {
            Body.Clear();
            currentDir = SnakeDir.Right; // По умолчанию, идёт вправо
            Body.Add(new Cell(0, 0));
            timeSinceLastMove = 0f;
        }

        public void SetDirection(SnakeDir direction)
        {
            if ((direction == SnakeDir.Up && currentDir != SnakeDir.Down) ||
                (direction == SnakeDir.Down && currentDir != SnakeDir.Up) ||
                (direction == SnakeDir.Left && currentDir != SnakeDir.Right) ||
                (direction == SnakeDir.Right && currentDir != SnakeDir.Left))
            {
                currentDir = direction;
            }
        }

        private Cell ShiftTo(Cell head)
        {
            Cell nextCell = head;
            switch (currentDir)
            {
                case SnakeDir.Up:
                    nextCell.Y -= 1;
                    break;
                case SnakeDir.Down:
                    nextCell.Y += 1;
                    break;
                case SnakeDir.Left:
                    nextCell.X -= 1;
                    break;
                case SnakeDir.Right:
                    nextCell.X += 1;
                    break;
            }
            return nextCell;
        }

        public override void Update(float deltaTime)
        {
            timeSinceLastMove += deltaTime;

            if (timeSinceLastMove >= moveInterval)
            {
                timeSinceLastMove = 0f;
                Cell head = Body[0];
                Cell nextCell = ShiftTo(head);
                Body.Insert(0, nextCell);
                Body.RemoveAt(Body.Count - 1);
            }
        }
    }
}
