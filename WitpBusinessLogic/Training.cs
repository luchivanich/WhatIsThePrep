namespace WitpBusinessLogic
{
    public class Training : ITraining
    {
        private readonly IExampleStorage _exampleStorage;

        public Training(IExampleStorage exampleStorage)
        {
            _exampleStorage = exampleStorage;
        }

        public IResponse CheckTheAnswer(IExample example, string answer)
        {
            return new Response
            {
                IsCorrect = answer.ToLower().Trim() == example.CorrectAnswer,
                CorrectAnswer = example.CorrectAnswer
            };
        }

        public IExample GetNextExample()
        {
            return _exampleStorage.GetRandomExample();
        }
    }
}
