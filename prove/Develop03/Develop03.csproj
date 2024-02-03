using System;
using System.Collections.Generic;

class Word
{
    public string Text { get; set; }

    public Word(string text)
    {
        Text = text;
    }

    public string Hide()
    {
        return new string('*', Text.Length);
    }
}

class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int? EndVerse { get; }

    public Reference(string book, int chapter, int startVerse, int? endVerse = null)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        if (EndVerse.HasValue)
        {
            return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
        }
        else
        {
            return $"{Book} {Chapter}:{StartVerse}";
        }
    }
}

class Scripture
{
    public Reference Reference { get; }
    public List<Word> Words { get; }

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Words = new List<Word>(Array.ConvertAll(text.Split(' '), word => new Word(word)));
    }

    public void HideWords()
    {
        Random random = new Random();
        HashSet<int> hiddenIndices = new HashSet<int>();

        while (hiddenIndices.Count < Words.Count)
        {
            int index = random.Next(0, Words.Count);
            hiddenIndices.Add(index);
        }

        foreach (int index in hiddenIndices)
        {
            Words[index] = new Word(Words[index].Hide());
        }
    }

    public bool IsAllHidden()
    {
        return Words.TrueForAll(word => word.Text.StartsWith("*"));
    }

    public void Display()
    {
        string hiddenScripture = string.Join(' ', Words.ConvertAll(word => word.Text));
        Console.WriteLine($"{Reference} - {hiddenScripture}");
    }
}

class Program
{
    static void Main()
    {
        Reference scriptureReference = new Reference(book: "John", chapter: 3, startVerse: 16);
        string scriptureText = "For God so loved the world, that he gave his only Son, that whoever believes in him should not perish but have eternal life.";
        Scripture scripture = new Scripture(reference: scriptureReference, text: scriptureText);

        while (!scripture.IsAllHidden())
        {
            Console.WriteLine("Press Enter to continue or type 'quit' to exit:");
            string userInput = Console.ReadLine().ToLower();

            if (userInput == "quit")
            {
                break;
            }

            ConsoleClear();
            scripture.HideWords();
            scripture.Display();
        }

        Console.WriteLine("Program ended.");
    }

    static void ConsoleClear()
    {
        Console.Clear();
    }
}