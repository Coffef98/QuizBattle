using System.Collections.Generic;
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
                string name = categoryElement.GetProperty("name").GetString()!;
                Category category = new Category(name);

                JsonElement questions = categoryElement.GetProperty("questions");
                foreach (JsonElement q in questions.EnumerateArray())
                {
                    string text = q.GetProperty("text").GetString()!;
                    string difficulty = q.GetProperty("difficulty").GetString()!;
                    string type = q.GetProperty("type").GetString()!;

                    if (type == "multipleChoice")
                    {
                        List<string> options = new List<string>();
                        foreach (JsonElement opt in q.GetProperty("options").EnumerateArray())
                        {
                            options.Add(opt.GetString()!);
                        }
                        int correctIndex = q.GetProperty("correctIndex").GetInt32();

                        category.Questions.Add(new MultipleChoiceQuestion(text, difficulty, options, correctIndex));
                    }
                    else if (type == "trueFalse")
                    {
                        bool correct = q.GetProperty("correct").GetBoolean();

                        category.Questions.Add(new TrueFalseQuestion(text, difficulty, correct));
                    }
                }

                Categories.Add(category);
            }
        }
    }
}