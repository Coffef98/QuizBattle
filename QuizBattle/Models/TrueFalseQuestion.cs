namespace QuizBattle
{
    public class TrueFalseQuestion : Question
    {
        public bool Correct { get; set;}

        public TrueFalseQuestion( string text, string difficulty,bool correct)
        : base(text, difficulty)
        {
            Correct = correct;
        }
        public override bool CheckAnswer(string answer)
        {
            if (answer.ToLower() == "sant")
            return Correct;
            
            if (answer. ToLower() == "falskt")
            return !Correct;

            return false;
        }
        public override string GetCorrectAnswer ()
        {
            if (Correct)
            return "sant";
            else 
            return "falskt";
            
        }
    }
}