using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzer.Domain.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public ICollection<Option> Options { get; set; } = new HashSet<Option>();
    }
}
