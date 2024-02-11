using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace EternalQuest
{
    abstract class Goal
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; protected set; }
        public int Value { get; protected set; }

        public Goal(string name, string description, int value)
        {
            Name = name;
            Description = description;
            IsComplete = false;
            Value = value;
        }

        public virtual void RecordEvent()
        {
            IsComplete = true;
        }

        public virtual void ShowProgress()
        {
            Console.WriteLine(IsComplete ? $"{Name}: {Description} - Complete" : $"{Name}: {Description} - Incomplete");
        }

        public override string ToString()
        {
            return IsComplete ? $"{Name}: {Description} - Complete" : $"{Name}: {Description} - Incomplete";
        }
    }

    class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int value) : base(name, description, value) { }
    }

    class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int value) : base(name, description, value) { }

        public override void RecordEvent()
        {
            base.RecordEvent();
            Console.WriteLine($"You gained {Value} points for completing the eternal goal '{Name}'.");
        }
    }

    class ChecklistGoal : Goal
    {
        public int TotalTimesCompleted { get; private set; }
        public int TimesCompleted { get; private set; }
        public int Bonus { get; private set; }

        public ChecklistGoal(string name, string description, int value, int totalTimesCompleted, int bonus) : base(name, description, value)
        {
            TotalTimesCompleted = totalTimesCompleted;
            Bonus = bonus;
        }

        public override void RecordEvent()
        {
            if (!IsComplete)
            {
                TimesCompleted++;
                if (TimesCompleted >= TotalTimesCompleted)
                {
                    IsComplete = true;
                    Console.WriteLine($"Congratulations! You've completed the checklist goal '{Name}' and received a bonus of {Bonus} points.");
                    Value += Bonus;
                }
                else
                {
                    Console.WriteLine($"You gained {Value} points for completing '{Name}' ({TimesCompleted}/{TotalTimesCompleted} times).");
                }
            }
            else
            {
                Console.WriteLine($"The goal '{Name}' has already been completed.");
            }
        }

        public override void ShowProgress()
        {
            Console.WriteLine(IsComplete ? $"{Name}: {Description} - Complete" : $"{Name}: {Description} - Completed {TimesCompleted}/{TotalTimesCompleted} times");
        }
    }

    class Program
    {
        static List<Goal> goals = new List<Goal>();
        static int userScore = 0;

        static void Main(string[] args)
        {
            LoadGoals();

            Console.WriteLine("Welcome to Eternal Quest!");

            while (true)
            {
                Console.WriteLine("\n1. Add a new goal");
                Console.WriteLine("2. Record an event");
                Console.WriteLine("3. Show list of goals");
                Console.WriteLine("4. Display user's score");
                Console.WriteLine("5. Save and exit");
                Console.Write("Choose an option: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddGoal();
                            break;
                        case 2:
                            RecordEvent();
                            break;
                        case 3:
                            ShowGoals();
                            break;
                        case 4:
                            DisplayScore();
                            break;
                        case 5:
                            SaveGoals();
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        static void AddGoal()
        {
            Console.WriteLine("\nSelect goal type:");
            Console.WriteLine("1. Simple goal");
            Console.WriteLine("2. Eternal goal");
            Console.WriteLine("3. Checklist goal");
            Console.Write("Enter your choice: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Write("Enter the name of the goal: ");
                string name = Console.ReadLine();
                Console.Write("Enter a description of the goal: ");
                string description = Console.ReadLine();
                Console.Write("Enter the value of the goal: ");
                int value = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        goals.Add(new SimpleGoal(name, description, value));
                        break;
                    case 2:
                        goals.Add(new EternalGoal(name, description, value));
                        break;
                    case 3:
                        Console.Write("Enter the total times to complete the goal: ");
                        int totalTimes = int.Parse(Console.ReadLine());
                        Console.Write("Enter the bonus value: ");
                        int bonus = int.Parse(Console.ReadLine());
                        goals.Add(new ChecklistGoal(name, description, value, totalTimes, bonus));
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        return;
                }

                Console.WriteLine("Goal added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        static void RecordEvent()
        {
            Console.WriteLine("\nSelect the goal to record an event for:");
            ShowGoals();
            Console.Write("Enter the name of the goal: ");
            string name = Console.ReadLine();

            Goal goal = goals.Find(g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (goal != null)
            {
                goal.RecordEvent();
                userScore += goal.Value;
            }
            else
            {
                Console.WriteLine($"Goal '{name}' not found.");
            }
        }

        static void ShowGoals()
        {
            Console.WriteLine("\nCurrent Goals:");
            foreach (var goal in goals)
            {
                goal.ShowProgress();
            }
        }

        static void DisplayScore()
        {
            Console.WriteLine($"\nYour current score is: {userScore} points");
        }

        static void SaveGoals()
        {
            string jsonString = JsonSerializer.Serialize(goals);
            File.WriteAllText("goals.json", jsonString);
            Console.WriteLine("Goals saved successfully.");
        }

        static void LoadGoals()
        {
            if (File.Exists("goals.json"))
            {
                string jsonString = File.ReadAllText("goals.json");
                goals = JsonSerializer.Deserialize<List<Goal>>(jsonString);
                Console.WriteLine("Goals loaded successfully.");
            }
            else
            {
                Console.WriteLine("No saved goals found.");
            }
        }
    }
}
