using System;

namespace SnakeGame
{
    public class ConsoleRenderer
    {
        public int width { get; set; }
        public int height { get; set; }

        private const int MaxColors = 8;
        private readonly ConsoleColor[] _colors;
        private readonly char[,] _pixels;
        private readonly byte[,] _pixelColors;
        private readonly int _maxWidth;
        private readonly int _maxHeight;

        public ConsoleColor bgColor { get; set; }

        public char this[int w, int h]
        {
            get { return _pixels[w, h]; }
            set { _pixels[w, h] = value; }
        }

        public ConsoleRenderer(ConsoleColor[] colors)
        {
            if (colors.Length > MaxColors)
            {
                var tmp = new ConsoleColor[MaxColors];
                Array.Copy(colors, tmp, tmp.Length);
                colors = tmp;
            }

            _colors = colors;

            _maxWidth = 80; 
            _maxHeight = 25; 

            _pixels = new char[_maxWidth, _maxHeight];
            _pixelColors = new byte[_maxWidth, _maxHeight];
        }

        public void SetPixel(int w, int h, char val, byte colorIdx)
        {
            if (w >= 0 && w < _maxWidth && h >= 0 && h < _maxHeight)
            {
                _pixels[w, h] = val;
                _pixelColors[w, h] = colorIdx;
            }
        }

        public void Render()
        {
            Console.Clear();
            Console.BackgroundColor = bgColor;

            for (var w = 0; w < _maxWidth; w++)
                for (var h = 0; h < _maxHeight; h++)
                {
                    var colorIdx = _pixelColors[w, h];
                    var color = _colors[colorIdx];
                    var symbol = _pixels[w, h];

                    if (symbol == 0 || color == bgColor)
                        continue;

                    Console.ForegroundColor = color;
                    Console.SetCursorPosition(w, h);
                    Console.Write(symbol);
                }

            Console.ResetColor();
            Console.CursorVisible = false;
        }

        public void DrawString(string text, int atWidth, int atHeight, ConsoleColor color)
        {
            var colorIdx = Array.IndexOf(_colors, color);
            if (colorIdx < 0)
                return;

            for (int i = 0; i < text.Length; i++)
            {
                if (atWidth + i < _maxWidth)
                {
                    _pixels[atWidth + i, atHeight] = text[i];
                    _pixelColors[atWidth + i, atHeight] = (byte)colorIdx;
                }
            }
        }

        public void Clear()
        {
            for (int w = 0; w < _maxWidth; w++)
                for (int h = 0; h < _maxHeight; h++)
                {
                    _pixelColors[w, h] = 0;
                    _pixels[w, h] = (char)0;
                }
        }
    }
}