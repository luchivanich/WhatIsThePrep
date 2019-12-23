namespace WhatIsThePrepDb
{
    public class ExampleDbService : IExampleDbService
    {
        public void AddExampleByString(ExampleModel exampleModel)
        {
            using (var dbContext = new WhatIsThePrepDbContext())
            {
                dbContext.Examples.Add(exampleModel);
                dbContext.SaveChanges();
            }
        }
    }
}
