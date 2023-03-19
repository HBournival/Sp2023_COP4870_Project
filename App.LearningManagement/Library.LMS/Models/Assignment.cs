﻿
namespace Library.LMS.Models
{
    public class Assignment
    {
        private static int lastId = 0;
        public int Id
        { 
            get;
            private set; 
        }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal tPoints { get; set; }
        public DateTime DueDate { get; set; }

        public Assignment()
        {
            Id = ++lastId;
        }
        public override string ToString()
        {
            return $"[{Id}] {Name} - {DueDate}";
        }
    }
}
