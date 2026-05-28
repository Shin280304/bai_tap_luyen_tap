using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class GameManager
{
    private readonly List<Character> characters = new List<Character>();
    private const string DefaultFileName = "character.txt";

    public void AddCharacter()
    {
        Console.WriteLine("===== ADD NEW CHARACTER =====");
        Console.WriteLine("1. Warrior");
        Console.WriteLine("2. Mage");
        Console.Write("Choose character type: ");

        string choice = Console.ReadLine() ?? string.Empty;
        Character? newCharacter = null;

        if (choice == "1")
        {
            newCharacter = new Warrior();
        }
        else if (choice == "2")
        {
            newCharacter = new Mage();
        }
        else
        {
            Console.WriteLine("Invalid choice!");
            return;
        }

        newCharacter.Id = GenerateCharacterId(newCharacter);
        newCharacter.Input();

        characters.Add(newCharacter);
        Console.WriteLine($"Character added successfully. Assigned ID: {newCharacter.Id}");
    }

    public void ShowCharacterList()
    {
        Console.WriteLine("====== CHARACTER LIST ======");

        if (characters.Count == 0)
        {
            Console.WriteLine("No characters found.");
            return;
        }

        foreach (Character character in characters)
        {
            Console.WriteLine("----------");
            Console.WriteLine($"Type: {GetCharacterType(character)}");
            character.Display();
        }
    }

    public void FindCharacterById()
    {
        Console.WriteLine("====== FIND CHARACTER BY ID ======");
        Console.Write("Enter ID: ");
        string id = (Console.ReadLine() ?? string.Empty).Trim();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("ID cannot be empty!");
            return;
        }

        Character? result = characters.Find(c => c.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        if (result != null)
        {
            Console.WriteLine($"Type: {GetCharacterType(result)}");
            result.Display();
            return;
        }

        Console.WriteLine("Character not found!");
    }

    public void SortByPower()
    {
        Console.WriteLine("====== SORT CHARACTER BY POWER ======");
        characters.Sort((a, b) => b.GetPower().CompareTo(a.GetPower()));
        Console.WriteLine("Characters sorted by power (descending).");
    }

    public void SaveToFile()
    {
        Console.WriteLine("====== SAVE TO FILE ======");
        string[] lines = characters.Select(ToFileLine).ToArray();
        File.WriteAllLines(DefaultFileName, lines);
        Console.WriteLine($"Saved {characters.Count} character(s) to {DefaultFileName}.");
    }

    public void LoadFromFile()
    {
        Console.WriteLine("====== LOAD FROM FILE ======");
        if (!File.Exists(DefaultFileName))
        {
            Console.WriteLine($"{DefaultFileName} not found.");
            return;
        }

        string[] lines = File.ReadAllLines(DefaultFileName);
        characters.Clear();

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            Character? character = ParseCharacter(line);
            if (character != null)
            {
                characters.Add(character);
            }
        }

        Console.WriteLine($"Loaded {characters.Count} character(s) from {DefaultFileName}.");
    }

    private static string GetCharacterType(Character character)
    {
        if (character is Warrior)
        {
            return "Warrior";
        }

        if (character is Mage)
        {
            return "Mage";
        }

        return "Character";
    }

    private static string ToFileLine(Character character)
    {
        if (character is Warrior warrior)
        {
            return $"Warrior|{warrior.Id}|{warrior.Name}|{warrior.Level}|{warrior.Health}|{warrior.AttackDamage}|{warrior.Weapon}";
        }

        if (character is Mage mage)
        {
            return $"Mage|{mage.Id}|{mage.Name}|{mage.Level}|{mage.Health}|{mage.Mana}|{mage.MagicDamage}";
        }

        return $"Character|{character.Id}|{character.Name}|{character.Level}|{character.Health}";
    }

    private static Character? ParseCharacter(string line)
    {
        string[] parts = line.Split('|');
        if (parts.Length == 0)
        {
            return null;
        }

        string type = parts[0];

        try
        {
            if (type.Equals("Warrior", StringComparison.OrdinalIgnoreCase) && parts.Length >= 7)
            {
                return new Warrior(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]),
                    int.Parse(parts[4]),
                    int.Parse(parts[5]),
                    parts[6]
                );
            }

            if (type.Equals("Mage", StringComparison.OrdinalIgnoreCase) && parts.Length >= 7)
            {
                return new Mage(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]),
                    int.Parse(parts[4]),
                    int.Parse(parts[5]),
                    int.Parse(parts[6])
                );
            }
        }
        catch
        {
            return null;
        }

        return null;
    }

    private string GenerateCharacterId(Character character)
    {
        string prefix = character is Warrior ? "W" : "M";
        int maxNumber = 0;

        foreach (Character c in characters)
        {
            bool sameType = (prefix == "W" && c is Warrior) || (prefix == "M" && c is Mage);
            if (!sameType || string.IsNullOrWhiteSpace(c.Id))
            {
                continue;
            }

            string candidate = c.Id.Trim().ToUpper();
            if (!candidate.StartsWith(prefix))
            {
                continue;
            }

            string numberPart = candidate.Substring(1);
            if (int.TryParse(numberPart, out int number) && number > maxNumber)
            {
                maxNumber = number;
            }
        }

        return $"{prefix}{maxNumber + 1:D2}";
    }
}