using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizzer.Web.Models
{
    public class OptionViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionId { get; set; }
        public bool IsCorrectOption { get; set; }
    }
}