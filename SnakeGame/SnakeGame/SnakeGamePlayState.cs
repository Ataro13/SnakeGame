using System;
using System.Collections.Generic;

public class SnakeGameplayState : BaseGameState
{
    public struct Cell
    {
        public int X, Y;
        public Cell(int x, int y) => (X, Y) = (x, y);
    }

    public enum SnakeDir { Up, Down, Left, Right }

    private List<Cell> Body = new List<Cell>();
    private SnakeDir currentDir = SnakeDir.Right;
    private float timeSinceLastMove = 0f;
    private const float moveInterval = 0.2f; // Интервал времени для перемещения (200 мс)

    public override void Reset()
    {
        Body.Clear();
        currentDir = SnakeDir.Right;
        Body.Add(new Cell(0, 0));
        timeSinceLastMove = 0f;
    }

    public void SetDirection(SnakeDir direction)
    {
        currentDir = direction;
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

        // Обновляем положение, когда прошло нужное кол-во времени
        if (timeSinceLastMove >= moveInterval)
        {
            timeSinceLastMove = 0f;
            Cell head = Body[0];
            Cell nextCell = ShiftTo(head);
            Body.RemoveAt(Body.Count - 1);
            Body.Insert(0, nextCell);

            Console.WriteLine($"Head Position: X = {Body[0].X}, Y = {Body[0].Y}");
        }
    }
}
