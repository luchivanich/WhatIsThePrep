namespace WitpBusinessLogic
{
    public interface ITraining
    {
        IExample GetNextExample();
        IResponse CheckTheAnswer(IExample example, string answer);
    }
}
