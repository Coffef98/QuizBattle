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
        public int CurrenStreak { get; set; }

        public Player(string name)
        {
            Name = name;
            Score = 0;
            CorrectAnswersCount = 0;
            CurrenStreak = 0;
        }

        public void AddCorrectAnswer(int basepoints)
        {
            CorrectAnswersCount++;
            CurrentStreak++;

            int bonusPoint = 0;
            if (CurrenStreak > 1)
            {
                bonuPoints = (CurrentStreak - 1) * 5;
                if (bonusPoints > 20) bonusPoints = 20;
            }

            Score += (basepoints + bonusPoints);

        }

        public void RegisterWrongAnswer()
        {
            CurrenstStreak = 0;
        }

        public void ResetStats()
        {
            Score = 0;
            CorrectAnswersCount = 0;
            CurrentStreak = 0;
        }

    }
}
