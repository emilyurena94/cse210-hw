using System;
using System.Collections.Generic;

namespace EternalQuest
{
    class Program
    {
        static List<Goal> goals = new List<Goal>();
        static int totalPoints = 0;
        static string filename = "goals.txt";

        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            while (true)
            {
                Console.WriteLine("\n===== Eternal Quest =====");
                Console.WriteLine("1. Create goal");
                Console.WriteLine("2. Record event");
                Console.WriteLine("3. View goals");
                Console.WriteLine("4. Save goals");
                Console.WriteLine("5. Load goals");
                Console.WriteLine("6. Exit");
                Console.Write("\nChoose option: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CreateGoal();
                        break;
                    case "2":
                        RecordEvent();
                        break;
                    case "3":
                        Helper.DisplayGoals(goals, totalPoints);
                        break;
                    case "4":
                        Helper.SaveGoals(goals, totalPoints, filename);
                        break;
                    case "5":
                        Helper.LoadGoals(goals, ref totalPoints, filename);
                        break;
                    case "6":
                        Console.WriteLine("\nGoodbye!");
                        return;
                    default:
                        Console.WriteLine("\nInvalid option.");
                        break;
                }
            }
        }

        static void CreateGoal()
        {
            Console.WriteLine("Goal types:");
            Console.WriteLine("1. SimpleGoal");
            Console.WriteLine("2. EternalGoal");
            Console.WriteLine("3. ChecklistGoal");
            Console.Write("\nChoose goal type: ");
            string type = Console.ReadLine();

            Console.Write("Goal name: ");
            string name = Console.ReadLine();
            Console.Write("Description: ");
            string desc = Console.ReadLine();
            Console.Write("Points per event: ");
            int points = int.Parse(Console.ReadLine());

            if (type == "1")
                goals.Add(new SimpleGoal(name, desc, points));
            else if (type == "2")
                goals.Add(new EternalGoal(name, desc, points));
            else if (type == "3")
            {
                Console.Write("\nNumber of times to complete: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("\nBonus points at completion: ");
                int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
            }
            else
                Console.WriteLine("\nInvalid option.");
        }

        static void RecordEvent()
        {
            if (goals.Count == 0)
            {
                Console.WriteLine("\nNo goals available.");
                return;
            }
            Console.WriteLine("\nChoose a goal to record:");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                goals[i].Display();
            }
            int choice = int.Parse(Console.ReadLine()) - 1;
            if (choice >= 0 && choice < goals.Count)
            {
                int points = goals[choice].RecordEvent();
                totalPoints += points;
                Console.WriteLine($"\nEvent recorded! You earned {points} points. Total: {totalPoints} pts");
            }
            else
                Console.WriteLine("\nInvalid option.");
        }
    }
}
