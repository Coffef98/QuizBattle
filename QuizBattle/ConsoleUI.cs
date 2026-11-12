namespace QuizBattle
{
    public class ConsoleUI
    {
        public int ShowMainMenu()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("================");
                Console.WriteLine("Magic Turtles");
                Console.WriteLine("Quiz Battle");
                Console.WriteLine("================");
                Console.ResetColor();

                Console.WriteLine();
                Console.WriteLine("1. Spela");
                Console.WriteLine("2. Topplista");
                Console.WriteLine("3. Avsluta");
                Console.WriteLine();
                Console.WriteLine("Välj ett alternativ:");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice >= 1 && choice <= 3)
                    {
                        return choice;
                    }
                }

                Console.WriteLine("Ogiltigt alternativ! Försök igen.");
                Console.WriteLine();
            }
        }

        public int GetPlayerCount()
        {
            while (true)
            {
                Console.WriteLine("Hur många spelare ska delta? (2-4)");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice >= 2 && choice <= 4)
                    {
                        return choice;
                    }
                }

                Console.WriteLine("Ogiltigt alternativ! Försök igen.");
            }
        }

        public int GetRoundCount()
        {
            while (true)
            {
                Console.WriteLine("Hur många rundor vill ni spela? (1-10)");
                if (int.TryParse(Console.ReadLine(), out int roundCount))
                {
                    if (roundCount >= 1 && roundCount <= 10)
                    {
                        return roundCount;
                    }
                }

                Console.WriteLine("Ogiltigt antal rundor! välj mellan 1 och 10.");
            }
        }

        public List<string> GetPlayerNames(int playerCount)
        {
            List<string> playerNames = new List<string>();

            for (int i = 0; i < playerCount; i++)
            {
                Console.WriteLine($"Ange namn för spelare {i + 1}:");
                string name = Console.ReadLine() ?? "";
                name = name.Trim();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Namnet får inte vara tomt!");
                    i--;
                    continue;
                }
                if (playerNames.Any(playerName =>
                    playerName.Equals(name, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Namnet används redan! Välj ett annat namn.");
                    i--;
                    continue;
                }

                playerNames.Add(name);
            }

            return playerNames;
        }

        public string ChooseCategory(List<Category> categories)
        {

            if (categories.Count == 0)
            {
                return "";
            }
            while (true)
            {
                Console.WriteLine("==== VÄLJ KATEGORI ====");
                Console.WriteLine();

                for (int i = 0; i < categories.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {categories[i].Name} ({categories[i].Questions.Count} frågor)");
                }

                Console.WriteLine($"{categories.Count + 1}. Slumpa");
                Console.WriteLine();
                Console.WriteLine("Välj ett alternativ:");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice >= 1 && choice <= categories.Count)
                    {
                        return categories[choice - 1].Name;
                    }

                    if (choice == categories.Count + 1)
                    {
                        Random random = new Random();
                        int randomIndex = random.Next(categories.Count);

                        return categories[randomIndex].Name;
                    }
                }

                Console.WriteLine($"Ogiltigt alternativ! Välj mellan 1 och {categories.Count + 1}.");
                Console.WriteLine();
            }
        }

        public string GetAnswer(Question question)
        {
            Console.WriteLine("==== FRÅGA ====");
            Console.WriteLine();
            Console.WriteLine(question.Text);
            Console.WriteLine();

            if (question is MultipleChoiceQuestion multipleChoice)
            {
                for (int i = 0; i < multipleChoice.Options.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {multipleChoice.Options[i]}");
                }
            }
            else if (question is TrueFalseQuestion)
            {
                Console.WriteLine("Svara med Sant eller Falskt:");
            }
            while (true)
            {
                string answer = (Console.ReadLine() ?? "").Trim();

                if (question is MultipleChoiceQuestion multipleChoiceQuestion)
                {
                    if (int.TryParse(answer, out int choice) &&
                        choice >= 1 && choice <= multipleChoiceQuestion.Options.Count)
                    {
                        return answer;
                    }
                }
                else if (question is TrueFalseQuestion)
                {
                    if (answer.Equals("sant", StringComparison.OrdinalIgnoreCase) ||
                        answer.Equals("falskt", StringComparison.OrdinalIgnoreCase))
                    {
                        return answer;
                    }
                }

                Console.WriteLine("Ogiltigt svar! Försök igen:");
            }
        }

        public void ShowRoundResult(Player player, int points, bool isCorrect, string correctAnswer)
        {
            Console.WriteLine("==== RESULTAT ====");

            if (isCorrect == true)
            {
                Console.WriteLine("Rätt svar!");
            }
            else
            {
                Console.WriteLine("Fel svar!");
            }

            Console.WriteLine($"Spelare: {player.Name}");
            Console.WriteLine($"Rätt svar: {correctAnswer}");
            Console.WriteLine($"Poäng för frågan: +{points}");
            Console.WriteLine($"Totala poäng: {player.Score}");
        }

        public void ShowWinners(List<Player> winners)
        {
            Console.WriteLine("===== QUIZ BATTLE - RESULTAT =====");

            foreach (var winner in winners)
            {
                Console.WriteLine($"Vinnare: {winner.Name}");
                Console.WriteLine($"Totala poäng: {winner.Score}");
            }
            
            Console.WriteLine("Grattis till vinsten!");
        }
    }
}
