using System;
using MyGameSnake.UserElement;
using MyGameSnake.UserElement.MainCharacter;

namespace MyGameSnake
{
    public class GameArea
    {
        private const char EmptySpace = ' ';
        private const char SymbolWall = '#';
        public int Row { get; set; }
        public int Column { get; set; }
        private char[,] matrix;


        private void SetObject(GameObject gObject)
        {
            matrix[gObject.Y, gObject.X] = gObject.Symbol;
        }

        public void SetEmptySpace(Snake snake)
        {
            for (int i = 0; i < snake.Length; i++)
                matrix[snake[i].Y, snake[i].X] = EmptySpace;
        }
        
        private void FillEmptySpace()
        {
            for (int i = 0; i < Row; i++)
                for (int j = 0; j < Column; j++)
                    matrix[i, j] = EmptySpace;
        }


        public bool IsSnakeInTheWall(Snake snake)
        {
            return snake[0].X == 0 || snake[0].X == Column || snake[0].Y == 0 || snake[0].Y == Row;
        }
        
        private void BuildWall(bool isVertical, int nomWall)
        {
            int tmp = isVertical ? Row : Column;
            for (int i = 0; i < tmp; i++)
            {
                if (isVertical) // for vertical wall
                    matrix[i, nomWall] = SymbolWall;
                else // for horizontal wall
                    matrix[nomWall, i] = SymbolWall;
            }
        }
        
        public GameArea(int row, int column)
        {
            Row = row;
            Column = column;
            matrix = new char[row, column];
            FillEmptySpace();
            BuildWall(true, 0); // left vertical
            BuildWall(true, Column - 1); // right vertical
            BuildWall(false, 0); // top horizontal
            BuildWall(false, Row - 1); // bottom horizontal
        }

        public void Draw()
        {
            Console.Clear();
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                    Console.Write(matrix[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine("score:{0}",GameManager.Score);
        }
        
        public void Update(params GameObject[] gObjects)
        {
            foreach (var gObject in gObjects)
                SetObject(gObject);
        }

        public void Update(Snake snake)
        {
            for (int i = 0; i < snake.Length; i++)
                SetObject(snake[i]);
        }
        
    }
}