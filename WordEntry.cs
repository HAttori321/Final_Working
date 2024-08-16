using System.Collections.Generic;

public class WordEntry
{
    public string Word { get; set; }
    public List<string> Translations { get; set; }
    public WordEntry(string word)
    {
        Word = word;
        Translations = new List<string>();
    }
    public void AddTranslation(string translation)
    {
        if (!Translations.Contains(translation))
        {
            Translations.Add(translation);
        }
    }
    public void RemoveTranslation(string translation)
    {
        if (Translations.Count > 1)
        {
            Translations.Remove(translation);
        }
    }
}