namespace NullableDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var surveyRun = new SurveyRun();
            surveyRun.AddQuestion(QuestionType.YesNo, "Has your code ever thrown a NullReferenceException?");
            surveyRun.AddQuestion(new SurveyQuestion(QuestionType.Number, "How many times (to the nearest 100) has that happened?"));
            surveyRun.AddQuestion(QuestionType.Text, "What is your favorite color?");
            
            // uncomment the below code to see the nullable reference warning message
            // surveyRun.AddQuestion(QuestionType.Text, default);
        }
    }
}