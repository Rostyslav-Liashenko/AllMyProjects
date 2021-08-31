using System;
using System.Collections.Generic;
namespace ConsoleToDoList.Classes
{
    public class Board
    {
        const int StandardSize = 3;
        
        public string Name { get; set; }
        public List<Goal> Goals; //  public need for serialization
        
        public Board()
        { }
        public Board(string name)
        {
            Name = name;
            Goals = new List<Goal>(StandardSize);
        }

        public void AddGoal(string description)
        {
            Goal goal = new Goal(GenerateRandomId(),description);
            Goals.Add(goal);
        }
        
        public bool IsChangeGoal(int targetId, string newDescription)
        {
            Goal targetGoal = FindGoal(targetId);
            if (targetGoal != null)
            {
                targetGoal.ChangeDescription(newDescription);
                return true;
            }
            return false;
        }

        public bool IsDeleteGoal(int targetId)
        {
            Goal targetGoal = FindGoal(targetId);
            if (targetGoal != null)
            {
                Goals.Remove(targetGoal);
                return true;
            }
            return false;
        }
        
        public Goal FindGoal(int targetId)
        {
            foreach (var goal in Goals)
                if (goal.Id == targetId)
                    return goal;
            return null;
        }

        private int GenerateRandomId()
        {
            const int beginRange = 1000;
            const int endRange = 9999;
            Random rand = new Random();
            int newId = rand.Next(beginRange, endRange);
            while (FindGoal(newId) != null)
                newId = rand.Next(beginRange, endRange);
            return newId;
        }
        
        public override string ToString()
        {
            string str = String.Empty;
            foreach (var goal in Goals)
                str += goal + "\n";
            return str;
        }
    }
}