namespace SnakeGame
{
    using Shared;
    using System;
    using System.Threading;

    internal class Program
    {
        static void Main()
        {
            const float targetFrameTime = 1f / 60f; // Определяем targetFrameTime 

            var gameLogic = new SnakeGameLogic();
            var palette = gameLogic.CreatePalette();
            var renderer0 = new ConsoleRenderer(palette);
            var renderer1 = new ConsoleRenderer(palette);
            var input = new ConsoleInput();
            gameLogic.InitializeInput(input);

            var prevRenderer = renderer0;
            var currRenderer = renderer1;
            var lastFrameTime = DateTime.Now;

            while (true)
            {
                var frameStartTime = DateTime.Now;
                float deltaTime = (float)(frameStartTime - lastFrameTime).TotalSeconds;
                input.Update();

                gameLogic.DrawNewState(deltaTime, currRenderer);
                lastFrameTime = frameStartTime;

                if (!prevRenderer.Equals(currRenderer))
                {
                    currRenderer.Render();
                    var tmp = prevRenderer;
                    prevRenderer = currRenderer;
                    currRenderer = tmp;
                    currRenderer.Clear(); // Очищаю буфер только после рендеринга
                }

                var nextFrameTime = frameStartTime + TimeSpan.FromSeconds(targetFrameTime);
                var endFrameTime = DateTime.Now;
                if (nextFrameTime > endFrameTime)
                {
                    Thread.Sleep((int)(nextFrameTime - endFrameTime).TotalMilliseconds);
                }
            }
        }
    }
}