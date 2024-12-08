using System.Collections.Generic;

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

        private float timeSinceLastMove = 0f;
        private const float moveInterval = 0.2f;
        public List<Cell> Body { get; private set; } = new List<Cell> { new Cell(0, 0) };
        private SnakeDir currentDir = SnakeDir.Right;

        public void SetDirection(SnakeDir direction)
        {
            // Предотвращаем изменение на противоположное направление
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
            switch (currentDir)
            {
                case SnakeDir.Up:
                    head.Y -= 1;
                    break;
                case SnakeDir.Down:
                    head.Y += 1;
                    break;
                case SnakeDir.Left:
                    head.X -= 1;
                    break;
                case SnakeDir.Right:
                    head.X += 1;
                    break;
            }
            return head;
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

        public override void Reset()
        {
            Body.Clear();
            Body.Add(new Cell(0, 0));
            currentDir = SnakeDir.Right;
            timeSinceLastMove = 0f;
        }
    }
}