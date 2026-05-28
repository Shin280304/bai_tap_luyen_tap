using System;

class Warrior : Character
{
    public int AttackDamage { get; set; }
    public string Weapon { get; set; }

    public Warrior()
    {
        Weapon = string.Empty;
    }

    public Warrior(string id, string name, int level, int health, int attackDamage, string weapon)
        : base(id, name, level, health)
    {
        AttackDamage = attackDamage;
        Weapon = weapon;
    }

    public override void Input()
    {
        base.Input();
        Console.Write("Enter Attack Damage: ");
        AttackDamage = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Enter Weapon: ");
        Weapon = Console.ReadLine() ?? string.Empty;
    }

    public override int GetPower()
    {
        return Level * AttackDamage;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Attack Damage: {AttackDamage}");
        Console.WriteLine($"Weapon: {Weapon}");
        Console.WriteLine($"Power: {GetPower()}");
    }
}