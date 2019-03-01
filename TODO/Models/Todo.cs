using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TODO.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string TodoItem { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateFinished { get; set; }
    }
}
