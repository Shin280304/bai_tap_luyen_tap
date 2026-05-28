using System;

class Mage : Character
{
    public int Mana { get; set; }
    public int MagicDamage { get; set; }

    public Mage() { }

    public Mage(string id, string name, int level, int health, int mana, int magicDamage)
        : base(id, name, level, health)
    {
        Mana = mana;
        MagicDamage = magicDamage;
    }

    public override void Input()
    {
        base.Input();
        Console.Write("Enter Mana: ");
        Mana = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Enter Magic Damage: ");
        MagicDamage = int.Parse(Console.ReadLine() ?? "0");
    }

    public override int GetPower()
    {
        return Level * MagicDamage;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Mana: {Mana}");
        Console.WriteLine($"Magic Damage: {MagicDamage}");
        Console.WriteLine($"Power: {GetPower()}");
    }
}