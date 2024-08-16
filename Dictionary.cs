using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
public class Dictionary
{
    public string Name { get; set; }
    public Dictionary<string, WordEntry> Words { get; set; }
    public Dictionary(string name)
    {
        Name = name;
        Words = new Dictionary<string, WordEntry>();
    }
    public void AddWord(string word, string translation)
    {
        if (!Words.ContainsKey(word))
        {
            Words[word] = new WordEntry(word);
        }
        Words[word].AddTranslation(translation);
    }
    public void ReplaceWord(string oldWord, string newWord)
    {
        if (Words.ContainsKey(oldWord))
        {
            var translations = Words[oldWord].Translations;
            Words.Remove(oldWord);
            Words[newWord] = new WordEntry(newWord) { Translations = translations };
        }
    }
    public void ReplaceTranslation(string word, string oldTranslation, string newTranslation)
    {
        if (Words.ContainsKey(word))
        {
            var wordEntry = Words[word];
            if (wordEntry.Translations.Contains(oldTranslation))
            {
                wordEntry.Translations.Remove(oldTranslation);
                wordEntry.AddTranslation(newTranslation);
            }
        }
    }
    public void RemoveWord(string word)
    {
        if (Words.ContainsKey(word))
        {
            Words.Remove(word);
            Console.WriteLine("Word and all its translations were successfully removed.");
        }
        else
        {
            Console.WriteLine("Word not found.");
        }
    }
    public WordEntry SearchWord(string word)
    {
        return Words.ContainsKey(word) ? Words[word] : null;
    }
    public void SaveToFile(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var entry in Words)
            {
                writer.WriteLine($"{entry.Key}:{string.Join(",", entry.Value.Translations)}");
            }
        }
    }
    public static Dictionary LoadFromFile(string filePath, string name)
    {
        var dictionary = new Dictionary(name);
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(':');
                if (parts.Length == 2)
                {
                    var word = parts[0];
                    var translations = parts[1].Split(',');
                    dictionary.Words[word] = new WordEntry(word) { Translations = translations.ToList() };
                }
            }
        }
        return dictionary;
    }
    public void AddNewTranslation(string word, string newTranslation)
    {
        if (Words.ContainsKey(word))
        {
            Words[word].AddTranslation(newTranslation);

        }
    }
}
