namespace QuizBattle
{
    public abstract class Question : IQuestion
    {
        public string Text { get; set; }
        public string Difficulty { get; set; } 
        
        public Question(string text,string difficulty)
        {
            Text = text;
            Difficulty = difficulty;
        }
        public int GetPoints()
        {
            if (Difficulty == "easy")
            return 10;

            if (Difficulty == "medium")
            return 20;

            if (Difficulty == "hard")
            return 30;
            
            return 0;
        }
        public abstract bool CheckAnswer(string answer);
        public abstract string GetCorrectAnswer();
    
    }
}