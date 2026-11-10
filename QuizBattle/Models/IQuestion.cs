namespace QuizBattle
{
    public interface IQuestion
    {
        string Text { get; }
        string Difficulty { get;} 

        bool CheckAnswer(string answer);
        int GetPoints();
        string GetCorrectAnswer();
    }
}