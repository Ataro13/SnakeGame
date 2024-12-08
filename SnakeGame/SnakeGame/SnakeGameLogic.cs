using SnakeGame;
using System.Collections.Generic;

namespace SnakeGame
{
    public class SnakeGameLogic : BaseGameLogic
    {
        private SnakeGameplayState gameplayState = new SnakeGameplayState();
        private ConsoleRenderer renderer;
        private readonly char snakeChar = '■';

        public SnakeGameLogic(ConsoleRenderer renderer)
        {
            this.renderer = renderer;
        }

        public override void Update(float deltaTime)
        {
            gameplayState.Update(deltaTime);
            renderer.Clear();

            // Отрисовка головы змейки
            var head = gameplayState.Body[0];
            renderer.SetPixel(head.X, head.Y, snakeChar, 1); // Используем индекс цвета 1 для змейки
            renderer.Render();
        }

        public override void OnArrowUp() => gameplayState.SetDirection(SnakeGameplayState.SnakeDir.Up);
        public override void OnArrowDown() => gameplayState.SetDirection(SnakeGameplayState.SnakeDir.Down);
        public override void OnArrowLeft() => gameplayState.SetDirection(SnakeGameplayState.SnakeDir.Left);
        public override void OnArrowRight() => gameplayState.SetDirection(SnakeGameplayState.SnakeDir.Right);

        public void GotoGameplay() => gameplayState.Reset();
    }
}
