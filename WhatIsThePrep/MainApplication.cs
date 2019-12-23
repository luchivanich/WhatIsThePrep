using System;
using WhatIsThePrepDb;
using WitpBusinessLogic;

namespace WhatIsThePrep
{
    public class MainApplication : IApplication
    {
        private readonly ITraining _training;
        private readonly IExampleDbService _exampleDbService;

        public MainApplication(ITraining training, IExampleDbService exampleDbService)
        {
            _training = training;
            _exampleDbService = exampleDbService;
        }

        public void Run()
        {
            while(true)
            {
                var example = _training.GetNextExample();
                if (example == null)
                {
                    Console.WriteLine("Thank you and goodbye");
                    return;
                }
                Console.WriteLine(example.Sentence);
                var answer = Console.ReadLine();
                if (answer.Equals(example.CorrectAnswer, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Congratulations!");
                }
                else
                {
                    Console.WriteLine(example.CorrectAnswer);
                }

                Console.WriteLine("Would you like to add this example to the DB? Y/N");
                var yesNo = Console.ReadLine();
                if (yesNo.Equals("y", StringComparison.OrdinalIgnoreCase) || yesNo.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    _exampleDbService.AddExampleByString(new ExampleModel { Sentence = example.CorrectSentence });
                }
            }
        }
    }
}
