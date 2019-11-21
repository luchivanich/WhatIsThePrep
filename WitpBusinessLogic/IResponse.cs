namespace WitpBusinessLogic
{
    public interface IResponse
    {
        public bool IsCorrect { get; set; }

        public string CorrectAnswer { get; set; }
    }
}
