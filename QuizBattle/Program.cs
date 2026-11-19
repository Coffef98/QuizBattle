
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