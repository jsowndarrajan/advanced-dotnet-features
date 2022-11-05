namespace NullableDemo;

public class SurveyResponse
{
    private static readonly Random RandomGenerator = new Random();

    public static SurveyResponse GetRandomId()
    {
        return new SurveyResponse(RandomGenerator.Next());
    }

    public int Id { get; }

    public SurveyResponse(int id)
    {
        Id = id;
    }

    private Dictionary<int, string>? _surveyResponses;

    public bool AnswerSurvey(IEnumerable<SurveyQuestion> questions)
    {
        if (ConsentToSurvey())
        {
            _surveyResponses = new Dictionary<int, string>();
            var index = 0;
            foreach (var question in questions)
            {
                var answer = GenerateAnswer(question);
                if (answer != null)
                {
                    _surveyResponses.Add(index, answer);
                }
                index++;
            }
        }
        return _surveyResponses != null;
    }

    private static string? GenerateAnswer(SurveyQuestion question)
    {
        switch (question.TypeOfQuestion)
        {
            case QuestionType.YesNo:
            {
                var randomAnswer = RandomGenerator.Next(-1, 2);
                return (randomAnswer == -1) ? default : (randomAnswer == 0) ? "No" : "Yes";
            }
            case QuestionType.Number:
            {
                var randomNumber = RandomGenerator.Next(-30, 101);
                return (randomNumber < 0) ? default : randomNumber.ToString();
            }
            case QuestionType.Text:
            default:
            {
                return "Hello";
            }
        }
    }

    private static bool ConsentToSurvey()
    {
        return RandomGenerator.Next(0, 2) == 1;
    }

    public bool AnsweredSurvey => _surveyResponses != null;
    public string Answer(int index) => _surveyResponses?.GetValueOrDefault(index) ?? "No answer";
}