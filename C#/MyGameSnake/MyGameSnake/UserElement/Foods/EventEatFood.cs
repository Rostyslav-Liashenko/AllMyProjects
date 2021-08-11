using System;
using MyGameSnake.UserElement.MainCharacter;

namespace MyGameSnake.UserElement.Foods
{
    public class EventEatFood : EventArgs
    {
        public Apple EatApple { get; set; }
        public Snake GrowthSnake { get; set; }
    }
}