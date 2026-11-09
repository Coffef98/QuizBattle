






while (true)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("===== MagicTurtels QuizBattle ========");
    Console.WriteLine();
    Console.ResetColor();

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("1: Spela | ");
    Console.ResetColor();

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("2: Highscore | ");
    Console.ResetColor();

    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("3: Avsluta | ");
    Console.ResetColor();

    string choice = Console.ReadLine() ?? "";




    if (choice == "1")      // 1: Spela. Börjar här
    {

    }
    // 1: Spela.    Slutar här


    else if (choice == "2")    // 2: Highscore.    Börjar här 
    {

    }
    //    2: Highscore.    Slutar här


    else if (choice == "3")   // Avsluta 
    {
        return;
    }
}