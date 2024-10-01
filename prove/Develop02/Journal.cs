using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    // List to hold journal entries
    public List<Entry> _entries = new List<Entry>();


    // Method to add a new entry to the journal
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    // Method to display all entries in the journal
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }
        Console.WriteLine($"entries:");
        foreach (Entry entry in _entries)
        {
            entry.Display(); // Calls the ToString method of Entry
        }
    }

    // Method to save journal entries to a file
    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                // Save each entry in the format: Date|Prompt|Response
                writer.WriteLine($"{entry._date}|{entry._promtText}|{entry._entryText}");
            }
        }
        Console.WriteLine("Entries saved to file successfully.");
    }

    // Method to load journal entries from a file
    public void LoadFromFile(string file)
    {
        _entries.Clear(); // Clear existing entries before loading new ones

        try
        {
            string[] lines = System.IO.File.ReadAllLines(file);

            foreach (string line in lines)
        {
            string[] parts = line.Split('|');


            if (parts.Length == 3)
            {
                Entry entry = new Entry()
                {
                    _date = parts[0].Trim(),
                    _promtText = parts[1].Trim(),
                    _entryText = parts[2].Trim()
                };
                _entries.Add(entry);
            }
            else
            {
                Console.WriteLine($"Skipping line due to unexpected format: {line}");
            }
        }
            Console.WriteLine("Entries loaded from file successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading the file: {ex.Message}");
        }
    }
}
