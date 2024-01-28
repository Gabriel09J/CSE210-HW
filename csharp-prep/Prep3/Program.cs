using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world...");
        Console.Clear();
        Console.WriteLine(scripture.Display());

        while (!scripture.AllWordsHidden())
        {
            Console.WriteLine("Press Enter to continue or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWord();
            Console.Clear();
            Console.WriteLine(scripture.Display());
        }

        Console.WriteLine("Program ended.");
    }
}

class Scripture
{
    private readonly List<Word> words;

    public Scripture(string reference, string text)
    {
        Reference = new Reference(reference);
        words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public Reference Reference { get; private set; }

    public void HideRandomWord()
    {
        Random rand = new Random();
        Word randomWord = words[rand.Next(words.Count)];
        randomWord.Hide();
    }

    public bool AllWordsHidden()
    {
        return words.All(word => word.IsHidden);
    }

    public string Display()
    {
        return $"{Reference.Display()}\n{string.Join(" ", words.Select(word => word.Display()))}";
    }
}

class Reference
{
    public Reference(string reference)
    {
        // Parse reference here for handling single verse and verse range
    }

    public string Display()
    {
        // Return formatted reference
    }
}

class Word
{
    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public string Text { get; private set; }
    public bool IsHidden { get; private set; }

    public void Hide()
    {
        IsHidden = true;
    }

    public string Display()
    {
        return IsHidden ? "_____" : Text;
    }
}
