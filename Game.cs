namespace CastTheDice;

public class Game(int winningNumber)
{
    private readonly Dice dice1 = new();
    private readonly Dice dice2 = new();
    private int WinningNumber { get; set; } = winningNumber;
    private int Attempts {get; set;}

    private static void GameMenu()
    {
        Console.Clear();
        System.Console.WriteLine("Välkommen till TärningsKaos");
        System.Console.WriteLine("===============================");
        System.Console.WriteLine("1. Spela");
        System.Console.WriteLine("2. Avsluta");
        System.Console.WriteLine("===============================\n\n");

        Console.Write("Ditt val: ");
    }
    public void StartGame()
    {
        while (true)
        {
            GameMenu();
            int menuInput = MenuHandler();

            switch (menuInput)
            {
                case 1:
                    PlayGame();
                    break;

                case 2:
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }

    }

    public void PlayGame()
    {
        Console.Clear();
        System.Console.Write($"Välkommen. För att vinna detta spel skall du slå {WinningNumber}. Är du redo att kasta? (j/n): ");
        bool input = AskToPlayAgainHandler();
        if (!input)
        {
            return;
        }
        HandleGame();
    }

    private void HandleGame()
    {
        Attempts = 0;
        bool playAgain = true;

        while (playAgain)
        {
            Attempts++;
            dice1.ThrowDice();
            dice2.ThrowDice();
            int result = dice1.Value + dice2.Value;

            if (result == WinningNumber)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Grattis, du har vunnit!, det tog {Attempts} försök.\n");
                Console.ResetColor();
                Attempts = 0;
            }
            else
            {
                Console.Clear();
                System.Console.WriteLine("Tyvärr ingen vinst, försök igen.\n");
                Console.WriteLine($"Tärning ett: {dice1.Value}, tärning två: {dice2.Value}. Resultat: {result}.\n\nFörsök: {Attempts}\n");
            }

            Console.Write("Spela igen? (j/n): ");
            playAgain = AskToPlayAgainHandler();
        }
    }

    private static int MenuHandler()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int input) && input >= 1 && input <= 2)
            {
                return input;
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\nOgiltigt val, 1(Spela) eller 2(Avsluta)!\n");
            Console.ResetColor();
            System.Console.Write("Försök igen: ");
        }
    }

    private static bool AskToPlayAgainHandler()
    {
        while (true)
        {
            string input = Console.ReadLine()?.Trim().ToLower() ?? "";

            if (input == "j") return true;
            if (input == "n") return false;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.WriteLine("Du måste skriva 'j'(Spela) eller 'n'(Återgå till menyn)");
            Console.ResetColor();
            Console.Write("Spela igen? (j/n): ");
        }
    }

}
