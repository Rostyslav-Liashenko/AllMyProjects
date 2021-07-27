using System;
using System.Linq;

namespace MyGameSnake.UserElement.MainCharacter
{
    public class Snake
    {
        private const char SymbolHead = '%';
        private const char OtherSegmentSnake = '*';
        private const int StandardSpeed = 200;
        public int Length { get; set; }
        public int Speed { get; set; }
        public SnakeDirection Direction { get; set; }

        public event EventHandler HitTheWall;
        public event EventHandler BiteYourself;
        
        
        private GameObject[] snake; // snake[0] it is head of snake, snake[Length - 1] it is tail of snake

        public GameObject this[int index] => snake[index];

        public Snake(int headX, int headY, int length)
        {
            Direction = SnakeDirection.Right;
            Length = length;
            Speed = StandardSpeed;
            snake = new GameObject[length];
            snake[0] = new GameObject(headX, headY, SymbolHead);
        }

        public bool IsHaveCoordinate(int x, int y) // Does any snake segment have coordinates?
        {
            return Array.Exists(snake, (o => o.X == x && o.Y == y));
        }

        public bool IsBiteYouSelf()
        {
            int tempX = snake[0].X;
            int tempY = snake[0].Y;
            int countMatches = snake.Count((ob) => ob.X == tempX && ob.Y == tempY);
            return countMatches > 1; // 1 because 1 matches it is head of snike
        }

        public bool IsRotateYourself(SnakeDirection latsDirection, SnakeDirection newDirection)
        {
            return Math.Abs((int) latsDirection - (int) newDirection) == 1;
        }
        
        public void Increment()
        {
            int offsetX = 0;
            int offsetY = 0;

            if (Length > 1)
            {
                if (snake[Length - 1].X - snake[Length - 2].X < 0) // generate tail left
                {
                    offsetX = -1;
                    offsetY = 0;
                }
                else if (snake[Length - 1].X - snake[Length - 2].X > 0) // generate tail right
                {
                    offsetX = 1;
                    offsetY = 0;
                }
                else if (snake[Length - 1].Y - snake[Length - 2].Y < 0) // generate tail up
                {
                    offsetX = 0;
                    offsetY = -1;
                }
                else if (snake[Length - 1].Y - snake[Length - 2].Y > 0) // generate tail down
                {
                    offsetX = 0;
                    offsetY = 1;
                }
            }
            else
            {
                offsetX = -1;
                offsetY = 0;
            }
            
            GameObject[] newSnake = new GameObject[snake.Length + 1];
            Array.Copy(snake,newSnake,snake.Length);
            newSnake[newSnake.Length - 1] = 
                new GameObject(snake[Length - 1].X + offsetX, snake[Length - 1].Y + offsetY, OtherSegmentSnake);
            Length = newSnake.Length;
            snake = newSnake;
        }

        public void MoveHead()
        {
            for (int i = Length - 2; i >= 0; i--) // move all part snake, without head
            {
                snake[i + 1].X = snake[i].X;
                snake[i + 1].Y = snake[i].Y;
            }
            
            switch (Direction)
            {
                case SnakeDirection.Up:
                    snake[0].Y -= 1;
                    break;
                case SnakeDirection.Down:
                    snake[0].Y += 1;
                    break;
                case SnakeDirection.Left:
                    snake[0].X -= 1;
                    break;
                case SnakeDirection.Right:
                    snake[0].X += 1;
                    break;
            }
        }

        public void OnHitTheWall()
        {
            HitTheWall?.Invoke(this,EventArgs.Empty);
        }

        public void OnBiteYourself()
        {
            BiteYourself?.Invoke(this, EventArgs.Empty);
        }
        
    }
}