using System;
using System.Collections.Generic;
using System.Text;

namespace QuizBattle
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int CorrectAnswersCount { get; set; }
        public int CurrentStreak { get; set; }

        public Player(string name)
        {
            Name = name;
            Score = 0;
            CorrectAnswersCount = 0;
            CurrentStreak = 0;
        }

        public void AddCorrectAnswer(int basepoints)
        {
            CorrectAnswersCount++;
            CurrentStreak++;

            int bonusPoints = 0;
            if (CurrentStreak > 1)
            {
                bonusPoints = (CurrentStreak - 1) * 5;
                if (bonusPoints > 20) bonusPoints = 20;
            }

            Score += (basepoints + bonusPoints);

        }

        public void RegisterWrongAnswer()
        {
            CurrentStreak = 0;
        }

        public void ResetStats()
        {
            Score = 0;
            CorrectAnswersCount = 0;
            CurrentStreak = 0;
        }

    }
}
