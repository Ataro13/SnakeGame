using System;
using System.Threading;
using SnakeGame;

class Program
{
    public static void Main()
    {
        ConsoleColor[] colors = { ConsoleColor.Gray, ConsoleColor.Green };
        ConsoleRenderer renderer = new ConsoleRenderer(colors)
        {
            width = Console.WindowWidth,
            height = Console.WindowHeight,
            bgColor = ConsoleColor.Black
        };

        SnakeGameLogic gameLogic = new SnakeGameLogic(renderer);
        ConsoleInput input = new ConsoleInput();
        gameLogic.InitializeInput(input);

        DateTime lastFrameTime = DateTime.Now;
        gameLogic.GotoGameplay();

        while (true)
        {
            DateTime frameStartTime = DateTime.Now;
            float deltaTime = (float)(frameStartTime - lastFrameTime).TotalSeconds;

            input.Update();
            gameLogic.Update(deltaTime);

            lastFrameTime = frameStartTime;
            Thread.Sleep(100); // задает скорость, с которой вызываются обновления
        }
    }
}