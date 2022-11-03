namespace NullableDemo;

public class SurveyRun
{
    private readonly List<SurveyQuestion> _surveyQuestions;

    public SurveyRun()
    {
        // comment the below code to see the nullable reference warning message
        _surveyQuestions = new List<SurveyQuestion>();
    }

    public void AddQuestion(QuestionType questionType, string question)
    {
        AddQuestion(new SurveyQuestion(questionType, question));
    }

    public void AddQuestion(SurveyQuestion surveyQuestion)
    {
        _surveyQuestions.Add(surveyQuestion);
    }
}