using System;
using System.Collections.Generic;
using System.Text;

namespace WitpBusinessLogic
{
    public interface IExample
    {
        string Sentence { get; set; }

        bool CheckTheAnswer(string answer);
    }
}
