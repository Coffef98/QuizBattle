namespace QuizBattle
{
    public class MultipleChoiceQuestion : Question
    {
        public List<string> Options { get; set; }
        public int CorrectIndex { get ; set; }

        public MultipleChoiceQuestion(
            string text,
            string difficulty,
            List<string> options,
            int correctIndex
        ) : base(text, difficulty)
        {
            Options = options;
            CorrectIndex = correctIndex;
        }
        public override bool CheckAnswer(string answer)
        {
            return int .TryParse(answer, out int selectedIndex) 
            && selectedIndex -1 == CorrectIndex;
        }   
        public override string GetCorrectAnswer()
        {
            return Options[CorrectIndex];
        }
    }
}