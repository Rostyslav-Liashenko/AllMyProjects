namespace MyGameSnake.UserElement.MainCharacter
{
    public enum SnakeDirection
    {
        Right = 1,
        Left,
        Up = 6, // it's magic number need for trick in method Snake.IsRotateYourself; sorry :)
        Down
    }
}