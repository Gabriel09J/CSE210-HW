using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main()
    {
        ActivityMenu menu = new ActivityMenu();

        while (true)
        {
            menu.DisplayMenu();
            int choice;

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                menu.PerformActivity(choice);
                if (choice == menu.ExitOption)
                {
                    Console.WriteLine("Exiting program. Goodbye!");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}

abstract class BaseActivity
{
    public string Name { get; set; }
    public string Description { get; set; }

    protected BaseActivity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public abstract void Perform();

    protected void DisplayAnimation(string message, int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write($"{message} ");
            Thread.Sleep(1000);
            Console.Clear();
        }
    }

    protected void DisplaySpinner(int durationInSeconds)
    {
        int spinnerDuration = Math.Min(durationInSeconds, 10);
        int spinnerInterval = 200;

        for (int i = 0; i < spinnerDuration * 1000 / spinnerInterval; i++)
        {
            string[] spinnerFrames = { "|", "/", "-", "\\" };
            Console.Write($"Processing {spinnerFrames[i % spinnerFrames.Length]} ");
            Thread.Sleep(spinnerInterval);
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }

        Console.WriteLine();
    }
}

class ActivityMenu
{
    private List<BaseActivity> activities;
    public int ExitOption { get; }

    public ActivityMenu()
    {
        activities = new List<BaseActivity>
        {
            new ExerciseActivity("Activity 1", "This activity focuses on physical exercise."),
            new ExerciseActivity("Activity 2", "This activity involves mental exercises."),
            new ExerciseActivity("Activity 3", "This activity combines physical and mental elements."),
            new BreathingActivity("Breathing Activity", "This activity helps you relax by focusing on your breath."),
            new ReflectionActivity("Reflection Activity", "This activity encourages reflection on past experiences."),
            new ListeningActivity("Listening Activity", "This activity involves listing positive aspects of your life.")
        };

        ExitOption = activities.Count + 1;
    }

    public void DisplayMenu()
    {
        for (int i = 0; i < activities.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {activities[i].Name}");
        }

        Console.WriteLine($"{ExitOption}. Exit");
        Console.Write("Select an activity: ");
    }

    public void PerformActivity(int choice)
    {
        if (choice >= 1 && choice <= activities.Count)
        {
            BaseActivity selectedActivity = activities[choice - 1];
            selectedActivity.Perform();
        }
        else if (choice == ExitOption)
        {
            // Do nothing, just exit
        }
        else
        {
            Console.WriteLine("Invalid choice. Please select a valid option.");
        }
    }
}

class ExerciseActivity : BaseActivity
{
    public ExerciseActivity(string name, string description) : base(name, description) { }

    public override void Perform()
    {
        Console.Clear();

        Console.WriteLine($"Starting {Name}.");
        Console.Write($"Enter duration in seconds for {Name}: ");

        int durationInSeconds;
        if (int.TryParse(Console.ReadLine(), out durationInSeconds))
        {
            DisplayAnimation("Preparing to begin", 3);

            Console.WriteLine($"Get ready to begin {Name}!");
            DisplayAnimation("Starting", 3);

            Console.WriteLine($"Activity ongoing for {durationInSeconds} seconds...");
            DisplaySpinner(durationInSeconds);

            Console.WriteLine($"Good job! You completed {Name} for {durationInSeconds} seconds.");
            DisplayAnimation("Completing", 3);
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number for duration.");
        }
    }
}

class BreathingActivity : BaseActivity
{
    public BreathingActivity(string name, string description) : base(name, description) { }

    public override void Perform()
    {
        Console.Clear();

        Console.WriteLine($"Starting {Name}.");
        Console.Write($"Enter duration in seconds for {Name}: ");

        int durationInSeconds;
        if (int.TryParse(Console.ReadLine(), out durationInSeconds))
        {
            Console.WriteLine($"This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
            DisplayAnimation("Preparing to begin", 3);

            Console.WriteLine($"Get ready to begin {Name}!");
            DisplayAnimation("Starting", 3);

            PerformBreathingCycle(durationInSeconds);

            Console.WriteLine($"Good job! You completed {Name} for {durationInSeconds} seconds.");
            DisplayAnimation("Completing", 3);
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number for duration.");
        }
    }

    private void PerformBreathingCycle(int durationInSeconds)
    {
        int breathInterval = 4; // 4 seconds for each phase (inhale and exhale)

        for (int i = 0; i < durationInSeconds / (2 * breathInterval); i++)
        {
            Console.WriteLine("Breathe in...");
            DisplayCountdown(breathInterval);

            Console.WriteLine("Breathe out...");
            DisplayCountdown(breathInterval);
        }
    }

    private void DisplayCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }

        Console.WriteLine(); // Move to the next line after the countdown
    }
}

