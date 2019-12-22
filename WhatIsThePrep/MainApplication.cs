using System;
using System.Collections.Generic;
using WitpBusinessLogic;

namespace WhatIsThePrep
{
    public class MainApplication : IApplication
    {
        private readonly ITraining _training;

        public MainApplication(ITraining training)
        {
            _training = training;
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
            }
        }
    }
}
