using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;
using System.Threading;

namespace Omada
{
    internal class Program
    {
        const int Width = 120;
        const int Height = 30;
        const int MaxLives = 3;

        static Player player;
        static Box topBox;
        static Box bottomBox;

        static List<GameObject> objects = new List<GameObject>();
        static char[] buffer = new char[Height * Width]; 

        static int lives = MaxLives;
        static double timeAlive = 0;
        static int fps = 0;

        static void Main(string[] args)
        {
            Console.Title = "Omada";
            Console.CursorVisible = false;
            Console.SetWindowSize(Width, Height);
            Console.SetBufferSize(Width, Height);

            player = new Player(new Vector2(2, 8), 5, 5);
            topBox = new Box(new Vector2(80, 3), 5, 10, new Vector2(-1, 0), '#');
            bottomBox = new Box(new Vector2(60, 18), 5, 10, new Vector2(1, 0), '#');

            objects.Add(player);
            objects.Add(topBox);
            objects.Add(bottomBox);

            Stopwatch stopwatch = new Stopwatch();
            Stopwatch fpsWatch = new Stopwatch();
            int frames = 0;

            stopwatch.Start();
            fpsWatch.Start();

            while (lives > 0 && player.Rows > 0)
            {
                double dt = stopwatch.Elapsed.TotalSeconds;
                stopwatch.Restart();

                HandleInput();
                Update(dt);
                Render();

                frames++;
                if (fpsWatch.ElapsedMilliseconds >= 1000)
                {
                    fps = frames;
                    frames = 0;
                    fpsWatch.Restart();
                }

                Thread.Sleep(5);
            }

            Console.SetCursorPosition(0, Height - 1);
            Console.Write("Game Over. Press any key...");
            Console.ReadKey(true);
        }

        static void HandleInput()
        {
            while (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.LeftArrow)
                {
                    if (player.Position.X > 0)
                    {
                        player.Position = new Vector2(player.Position.X - 1, player.Position.Y);
                    }
                }
                else if (key == ConsoleKey.RightArrow)
                {
                    if (player.Position.X + player.Cols < Width)
                    {
                        player.Position = new Vector2(player.Position.X + 1, player.Position.Y);
                    }
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    if (player.Position.Y > 2)
                    {
                        player.Position = new Vector2(player.Position.X, player.Position.Y - 1);
                    }
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    if (player.Position.Y + player.Rows < Height)
                    {
                        player.Position = new Vector2(player.Position.X, player.Position.Y + 1);
                    }
                }
            }
        }

        static void Update(double dt)
        {
            timeAlive += dt;

            foreach (var obj in objects)
            {
                if (obj.IsActive)
                {
                    obj.Update(dt);
                }
            }

            if (CollisionChecker.CheckCollision(player, topBox))
            {
                HitPlayer();
            }

            if (CollisionChecker.CheckCollision(player, bottomBox))
            {
                HitPlayer();
            }
        }

        static void HitPlayer()
        {
            if (lives <= 0 || player.Rows <= 0)
            {
                return;
            }

            lives--;

            if (player.Rows > 0)
            {
                player.Rows -= 1;
                player.UpdateShape();
            }

            if (player.Rows <= 0)
            {
                lives = 0;
                return;
            }

            if (player.Position.Y + player.Rows >= Height)
            {
                player.Position = new Vector2(player.Position.X, Height - player.Rows - 1);
            }
            if (player.Position.Y < 2)
            {
                player.Position = new Vector2(player.Position.X, 2);
            }
        }

        static void Render()
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = ' ';
            }

            TextRenderer.DrawText(buffer, 0, 0, $"FPS: {fps}");
            TextRenderer.DrawText(buffer, 0, 1, $"Time Alive: {timeAlive:000.0} | Life: {lives}");

            foreach (var obj in objects)
            {
                if (obj.IsActive)
                {
                    obj.Render(buffer);
                }
            }

            Console.SetCursorPosition(0, 0);
            Console.Write(buffer);
        }
    }
}
