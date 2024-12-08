using System;
using System.Collections.Generic;

namespace SnakeGame
{
    public interface IArrowListener
    {
        void OnArrowUp();
        void OnArrowDown();
        void OnArrowLeft();
        void OnArrowRight();
    }

    public class ConsoleInput
    {
        private List<IArrowListener> arrowListeners = new List<IArrowListener>();

        public void Subscribe(IArrowListener listener)
        {
            arrowListeners.Add(listener);
        }

        public void Update()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(intercept: true).Key;

                foreach (var listener in arrowListeners)
                {
                    switch (key)
                    {
                        case ConsoleKey.W:
                        case ConsoleKey.UpArrow:
                            listener.OnArrowUp();
                            break;
                        case ConsoleKey.S:
                        case ConsoleKey.DownArrow:
                            listener.OnArrowDown();
                            break;
                        case ConsoleKey.A:
                        case ConsoleKey.LeftArrow:
                            listener.OnArrowLeft();
                            break;
                        case ConsoleKey.D:
                        case ConsoleKey.RightArrow:
                            listener.OnArrowRight();
                            break;
                    }
                }
            }
        }
    }
}