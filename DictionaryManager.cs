using System;
using System.Collections.Generic;
public class DictionaryManager
{
    private List<Dictionary> Dictionaries = new List<Dictionary>();
    public void Start()
    {
        while (true)
        {
            Console.WriteLine("1. Create Dictionary");
            Console.WriteLine("2. Add Word");
            Console.WriteLine("3. Replace Word or Translation");
            Console.WriteLine("4. Remove Word");
            Console.WriteLine("5. Search Word");
            Console.WriteLine("6. Save Dictionary");
            Console.WriteLine("7. Load Dictionary");
            Console.WriteLine("8. Add new translation");
            Console.WriteLine("0. Exit");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateDictionary();
                    break;
                case "2":
                    AddWord();
                    break;
                case "3":
                    ReplaceWordOrTranslation();
                    break;
                case "4":
                    RemoveWord();
                    break;
                case "5":
                    SearchWord();
                    break;
                case "6":
                    SaveDictionary();
                    break;
                case "7":
                    LoadDictionary();
                    break;
                case "8":
                    AddNewTranslation();
                    break;
                case "0":
                    return;
            }
        }
    }
    private void CreateDictionary()
    {
        Console.WriteLine("Enter dictionary name:");
        string name = Console.ReadLine();
        Dictionaries.Add(new Dictionary(name));
        Console.WriteLine("Dictionary successfully created.");
    }
    private void AddWord()
    {
        var dictionary = SelectDictionary();
        if (dictionary == null) return;
        Console.WriteLine("Enter word:");
        string word = Console.ReadLine();
        Console.WriteLine("Enter translation:");
        string translation = Console.ReadLine();
        dictionary.AddWord(word, translation);
        Console.WriteLine("Word successfully added.");
    }
    private void ReplaceWordOrTranslation()
    {
        var dictionary = SelectDictionary();
        if (dictionary == null) return;
        Console.WriteLine("1. Replace Word");
        Console.WriteLine("2. Replace Translation");
        string option = Console.ReadLine();
        if (option == "1")
        {
            Console.WriteLine("Enter the word to replace:");
            string oldWord = Console.ReadLine();
            Console.WriteLine("Enter the new word:");
            string newWord = Console.ReadLine();
            dictionary.ReplaceWord(oldWord, newWord);
            Console.WriteLine("Word successfully replaced.");
        }
        else if (option == "2")
        {
            Console.WriteLine("Enter the word containing the translation:");
            string word = Console.ReadLine();
            Console.WriteLine("Enter the translation to replace:");
            string oldTranslation = Console.ReadLine();
            Console.WriteLine("Enter the new translation:");
            string newTranslation = Console.ReadLine();
            dictionary.ReplaceTranslation(word, oldTranslation, newTranslation);
            Console.WriteLine("Translation successfully replaced.");
        }
        else
        {
            Console.WriteLine("Invalid option.");
        }
    }
    private void RemoveWord()
    {
        var dictionary = SelectDictionary();
        if (dictionary == null) return;
        Console.WriteLine("Enter the word to remove:");
        string word = Console.ReadLine();
        dictionary.RemoveWord(word);
    }
    private void SearchWord()
    {
        var dictionary = SelectDictionary();
        if (dictionary == null) return;
        Console.WriteLine("Enter the word to search:");
        string word = Console.ReadLine();
        var wordEntry = dictionary.SearchWord(word);
        if (wordEntry != null)
        {
            Console.WriteLine($"Word: {word}");
            Console.WriteLine($"Translations: {string.Join(", ", wordEntry.Translations)}");
        }
        else
        {
            Console.WriteLine("Word not found.");
        }
        Console.WriteLine("Search completed successfully.");
    }
    private void SaveDictionary()
    {
        var dictionary = SelectDictionary();
        if (dictionary == null) return;
        Console.WriteLine("Enter file path to save:");
        string filePath = Console.ReadLine();
        dictionary.SaveToFile(filePath);
        Console.WriteLine("Dictionary successfully saved.");
    }
    private void LoadDictionary()
    {
        Console.WriteLine("Enter file path to load:");
        string filePath = Console.ReadLine();
        Console.WriteLine("Enter dictionary name:");
        string name = Console.ReadLine();
        var dictionary = Dictionary.LoadFromFile(filePath, name);
        Dictionaries.Add(dictionary);
        Console.WriteLine("Dictionary successfully loaded.");
        Console.WriteLine("Loaded Dictionary Contents:");
        foreach (var entry in dictionary.Words)
        {
            Console.WriteLine($"Word: {entry.Key}");
            Console.WriteLine($"Translations: {string.Join(", ", entry.Value.Translations)}");
        }
    }
    private Dictionary SelectDictionary()
    {
        Console.WriteLine("Select a dictionary:");
        for (int i = 0; i < Dictionaries.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Dictionaries[i].Name}");
        }
        int index;
        if (int.TryParse(Console.ReadLine(), out index) && index > 0 && index <= Dictionaries.Count)
        {
            return Dictionaries[index - 1];
        }
        Console.WriteLine("Invalid selection.");
        return null;
    }
    private void AddNewTranslation()
    {
        var dictionary = SelectDictionary();
        if (dictionary == null) return;
        Console.WriteLine("Enter word:");
        string word = Console.ReadLine();
        Console.WriteLine("Enter translation:");
        string translation = Console.ReadLine();
        dictionary.AddNewTranslation(word, translation);
        Console.WriteLine("Translation successfully added.");
    }
}
