using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public static class Helper
    {
        public static void DisplayGoals(List<Goal> goals, int totalPoints)
        {
            Console.WriteLine($"\n--- Current Goals (Total points: {totalPoints}) ---");
            if (goals.Count == 0)
                Console.WriteLine("\nNo goals yet.");
            foreach (var g in goals)
                g.Display();
            Console.WriteLine("-------------------------------------------\n");
        }

        public static void SaveGoals(List<Goal> goals, int totalPoints, string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var g in goals)
                    writer.WriteLine(g.SaveString());

                writer.WriteLine($"TOTAL|{totalPoints}");
            }
            Console.WriteLine("\nGoals saved successfully.");
        }

        public static void LoadGoals(List<Goal> goals, ref int totalPoints, string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("\nNo save file found.");
                return;
            }

            goals.Clear();

            foreach (var line in File.ReadAllLines(filename))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;  // ← ¡ESTO ERA NECESARIO!

                string[] parts = line.Split('|');

                switch (parts[0])
                {
                    case "Simple":
                        goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
                        break;

                    case "Eternal":
                        goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                        break;

                    case "Checklist":
                        goals.Add(new ChecklistGoal(
                            parts[1], parts[2], int.Parse(parts[3]),
                            int.Parse(parts[4]), int.Parse(parts[5]),
                            int.Parse(parts[6])));
                        break;

                    case "TOTAL":
                        totalPoints = int.Parse(parts[1]);
                        break;
                }
            }

            Console.WriteLine("\nGoals loaded successfully.");
        }
    }
}
