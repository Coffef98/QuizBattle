using System;
using System.Collections.Generic;
using System.Text;

namespace QuizBattle
{
    public class HighscoreEntry
    {
        public string Name { get; set; } = "";
        public int Score { get; set; }
        public int CorrectAnswersCount { get; set; }
        public DateTime Date { get; set; }
    }
}
