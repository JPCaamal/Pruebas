using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios.Models
{

    public class questionType
    {       
        public const char onlyOneAnswer = 'A';
        public const char boolean = 'B';
        public const char moreThanOneAnswer = 'C';
        public const char moreThanOneAnswerAll = 'D';
    }

    public class Options
    {
        public int ID_option { get; set; }
        public string option_description { get; set; }
        public bool option_value { get; set; }
    }

    public class Questions
    {
        public int ID_question{ get; set; }
        public string question_description { get; set; }
        public char question_type { get; set; }
        public int question_points { get; set; }
        public List<Options> question_options { get; set; }
    }
}