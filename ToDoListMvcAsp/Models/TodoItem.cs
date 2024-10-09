using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoListMvcAsp.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}