class ReflectionActivity : BaseActivity
{
    private string[] reflectionPrompts =
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    public ReflectionActivity(string name, string description) : base(name, description) { }

    public override void Perform()
    {
        Console.Clear();

        Console.WriteLine($"Starting {Name}.");
        Console.Write($"Enter duration in seconds for {Name}: ");

        int durationInSeconds;
        if (int.TryParse(Console.ReadLine(), out durationInSeconds))
        {
Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
DisplayAnimation(“Preparing to begin”, 3);
Console.WriteLine($“Get ready to begin {Name}!”);
DisplayAnimation(“Starting”, 3);

        PerformRandomReflection(durationInSeconds);

        Console.WriteLine($"Good job! You completed {Name} for {durationInSeconds} seconds.");
        DisplayAnimation("Completing", 3);
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid number for duration.");
    }
}

private void PerformRandomReflection(int durationInSeconds)
{
    Random random = new Random();

    for (int i = 0; i < durationInSeconds; i++)
    {
        string randomPrompt = reflectionPrompts[random.Next(reflectionPrompts.Length)];
        Console.WriteLine(randomPrompt);
        DisplaySpinner(3); // Spinner pause for 3 seconds

        string[] reflectionQuestions =
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        foreach (var question in reflectionQuestions)
        {
            Console.WriteLine(question);
            DisplaySpinner(3); // Spinner pause for 3 seconds
        }
    }
}

}

class ListeningActivity : BaseActivity
{
private string[] listeningPrompts =
{
“Who are people that you appreciate?”,
“What are personal strengths of yours?”,
“Who are people that you have helped this week?”,
“When have you felt the Holy Ghost this month?”,
“Who are some of your personal heroes?”
};

public ListeningActivity(string name, string description) : base(name, description) { }

public override void Perform()
{
    Console.Clear();

    Console.WriteLine($"Starting {Name}.");
    Console.Write($"Enter duration in seconds for {Name}: ");

    int durationInSeconds;
    if (int.TryParse(Console.ReadLine(), out durationInSeconds))
    {
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        DisplayAnimation("Preparing to begin", 3);

        Console.WriteLine($"Get ready to begin {Name}!");
        DisplayAnimation("Starting", 3);

        PerformListeningCycle(durationInSeconds);

        Console.WriteLine($"Good job! You completed {Name} for {durationInSeconds} seconds.");
        DisplayAnimation("Completing", 3);
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid number for duration.");
    }
}

private void PerformListeningCycle(int durationInSeconds)
{
    Random random = new Random();
    string randomPrompt = listeningPrompts[random.Next(listeningPrompts.Length)];
    Console.WriteLine(randomPrompt);

    DisplayCountdown(5); // Countdown of 5 seconds to begin thinking about the prompt

    Console.WriteLine("Now, list as many items as you can!");

    List<string> userItems = new List<string>();

    while (durationInSeconds > 0)
    {
        Console.Write("Enter an item (or type 'done' to finish): ");
        string userEntry = Console.ReadLine();
        if (userEntry.ToLower() == "done")
        {
            break;
        }
        userItems.Add(userEntry);
        durationInSeconds -= 1;
        DisplaySpinner(3); // Spinner pause for 3 seconds
    }
    Console.WriteLine($"You listed {userItems.Count} items:");
    foreach (var item in userItems)
    {
        Console.WriteLine(item);
    }
}

private void DisplayCountdown(int seconds)
{
    for (int i = seconds; i > 0; i--)
    {
        Console.Write($"{i} ");
        Thread.Sleep(1000);
        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
    }
    Console.WriteLine(); // Move to the next line after the countdown
}

}
