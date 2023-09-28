using System;

namespace Practica2
{
    public class Note
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public Note(string name, string description, DateTime date)
        {
            Name = name;
            Description = description;
            Date = date;
        }
    }
}
