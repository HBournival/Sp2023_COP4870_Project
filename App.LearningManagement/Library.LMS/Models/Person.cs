﻿namespace Library.LMS.Models
{
    public class Person 
    {
        public int Id { get; set; }
        public string? Name { get; set; }
       

        public Person()
        {
            Name = string.Empty;
        }

        public override string ToString()
        {
            return $"[{Id}] {Name}";
        }
    }

    public enum PersonClassification
    {
        Freshman, Sophomore, Junior, Senior
    }
}