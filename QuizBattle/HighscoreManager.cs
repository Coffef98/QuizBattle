using QuizBattle;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace QuizBattle
{
    public class HighscoreManager
    {
        private readonly string filePath = Path.Combine(AppContext.BaseDirectory,"data", "highscores.json");
        private List<HighscoreEntry> entries = new();
        private bool loadFailed = false;
        public void LoadScores() //--------------------------------------------------------------------------------------------------------------------------
        {
            loadFailed = false;

            if (!File.Exists(filePath))
            {
                entries = new List<HighscoreEntry>();
                return;
            }

            try
            {
                string json = File.ReadAllText(filePath);

                entries = JsonSerializer.Deserialize<List<HighscoreEntry>>(json)
                          ?? new List<HighscoreEntry>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Kunde inte läsa topplistan: {ex.Message}");
                entries = new List<HighscoreEntry>();
                loadFailed = true;
            }
        }
        public void SaveResult(HighscoreEntry result) //--------------------------------------------------------------------------------------------------------
        {

            LoadScores();

            if (loadFailed)
            {
                Console.WriteLine("Resultatet kunde inte sparas.");
                return;
            }
            try
            {
                entries.Add(result);

                string json = JsonSerializer.Serialize(
                    entries,
                    new JsonSerializerOptions { WriteIndented = true }
                );

                string tempPath = filePath + ".tmp";

                File.WriteAllText(tempPath, json);

                File.Move(tempPath, filePath, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Kunde inte spara resultatet: {ex.Message}");
            }
        }
        public List<HighscoreEntry> GetTopTen() //---------------------------------------------------------------------------------------------------------------
        {
            var sortedEntries = entries
                    .OrderByDescending(entry => entry.Score)
                    .ThenByDescending(entry => entry.CorrectAnswersCount)
                    .Take(10)
                    .ToList();

            return sortedEntries;
        }
        public void ShowLeaderboard() //--------------------------------------------------------------------------------------------------------------------------
        {
            LoadScores();
            List<HighscoreEntry> topTen = GetTopTen();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("========== MAGIC TURTELS TOPPLISTA ==========");
            Console.ResetColor();

            if (topTen.Count == 0)
            {
                Console.WriteLine("Inga sparade resultat ännu.");
                return;
            }
            int position = 1;

            foreach (HighscoreEntry entry in topTen)
            {
                if (position == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (position == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (position == 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                else
                {
                    Console.ResetColor();
                }
                Console.WriteLine(
                    $"{position}. {entry.Name,-15} | " +
                    $"{entry.Score,4} poäng | " +
                    $"{entry.CorrectAnswersCount,3} rätt | " +
                    $"{entry.Date:yyyy-MM-dd}"
                );
                Console.ResetColor();
                position++;
            }
        }

        public void TestLoadScores() //------------------------------------------------------------------------------------------------------------------
        {
            LoadScores();

            foreach (HighscoreEntry entry in GetTopTen())
            {
                Console.WriteLine($"{entry.Name} - {entry.Score} poäng - {entry.CorrectAnswersCount} rätt");
            }
           

            Console.WriteLine($"Antal sparade resultat: {entries.Count}");      // Visar 0 för tillfället så stämmer 
            Console.WriteLine($"Finns JSON-filen? {File.Exists(filePath)}");   // japp den visar att den finns. den retunerade: true.
        }
    }
}
