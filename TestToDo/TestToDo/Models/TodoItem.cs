using SQLite;
using System;

namespace TestToDo.Models
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int TodoId { get; set; }
        public string TodoName { get; set; }
        public bool Completed { get; set; }
        public DateTime Created { get; set; }
    }
}
