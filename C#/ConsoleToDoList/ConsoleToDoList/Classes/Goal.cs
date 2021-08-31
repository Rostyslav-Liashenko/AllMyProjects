using System;

namespace ConsoleToDoList.Classes
{
    [Serializable]
    public class Goal
    {
        private const int NotFoundId = -1;
        public int Id { get; set; }
        public string Description { get; set; }

        public Goal()
        {
            Id = NotFoundId;
            Description = String.Empty;
            
        }

        public Goal(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public void ChangeDescription(string newDescription)
        {
            Description = newDescription;
        }

        public override string ToString()
        {
            return $"ID: {Id}\nDescription: {Description}";
        }
    }
}