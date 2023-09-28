using System;
using System.Collections.Generic;
using System.IO;

namespace Practica2
{
    public static class SaveLoad
    {
        private const string FileName = "notes.txt";

        public static void Save(List<Note> notes)
        {
            using (StreamWriter writer = new StreamWriter(FileName))
            {
                foreach (Note note in notes)
                {
                    writer.WriteLine($"{note.Name}|{note.Description}|{note.Date}");
                }
            }
        }

        public static List<Note> Load()
        {
            List<Note> notes = new List<Note>();
            if (File.Exists(FileName))
            {
                using (StreamReader reader = new StreamReader(FileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');
                        if (parts.Length == 3)
                        {
                            string name = parts[0];
                            string description = parts[1];
                            DateTime date = DateTime.Parse(parts[2]);
                            notes.Add(new Note(name, description, date));
                        }
                    }
                }
            }
            return notes;
        }
    }
}
