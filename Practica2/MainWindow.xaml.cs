using Practica2;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace Practica2
{
    public partial class MainWindow : Window
    {
        int idSelected;
        List<Note> notes;
        List<Note> selectedNotes = new List<Note>();

        public MainWindow()
        {
            InitializeComponent();
            notes = SaveLoad.Load();
            DatePicker.SelectedDate = DateTime.Now;
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime date = DatePicker.SelectedDate ?? DateTime.Now;
            List<string> noteNames = new List<string>();
            selectedNotes.Clear();

            foreach (Note note in notes)
            {
                if (note.Date == date)
                {
                    selectedNotes.Add(note);
                    noteNames.Add(note.Name);
                }
            }
            Menu.ItemsSource = noteNames;
        }

        private void Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Menu.SelectedItem != null)
            {
                for (int i = 0; i < selectedNotes.Count; i++)
                {
                    if (Menu.SelectedItem.ToString() == selectedNotes[i].Name)
                    {
                        Name.Text = selectedNotes[i].Name;
                        Text.Text = selectedNotes[i].Description;
                        idSelected = i;
                    }
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedNotes.Count > 0 && idSelected >= 0 && idSelected < selectedNotes.Count)
            {
                notes.Remove(selectedNotes[idSelected]);
                UpDate();
                SaveLoad.Save(notes);
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            notes.Add(new Note(Name.Text, Text.Text, DatePicker.SelectedDate ?? DateTime.Now));
            UpDate();
            SaveLoad.Save(notes);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedNotes.Count > 0 && idSelected >= 0 && idSelected < selectedNotes.Count)
            {
                notes.Remove(selectedNotes[idSelected]);
                notes.Add(new Note(Name.Text, Text.Text, DatePicker.SelectedDate ?? DateTime.Now));
                UpDate();
                SaveLoad.Save(notes);
            }
        }

        private void UpDate()
        {
            DateTime date = DatePicker.SelectedDate ?? DateTime.Now;
            List<string> noteNames = new List<string>();
            selectedNotes.Clear();

            foreach (Note note in notes)
            {
                if (note.Date == date)
                {
                    selectedNotes.Add(note);
                    noteNames.Add(note.Name);
                }
            }
            Menu.ItemsSource = noteNames;
        }
    }
}
