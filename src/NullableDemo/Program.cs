namespace NullableDemo
{
    internal class Program
    {
        static void Main()
        {
            var surveyRun = new SurveyRun();
            surveyRun.AddQuestion(QuestionType.YesNo, "Has your code ever thrown a NullReferenceException?");
            surveyRun.AddQuestion(new SurveyQuestion(QuestionType.Number, "How many times (to the nearest 100) has that happened?"));
            surveyRun.AddQuestion(QuestionType.Text, "What is your favorite color?");
            
            // uncomment the below code to see the nullable reference warning message
            // surveyRun.AddQuestion(QuestionType.Text, default);

            surveyRun.PerformSurvey(50);

            // note that any explicit NULL check is not implemented in the below code because underlying interfaces designed such a way to return non-nullable values
            foreach (var participant in surveyRun.AllParticipants)
            {
                Console.WriteLine($"Participant: {participant.Id}:");
                if (participant.AnsweredSurvey)
                {
                    for (var i = 0; i < surveyRun.Questions.Count; i++)
                    {
                        var answer = participant.Answer(i);
                        Console.WriteLine($"\t{surveyRun.GetQuestion(i).QuestionText} : {answer}");
                    }
                }
                else
                {
                    Console.WriteLine("\tNo responses");
                }
            }
        }
    }
}