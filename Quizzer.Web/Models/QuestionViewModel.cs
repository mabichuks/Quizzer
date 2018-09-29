using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizzer.Web.Models
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int CategoryId { get; set; }
    }
}