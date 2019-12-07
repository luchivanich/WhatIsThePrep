
namespace WitpBusinessLogic
{
    public class MockTraining : ITraining
    {
        public IExample GetNextExample()
        {
            return new Example
            {
                Sentence = "Some sentence [?] some preposition",
                CorrectAnswer = "with"
        };
        }
    }
}
