namespace NullableDemo;

public class SurveyRun
{
    private readonly List<SurveyQuestion> _surveyQuestions;

    public IEnumerable<SurveyResponse> AllParticipants => (_respondents ?? Enumerable.Empty<SurveyResponse>());
    public ICollection<SurveyQuestion> Questions => _surveyQuestions;
    public SurveyQuestion GetQuestion(int index) => _surveyQuestions[index];

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

    private List<SurveyResponse>? _respondents;
    public void PerformSurvey(int numberOfRespondents)
    {
        var respondentsConsenting = 0;
        _respondents = new List<SurveyResponse>();
        while (respondentsConsenting < numberOfRespondents)
        {
            var respondent = SurveyResponse.GetRandomId();
            if (respondent.AnswerSurvey(_surveyQuestions))
            {
                respondentsConsenting++;
            }
            _respondents.Add(respondent);
        }
    }
}