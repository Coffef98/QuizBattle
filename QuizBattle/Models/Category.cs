namespace QuizBattle
{
    public class Category
    {
        public string Name { get; set; }
        public List<Question> Questions { get; set; }

        public Category (string name)
        {
            Name = name;
            Questions = new List<Question>();
        }
    }
}