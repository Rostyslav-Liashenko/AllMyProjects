using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml.Serialization;
using ConsoleToDoList.Classes;

namespace ConsoleToDoList
{
    static class ToDoList
    { 
        static void PrintCommandOfTable()
        {
            Console.Clear();
            Console.WriteLine("add - add new goal");
            Console.WriteLine("del - delete goal");
            Console.WriteLine("edt - edit goal");
            Console.WriteLine("prn - print of goals in all tables");
            Console.WriteLine("mv - move to the next table, in last it delete");
            Console.WriteLine("ext - exit");
        }

        static void PrintOfTables()
        {
            Console.WriteLine("Choose the board: \n1 - To do \n2 - Completed");
        }
        
        static string GetUserDescription()
        {
            Console.WriteLine("Input the description of goal:");
            string description = Console.ReadLine();
            return description;
        }

        static int GetUserId(Board board)
        {
            Console.WriteLine(board);
            Console.WriteLine("Input the id of goal: ");
            int targetId = Convert.ToInt32(Console.ReadLine());
            return targetId;
        }

        static void SaveInFile(List<Board> boards)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Board>));
            using FileStream fs = new FileStream("save.xml", FileMode.OpenOrCreate);
                formatter.Serialize(fs, boards);
        }

        static bool IsLoadFromFile(ref List<Board> boards)
        {
            if (File.Exists("save.xml"))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Board>));
                using FileStream fs = new FileStream("save.xml", FileMode.Open);
                boards = (List<Board>) formatter.Deserialize(fs);
                return true;
            }
            return false;
        }
        
        static bool CallMenu(List<Board> boards)
        {
            PrintOfTables();
            Console.WriteLine("\nInput the number of board:");
            int numOfBoard;
            try
            {
                numOfBoard = Convert.ToInt32(Console.ReadLine()) - 1;
            }
            catch (FormatException)
            {
                Console.WriteLine("You entered not a number\n Main menu after 5 seconds");
                Thread.Sleep(5000);
                return true; // new iterator loop. goto in begin CallMenu
            }
            PrintCommandOfTable();
            Console.WriteLine("Input your command: ");
            string choose = Console.ReadLine();
            switch (choose)
            {
                case "add":
                    boards[numOfBoard].AddGoal(GetUserDescription());
                    break;
                case "del":
                    if (!boards[numOfBoard].IsDeleteGoal(GetUserId(boards[numOfBoard])))
                        Console.WriteLine("Not possible to delete the goal...");
                    break;
                case "edt":
                    int userId = GetUserId(boards[numOfBoard]);
                    string newDescription = GetUserDescription();
                    if (!boards[numOfBoard].IsChangeGoal(userId, newDescription))
                        Console.WriteLine("Not possible to change the goal...");
                    break;
                case "mv":
                    int targetId = GetUserId(boards[numOfBoard]);
                    Goal findGoal = boards[numOfBoard].FindGoal(targetId);
                    if (findGoal != null)
                    {
                        if (numOfBoard + 1 == boards.Count) // if last table have this goal, delete this goal
                            boards[numOfBoard].IsDeleteGoal(findGoal.Id);
                        else
                        {
                            boards[numOfBoard + 1].AddGoal(findGoal.Description);
                            boards[numOfBoard].IsDeleteGoal(findGoal.Id);
                        }
                    }
                    else 
                        Console.WriteLine("Goal not found...");
                    break;
                case "prn":
                    foreach (var board in boards)
                    {
                        Console.WriteLine($"---#{board.Name}---");
                        Console.WriteLine(board);
                    }
                    break;
                case "ext":
                    SaveInFile(boards);
                    Console.WriteLine("Successfully write in file");
                    return false;
                default:
                    Console.WriteLine("Not found a command");
                    break;
            }
            return true;
        }
        
        static void Main()
        {
            List<Board> boards = null;
            if (!IsLoadFromFile(ref boards))
            {
                boards = new List<Board>(2)
                {
                    new ("To do"), 
                    new ("Completed")
                };
            }
            while (CallMenu(boards))
            { }
        }
    }
}