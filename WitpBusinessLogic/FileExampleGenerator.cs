using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WitpBusinessLogic
{
    public class FileExampleGenerator : IExampleStorage
    {
        private const int SENTENCE_MAX_LENGTH = 80;

        private List<string> _allSentences = new List<string>();
        private List<IExample> _exampleSentences = new List<IExample>();

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
            
        }

        public void Init()
        {
            var text = File.ReadAllText("text.txt");
            _allSentences = Regex.Split(text, @"(?<=[\.!\?])(?<!Mr\.|Mrs\.|Dr\.|Ms\.|St\.|a\.m\.|p\.m\.)\s+").ToList();
        }

        public IExample GetExample()
        {
            while (_allSentences.Count > 0)
            {
                var sentence = _allSentences.First();
                _allSentences.Remove(sentence);

                var example = CreateExample(sentence);
                if (example != null)
                {
                    _exampleSentences.Add(example);
                    return example;
                }
            }

            return GetRandomExample();
        }

        private IExample CreateExample(string sentence)
        {
            var stringResult = sentence;
            foreach (var prep in _commonPrepositions)
            {
                if (sentence.Length <= SENTENCE_MAX_LENGTH && sentence.Contains($" {prep} "))
                {
                    return new Example
                    {
                        Sentence = stringResult.Replace($" {prep} ", " [?] "),
                        CorrectSentence = sentence,
                        CorrectAnswer = prep
                    };
                }
            }
            return null;
        }

        private IExample GetRandomExample()
        {
            if (_exampleSentences.Count == 0)
            {
                return null;
            }

            var rnd = new Random();
            var index = rnd.Next(0, _exampleSentences.Count - 1);
            return _exampleSentences[index];
        }
    }
}
