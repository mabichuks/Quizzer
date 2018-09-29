﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzer.Domain.Entities
{
    public class Option
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual Question Question { get; set; }
        public int QuestionId { get; set; }
        public bool IsCorrectOption { get; set; }
    }
}
