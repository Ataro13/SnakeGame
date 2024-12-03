

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
    private float timeToMove = 0.2f;

    public override void Reset()
    {
        Body.Clear();
        currentDir = SnakeDir.Right; // Устанавливаем начальное направление вправо
        Body.Add(new Cell(0, 0)); // Начальные координаты головы змейки
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
            case SnakeDir.Up: nextCell.Y -= 1; break;
            case SnakeDir.Down: nextCell.Y += 1; break;
            case SnakeDir.Left: nextCell.X -= 1; break;
            case SnakeDir.Right: nextCell.X += 1; break;
        }
        return nextCell;
    }

    public override void Update(float deltaTime)
    {
        timeToMove -= deltaTime;
        if (timeToMove > 0) return;

        timeToMove = 0.2f; // Обновление каждые 200 мс
        Cell head = Body[0];
        Cell nextCell = ShiftTo(head);
        Body.RemoveAt(Body.Count - 1);
        Body.Insert(0, nextCell);

        Console.WriteLine($"Head Position: X = {Body[0].X}, Y = {Body[0].Y}");
    }
}
