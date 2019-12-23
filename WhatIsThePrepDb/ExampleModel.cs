using System.ComponentModel.DataAnnotations.Schema;

namespace WhatIsThePrepDb
{
    [Table("Examples")]
    public class ExampleModel
    {
        public long Id { get; set; }
        public string Sentence { get; set; }
    }
}
