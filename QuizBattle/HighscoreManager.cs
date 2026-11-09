using System;
using System.Collections.Generic;
using System.Text;

namespace QuizBattle
{
    public class HighscoreManager
    {
        private readonly string filePath = Path.Combine(AppContext.BaseDirectory,"data", "highscores.json");
        private List<HighscoreEntry> entries = new();

    }
}
