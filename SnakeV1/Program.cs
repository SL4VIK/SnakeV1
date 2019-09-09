using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace SnakeV1
{
    class Canvas
    {
        private readonly uint _color;
        public int ClientWidth;
        public int ClientHeigth;

        public Canvas(uint color, int clientWidth, int clientHeigth)
        {
            _color = color;
            ClientWidth = clientWidth;
            ClientHeigth = clientHeigth;
        }
        public void Render(ConsoleGraphics cg)
        {
            cg.FillRectangle(_color, 0, 0, ClientWidth, ClientHeigth);
        }
    }
    class Head
    {
        private const int size = 30;
        private readonly uint _color;
        public int _x;
        public int _y;
        public readonly Canvas _canvas;
        public Head(uint color, int x, int y, Canvas canvas)
        {
            _color = color;
            _x = x;
            _y = y;
            _canvas = canvas;
        }
        public void Move()
        {
            if (Input.IsKeyDown(Keys.KEY_D))
            {
                _x += 30;
            }
            else if (Input.IsKeyDown(Keys.KEY_A))
            {
                _x -= 30;
            }
            else if (Input.IsKeyDown(Keys.KEY_S))
            {
                _y += 30;
            }
            else if (Input.IsKeyDown(Keys.KEY_W))
            {
                _y -= 30;
            }
            if (_x > _canvas.ClientWidth - 30)
            {
                _x = 0;
            }
            if (_x < 0)
            {
                _x = _canvas.ClientWidth - 30;
            }
            if (_y > _canvas.ClientHeigth - 400)
            {
                _y = 0;
            }
            if (_y < 0)
            {
                _y = _canvas.ClientHeigth - 414;
            }
        }
        public void Render(ConsoleGraphics cg)
        {
            cg.FillRectangle(_color, _x, _y, size, size);
        }
    }
    class Apple
    {
        private const int size = 30;
        private readonly uint _color;
        public int _x;
        public int _y;
        public readonly Canvas _canvas;
        public Apple(uint color, Canvas canvas)
        {
            _color = color;
            _canvas = canvas;
        }
        public void Spawn(ConsoleGraphics cg)
        {
            Random random = new Random();
            _x = random.Next(10, _canvas.ClientWidth - 30);
            _y= random.Next(10, _canvas.ClientHeigth - 400);
            cg.FillRectangle(_color, _x, _y, size, size);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            ConsoleGraphics cg = new ConsoleGraphics();
            Canvas canvas = new Canvas(0xFFbdc1c9, cg.ClientWidth, cg.ClientWidth);
            Apple apple = new Apple(0xFF7f711, canvas);
            Head head = new Head(0xFFFF0000, 60, 0, canvas);
            while (true)
            {
                apple.Spawn(cg);
                head.Move();
                canvas.Render(cg);
                head.Render(cg);
                
                cg.FlipPages();
                Thread.Sleep(130);
            }
        }
    }
}
