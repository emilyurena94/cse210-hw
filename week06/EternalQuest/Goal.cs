using System;

namespace EternalQuest
{
    // ================================
    //           GOAL CLASSES
    // ================================
    public abstract class Goal
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }

        public Goal(string name, string description, int points)
        {
            Name = name;
            Description = description;
            Points = points;
        }

        public abstract int RecordEvent();
        public abstract void Display();
        public abstract string SaveString();
    }

    public class SimpleGoal : Goal
    {
        public bool Completed { get; set; }

        public SimpleGoal(string name, string description, int points, bool completed = false)
            : base(name, description, points)
        {
            Completed = completed;
        }

        public override int RecordEvent()
        {
            if (!Completed)
            {
                Completed = true;
                return Points;
            }
            return 0;
        }

        public override void Display()
        {
            string status = Completed ? "✅" : "❌";
            Console.WriteLine($"[{status}] {Name} ({Description}) - {Points} pts");
        }

        public override string SaveString()
        {
            return $"Simple|{Name}|{Description}|{Points}|{Completed}";
        }
    }

    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points) { }

        public override int RecordEvent()
        {
            return Points;
        }

        public override void Display()
        {
            Console.WriteLine($"[∞] {Name} ({Description}) - {Points} pts each time");
        }

        public override string SaveString()
        {
            return $"Eternal|{Name}|{Description}|{Points}";
        }
    }

    public class ChecklistGoal : Goal
    {
        public int TargetCount { get; set; }
        public int Bonus { get; set; }
        public int CurrentCount { get; set; }

        public ChecklistGoal(string name, string description, int points, int targetCount, int bonus, int currentCount = 0)
            : base(name, description, points)
        {
            TargetCount = targetCount;
            Bonus = bonus;
            CurrentCount = currentCount;
        }

        public override int RecordEvent()
        {
            if (CurrentCount < TargetCount)
            {
                CurrentCount++;
                if (CurrentCount == TargetCount)
                    return Points + Bonus;
                return Points;
            }
            return 0;
        }

        public override void Display()
        {
            Console.WriteLine($"[{CurrentCount}/{TargetCount}] {Name} ({Description}) - {Points} pts each, bonus {Bonus}");
        }

        public override string SaveString()
        {
            return $"Checklist|{Name}|{Description}|{Points}|{TargetCount}|{Bonus}|{CurrentCount}";
        }
    }
}
