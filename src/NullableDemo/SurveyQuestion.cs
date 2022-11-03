namespace NullableDemo;

public class SurveyQuestion
{
    public string QuestionText { get; }
    public QuestionType TypeOfQuestion { get; }

    // comment the below default constructor to see the nullable reference warning message
    public SurveyQuestion(QuestionType questionType, string questionText)
    {
        TypeOfQuestion = questionType;
        QuestionText = questionText;
    }
}