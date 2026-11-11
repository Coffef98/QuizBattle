using System.IO;
using System.Text.Json;
namespace QuizBattle
{
    public class QuestionManager
    {
        public List<Category> Categories { get; set; }
        public QuestionManager()
        {
            Categories = new List<Category>();
        }
        public void AddCategory(Category category)
        {
            Categories.Add(category);
        }
        public void LoadQuestions(string filePath)
        {
            string json = File.ReadAllText(filePath);
            JsonDocument document = JsonDocument.Parse(json);
            JsonElement categories = document.RootElement.GetProperty("categories");

            foreach (JsonElement categoryElement in categories.EnumerateArray())
            {
                string name = categoryElement.GetProperty("name").GetString();

                Category category = new Category(name);
                

                Categories.Add(category);
            }
        }
    }
}