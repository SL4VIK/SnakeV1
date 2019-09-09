using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace SnakeV1
{
    internal class Canvas
    {
        private uint _color;
        private int clientWidth;
        private int clientHeigth;

        public Canvas(uint color, int clientWidth, int clientHeigth)
        {
            _color = color;
            this.clientWidth = clientWidth;
            this.clientHeigth = clientHeigth;
        }
        public void Render(ConsoleGraphics cg)
        {
            cg.FillRectangle(_color, 0, 0, clientWidth, clientHeigth);
        }
    }
    class Head
    {
        private const int size = 30;
        public readonly uint _color;
        public int _x;
        public int _y;
        public Head(uint color, int x, int y)
        {
            _color = _color;
            _x = _x;
            _y = _y;
        }
        public void Move()
        {
            _x += 5;
        }
        public void Render(ConsoleGraphics cg)
        {
            cg.FillRectangle(_color, _x, _y, size, size);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            ConsoleGraphics cg = new ConsoleGraphics();
            Canvas canvas = new Canvas(0xFF07ed44, cg.ClientWidth, cg.ClientWidth);
            Head head = new Head(0xFFFF0000, 30, 30);
            while (true)
            {
                head.Move();
                canvas.Render(cg);
                head.Render(cg);
                
                cg.FlipPages();
            }
        }
    }
}
