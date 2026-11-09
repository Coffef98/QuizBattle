using System;
using System.Collections.Generic;
using System.Text;

namespace QuizBattle
{
    public class GameEngine
    {
        private List<Player> players;
        private int totalRounds;
        private int currentRound;

        public GameEngine(List<Player> playerList, int rounds)
        {
            players = playerList;
            totalRounds = rounds;
            currentRound = 1;
        }

        public void StartGame()
        {

            while (currentRound <= totalRounds)
            {
                PlayRound();
                currentRound++;

            }

            List<Player> winners = GetWinners();
        }

        public void PlayRound()
        {
            Console.WriteLine($"\n=== round {currentRound} of {totalRounds} ===");

            foreach (var player in players)
            {
                Console.WriteLine($"\nIt is {player.Name}'s to play.");
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

            int maxScore = players.Max(p => p.Score);
            var topScorers = players.Where(p => p.Score == maxScore).ToList();

            if (topScorers.Count > 1)
            {
                int maxCorrect = topScorers.Max(p => p.CorrectAnswersCount);
                return topScorers.Where(p => p.CorrectAnswersCount == maxCorrect).ToList();
            }

            return topScorers;
        }
    }
}




