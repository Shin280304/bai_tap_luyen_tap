using System;

class Program
{
    static void Main(string[] args)
    {
        GameManager gm = new GameManager();

        while (true)
        {
            Console.WriteLine("========= GAME CHARACTER MANAGER =========");
            Console.WriteLine("1. Add Character");
            Console.WriteLine("2. Show Character List");
            Console.WriteLine("3. Find Character By ID");
            Console.WriteLine("4. Sort By Power");
            Console.WriteLine("5. Save To File");
            Console.WriteLine("6. Load From File");
            Console.WriteLine("7. Exit");
            Console.WriteLine("==========================================");
            Console.Write("Choose: ");

            string choice = Console.ReadLine() ?? string.Empty;

            switch (choice)
            {
                case "1":
                    gm.AddCharacter();
                    break;

                case "2":
                    gm.ShowCharacterList();
                    break;

                case "3":
                    gm.FindCharacterById();
                    break;

                case "4":
                    gm.SortByPower();
                    break;

                case "5":
                    gm.SaveToFile();
                    break;

                case "6":
                    gm.LoadFromFile();
                    break;

                case "7":
                    return;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

            Console.WriteLine();
        }
    }
}