using System;
using System.Collections.Generic;
using System.Numerics;

namespace Omada
{
    public class Program
    {
        const int MaxLives = 3;
        const double TargetFps = 300;

        static Player Player;
        static Box TopBox;
        static Circle Circle;

        static List<GameObject> Objects = new List<GameObject>();
        static char[] Buffer = new char[GameParameters.ScreenHeight * GameParameters.ScreenWidth];

        static int Lives = MaxLives;
        static double TimeAlive = 0;
        static double Fps = 0;
        static double TargetDeltaTime = 1.0 / TargetFps;

        static void Main(string[] args)
        {
            Console.Title = "Omada";
            Console.CursorVisible = false;
            Console.SetWindowSize(GameParameters.ScreenWidth, GameParameters.ScreenHeight);
            Console.SetBufferSize(GameParameters.ScreenWidth, GameParameters.ScreenHeight);

            Player = new Player(new Vector2(2, 8), new Vector2(5, 5));
            TopBox = new Box(new Vector2(80, 3), new Vector2(10, 5), new Vector2(-60, 0), '#');
            Circle = new Circle(new Vector2(60, 18), 3, new Vector2(60, 0), 'O');

            Objects.Add(Player);
            Objects.Add(TopBox);
            Objects.Add(Circle);

            DateTime startTime = DateTime.Now;
            double previousTime = 0;
            double currentTime = 0;
            double deltaTime = 0;

            while (Lives > 0 && Player.IsActive)
            {
                currentTime = (DateTime.Now - startTime).TotalSeconds;
                deltaTime += currentTime - previousTime;
                previousTime = currentTime;

                if (deltaTime < TargetDeltaTime)
                {
                    continue;
                }

                Fps = Math.Round(1.0 / deltaTime);

                HandleInput();
                Update((float)deltaTime);
                Render();
                deltaTime = 0;
                Lives = Player.Lives;
            }

            Console.SetCursorPosition(0, GameParameters.ScreenHeight - 1);
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
                    if (Player.Position.X > 0)
                    {
                        Player.Position = new Vector2(Player.Position.X - 1, Player.Position.Y);
                    }
                }
                else if (key == ConsoleKey.RightArrow)
                {
                    if (Player.Position.X + Player.Size.X < GameParameters.ScreenWidth)
                    {
                        Player.Position = new Vector2(Player.Position.X + 1, Player.Position.Y);
                    }
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    if (Player.Position.Y > 2)
                    {
                        Player.Position = new Vector2(Player.Position.X, Player.Position.Y - 1);
                    }
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    if (Player.Position.Y + Player.Size.Y < GameParameters.ScreenHeight)
                    {
                        Player.Position = new Vector2(Player.Position.X, Player.Position.Y + 1);
                    }
                }
            }
        }

        static void Update(float deltaTime)
        {
            TimeAlive += deltaTime;

            foreach (var obj in Objects)
            {
                if (obj.IsActive)
                {
                    obj.Update(deltaTime);
                }
            }

            foreach (var obj in Objects)
            {
                if (!obj.IsActive)
                {
                    continue;
                }

                if (obj is ICollider collidableA)
                {
                    foreach (var other in Objects)
                    {
                        if (!other.IsActive || other == obj)
                        {
                            continue;
                        }

                        if (other is ICollider collidableB && collidableA.IsCollidingWith(collidableB))
                        {
                            if (collidableB is IColliderCallback callbackB)
                            {
                                callbackB.OnCollision(collidableA);
                            }

                            if (collidableA is IColliderCallback callbackA)
                            {
                                callbackA.OnCollision(collidableB);
                            }
                        }
                    }
                }
            }
        }

        static void Render()
        {
            for (int i = 0; i < Buffer.Length; i++)
            {
                Buffer[i] = ' ';
            }

            TextRenderer.DrawText(Buffer, 0, 0, $"FPS: {Fps}");
            TextRenderer.DrawText(Buffer, 0, 1, $"Time Alive: {TimeAlive:000.0} | Life: {Lives}");

            foreach (var obj in Objects)
            {
                if (obj.IsActive)
                {
                    obj.Render(Buffer);
                }
            }

            Console.SetCursorPosition(0, 0);
            Console.Write(Buffer);
        }
    }
}
