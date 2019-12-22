namespace WitpBusinessLogic
{
    public class SimpleExample
    {
        public string Sentence { get; set; }
        public string CorrectAnswer { get; set; }

        public SimpleExample(string sentence, string correctAnswer)
        {
            Sentence = sentence;
            CorrectAnswer = correctAnswer;
        }
    }
}
