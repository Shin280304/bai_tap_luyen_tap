using System;

class Character
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public int Health { get; set; }

    public Character()
    {
        Id = string.Empty;
        Name = string.Empty;
    }

    public Character(string id, string name, int level, int health)
    {
        Id = id;
        Name = name;
        Level = level;
        Health = health;
    }

    public virtual void Input()
    {
        Console.Write("Enter Name: ");
        Name = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter Level: ");
        Level = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Enter Health (HP): ");
        Health = int.Parse(Console.ReadLine() ?? "0");
    }

    public virtual void Display()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Level: {Level}");
        Console.WriteLine($"HP: {Health}");
    }

    public virtual int GetPower()
    {
        return 0;
    }
}