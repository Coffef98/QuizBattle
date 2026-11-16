
using QuizBattle;

ConsoleUI ui = new ConsoleUI();

while (true)
{
    int choice = ui.ShowMainMenu();

    if (choice == 1)
    {
        int playerCount = ui.GetPlayerCount();
        List<string> playerNames = ui.GetPlayerNames(playerCount);
        List<Player> players = new List<Player>();
        foreach (string name in playerNames)
        {
            Player player = new Player(name);
            players.Add(player);
        }
        int rounds = ui.GetRoundCount();
        GameManager game = new GameManager(players, rounds);
        game.StartGame();
    }
    else if (choice == 2)
    {
        HighscoreManager manager = new HighscoreManager();
        manager.ShowLeaderboard();
    }
    else if (choice == 3)
    {
        Console.WriteLine("Tack för att du spelade!");
        break;
    }
}




//while (true)
//{
//Console.ForegroundColor = ConsoleColor.Green;
//Console.WriteLine("===== MagicTurtels QuizBattle ========");
//Console.WriteLine();
//Console.ResetColor();

//Console.ForegroundColor = ConsoleColor.Yellow;
//Console.Write("1: Spela | ");
//Console.ResetColor();

//Console.ForegroundColor = ConsoleColor.Cyan;
//Console.Write("2: Highscore | ");
//Console.ResetColor();

//Console.ForegroundColor = ConsoleColor.Red;
//Console.Write("3: Avsluta | ");
//Console.ResetColor();

//Console.WriteLine();
//Console.ForegroundColor = ConsoleColor.DarkCyan;
//Console.Write("Ditt val 1-3: ");
//Console.ResetColor();

//string choice = Console.ReadLine() ?? "";




//if (choice == "1")      // 1: Spela. Börjar här
//{

//}
// 1: Spela.    Slutar här


//else if (choice == "2")    // 2: Highscore.    Börjar här 
//{
//  HighscoreManager manager = new HighscoreManager();
//HighscoreEntry testResult = new HighscoreEntry   // Testade och fick upp 2 st som är rätt
//{
//    Name = "Maja",
//    Score = 200,
//    CorrectAnswersCount = 8,
//    Date = DateTime.Now
//};
//manager.SaveResult(testResult);

//Console.WriteLine("Testresultatet har skickats till SaveResult().");  // Bara en kontroll 

//manager.ShowLeaderboard();
//manager.TestLoadScores();     // Gamla anropet när vi testade.

//}
//    2: Highscore.    Slutar här


//else if (choice == "3")   // Avsluta 
//{
//  return;
//}
//}