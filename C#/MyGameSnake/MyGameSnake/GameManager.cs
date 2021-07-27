using System;
using System.Threading;
using MyGameSnake.UserElement.Foods;
using MyGameSnake.UserElement.MainCharacter;

namespace MyGameSnake
{
    public static class GameManager
    {
        private const int Height = 23; // height of game area
        private const int Width = 50; // width of game area
        private const int TimeSleep = 700; // need for miniature
        public static uint Score;

        private static SnakeDirection ChooseDirection(ConsoleKeyInfo keyPad)
        {
            switch (keyPad.Key)
            {
                case ConsoleKey.UpArrow:
                    return SnakeDirection.Up;
                case ConsoleKey.DownArrow:
                    return SnakeDirection.Down;
                case ConsoleKey.LeftArrow:
                    return SnakeDirection.Left;
                case ConsoleKey.RightArrow:
                    return SnakeDirection.Right;
            }
            return SnakeDirection.Right; // never
        }

        private static void CheckEat(Snake snake, Food food)
        {
            if (snake[0].Equals(food)) // compare coordinate head of snake and food
                food.OnEatenFood(snake);
        }
        
        static void Main()
        {
            GameArea area = new GameArea(Height, Width);
            Food food = new Food(0, 0);
            Snake snake = new Snake(Width / 2, Height / 2, 1);
            
            food.Eat += (sender, e) =>
            {
                while (e.GrowthSnake.IsHaveCoordinate(e.EatFood.X, e.EatFood.Y))
                    e.EatFood.ChangePlace(Width,Height);
                Score++;
                e.GrowthSnake.Increment();
            };
            
            snake.HitTheWall += (sender, e) => // handler hit the wall
            {
                // in future handler is change. It is will new feature
                Console.Clear();
                Console.WriteLine("You hit the wall\nGame over\nYour score: {0}",Score);
                Thread.Sleep(TimeSleep);
                Environment.Exit(0); // end of game
            };

            snake.BiteYourself += (sender, e) => // handler biteYourSelf
            {
                Console.Clear();
                Console.WriteLine("You bit the yourself\nGame over\nYour score: {0}",Score);
                Thread.Sleep(TimeSleep);
                Environment.Exit(0); // end of game
            };
            
            food.ChangePlace(Width,Height);
            while (true)
            {
                area.Update(food);
                area.Update(snake);
                area.Draw();
                area.SetEmptySpace(snake);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo userKey = Console.ReadKey();
                    SnakeDirection newDirection = ChooseDirection(userKey);
                    if (!snake.IsRotateYourself(snake.Direction, newDirection))
                        snake.Direction = newDirection;
                }
                snake.MoveHead();
                if (snake.IsBiteYouSelf())
                    snake.OnBiteYourself(); // start event
                if (area.IsSnakeInTheWall(snake))
                    snake.OnHitTheWall();
                CheckEat(snake,food);
                Thread.Sleep(snake.Speed);
            }
        }
    }
}