using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WitpBusinessLogic
{
    public class FileExampleGenerator : IExampleStorage
    {
        private List<string> _sentences;

        private readonly List<string> _commonPrepositions = new List<string>
        {
            "in",
            "at",
            "on",
            "of",
            "with"
        };

        public FileExampleGenerator()
        {
            var text = File.ReadAllText("text.txt");
            _sentences = Regex.Split(text, @"(?<=[\.!\?])(?<!Mr\.|Mrs\.|Dr\.|Ms\.|St\.|a\.m\.|p\.m\.)\s+").ToList();
        }

        public IExample GetRandomExample()
        {
            var i = 0;
            while(i < 10)
            {
                var rnd = new Random();
                var index = rnd.Next(0, _sentences.Count - 1);

                (var hasPreposition, var sentence, var correctAnswer) = IsContainPreposition(_sentences[index]);

                if (hasPreposition)
                {
                    return new Example
                    {
                        Sentence = sentence,
                        CorrectAnswer = correctAnswer
                    };
                }
                i++;
            }
            return null;
        }

        private (bool, string, string) IsContainPreposition(string sentence)
        {
            var boolResult = false;
            var stringResult = sentence;
            foreach(var prep in _commonPrepositions)
            {
                if (sentence.Contains($" {prep} "))
                {
                    return (true, stringResult.Replace($" {prep} ", " [?] "), prep);
                }
            }
            return (false, null, null);
        }
    }
}
