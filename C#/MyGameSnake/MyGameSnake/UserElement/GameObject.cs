using System;

namespace MyGameSnake.UserElement
{
    public class GameObject : IEquatable<GameObject>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; set; }

        public GameObject(int x, int y, char ch)
        {
            X = x;
            Y = y;
            Symbol = ch;
        }

        public bool Equals(GameObject gObject)
        {
            if (gObject != null)
                return X == gObject.X && Y == gObject.Y;
            else
                return false;
        }
    }
}