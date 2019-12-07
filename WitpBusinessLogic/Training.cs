namespace WitpBusinessLogic
{
    public class Training : ITraining
    {
        private readonly IExampleStorage _exampleStorage;

        public Training(IExampleStorage exampleStorage)
        {
            _exampleStorage = exampleStorage;
        }

        public IExample GetNextExample()
        {
            return _exampleStorage.GetRandomExample();
        }
    }
}
