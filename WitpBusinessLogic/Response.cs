namespace WitpBusinessLogic
{
    public class Response : IResponse
    {
        public bool IsCorrect { get; set; }
        public string CorrectAnswer { get; set; }
    }
}
