using System;
using System.Collections.Generic;
using System.Text;

namespace QuizBattle
{
    public class GameManager
    {
        private List<Player> players;
        private int totalRounds;
        private int currentRound;
        private QuestionManager questionManager;


        public GameManager(List<Player> playerList, int rounds)
        {
            players = playerList;
            totalRounds = rounds;
            currentRound = 1;
            questionManager = new QuestionManager();
            questionManager.LoadQuestions(Path.Combine(AppContext.BaseDirectory, "data", "questions.json"));
        }

        public void StartGame()
        {

            while (currentRound <= totalRounds)
            {
                if (questionManager.Categories.All(c => c.Questions.Count == 0))
                {
                    Console.WriteLine("Alla frågor är slut! Spelet avslutas.");
                    break;
                }

                PlayRound();
                currentRound++;

            }

            List<Player> winners = GetWinners();
            ConsoleUI ui = new ConsoleUI();
            ui.ShowWinners(winners);
            HighscoreManager highscoreManager = new HighscoreManager();

            foreach (Player player in players)
            {
                HighscoreEntry entry = new HighscoreEntry
                {
                    Name = player.Name,
                    Score = player.Score,
                    CorrectAnswersCount = player.CorrectAnswersCount,
                    Date = DateTime.Now
                };

                highscoreManager.SaveResult(entry);
            }
        }

        public void PlayRound()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n=== round {currentRound} of {totalRounds} ===");
            Console.ResetColor();

            foreach (var player in players)
            {

                if (questionManager.Categories.All(c => c.Questions.Count == 0))
                {
                    Console.WriteLine("\nAlla frågor är slut!");
                    break;
                }

                Console.Write("\nNu är det ");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(player.Name);
                Console.ResetColor();

                Console.WriteLine("s tur att spela!");


                ConsoleUI ui = new ConsoleUI();
                string selectedCategory = ui.ChooseCategory(questionManager.Categories);
                Category? category = questionManager.Categories
                    .FirstOrDefault(c => c.Name == selectedCategory);

                if (category == null)
                {
                    Console.WriteLine("Kategorin kunde inte hittas.");
                    continue;
                }
                if (category.Questions.Count == 0)
                {
                    Console.WriteLine("Det finns inga frågor kvar i denna kategori.");
                    continue;
                }
                Random random = new Random();
                int randomIndex = random.Next(category.Questions.Count);
                Question question = category.Questions[randomIndex];
                string answer = ui.GetAnswer(question);
                bool isCorrect = question.CheckAnswer(answer);
                int basePoints = question.GetPoints();
                int earnedPoints = CalculatePoints(player, basePoints, isCorrect);
                string correctAnswer = question.GetCorrectAnswer();
                ui.ShowRoundResult(player, earnedPoints, isCorrect, correctAnswer);
                category.Questions.RemoveAt(randomIndex);
            }
        }

        public int CalculatePoints(Player player, int basePoints, bool isCorrect)
        {
            if (isCorrect)
            {
                int scoreBefore = player.Score;
                player.AddCorrectAnswer(basePoints);
                int scoreAfter = player.Score;

                return scoreAfter - scoreBefore;
            }
            else
            {
                player.RegisterWrongAnswer();
                return 0;
            }
        }

        public List<Player> GetWinners()
        {
            if (players == null || players.Count == 0)
            {
                return new List<Player>();
            }

            int maxScore = -1;
            foreach (var player in players)
            {
                 if(player.Score > maxScore)
                 {
                    maxScore = player.Score;
                 }
            }

            List<Player> topScorers = new List<Player>();
            foreach (var player in players)
            {
                if (player.Score == maxScore)
                {
                    topScorers.Add(player);
                }
            }

            if (topScorers.Count > 1)
            {
                int maxCorrect = -1;
                foreach (var player in topScorers)
                {
                    if (player.CorrectAnswersCount > maxCorrect)
                    {
                        maxCorrect = player.CorrectAnswersCount;
                    }
                }

                List<Player> finalWinners = new List<Player>();
                foreach (var player in topScorers)
                {
                    if (player.CorrectAnswersCount == maxCorrect)
                    {
                        finalWinners.Add(player);
                    }
                }
                return finalWinners;
            }

            return topScorers;
        }
    }
}






