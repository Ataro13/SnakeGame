using System;
using System.Threading;

public class Program
{
    public static void Main()
    {
        SnakeGameLogic gameLogic = new SnakeGameLogic();
        ConsoleInput input = new ConsoleInput();
        gameLogic.InitializeInput(input);

        DateTime lastFrameTime = DateTime.Now;
        gameLogic.GotoGameplay();

        while (true)
        {
            DateTime frameStartTime = DateTime.Now;
            float deltaTime = (float)(frameStartTime - lastFrameTime).TotalSeconds;

            input.Update(); // Обработка ввода от пользователя
            gameLogic.Update(deltaTime); // Обновление состояния игры

            lastFrameTime = frameStartTime;

            Thread.Sleep(10); // Ждем немного перед следующим циклом
        }
    }
}
