using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace FitnessApp
{
    
    public partial class MainWindow : Window
    {
        public Muskeln Model { get; set; }
        public User User { get; set; }
        public UserControl1 PageChest { get; set; }
        public UserControl1 PageTriceps { get; set; }
        public UserControl1 PageShoulders { get; set; }
        public UserControl1 PageBiceps { get; set; }
        public UserControl1 PageMiddleBack { get; set; }
        public UserControl1 PageHamstrings { get; set; }

        public UserControl2 PagePlan {  get; set; }



        public MainWindow()
        {
            InitializeComponent();

            Model = new Muskeln();
            User = new User();

            DataContext = Model;
            MeineListBox.ItemsSource = Model.MuskelListe;

            ReadExerciseDataFromFile();
          
            PageChest = new UserControl1(Model.MuskelListe[0]);
            PageTriceps = new UserControl1(Model.MuskelListe[1]);
            PageShoulders = new UserControl1(Model.MuskelListe[2]);
            PageBiceps = new UserControl1(Model.MuskelListe[3]);
            PageMiddleBack = new UserControl1(Model.MuskelListe[4]);
            PageHamstrings = new UserControl1(Model.MuskelListe[5]);

            PagePlan = new UserControl2();

            MeinContentControl.Content = PageChest;
        }

       
        public void ReadExerciseDataFromFile()
        {
            Uebung uebung;
            try
            {
                string[] lines = File.ReadAllLines("./Data/Data.csv");

                foreach (string line in lines.Skip(1)) 
                {
                    string[] values = line.Split(',');

                    string exerciseName = Regex.Replace(values[0], "[^a-zA-Z\\s]","");
                    string exerciseImage = values[2].Replace("\"", "");
                    string exerciseImage2 = values[3].Replace("\"", ""); 
                    string muskelName = Regex.Replace(values[5], "[^a-zA-Z\\s]","");

                    if (Model.MuskelListe.Any(m => m.MuskelName == muskelName) && !string.IsNullOrEmpty(exerciseImage))
                    {
                       
                        uebung = new Uebung(exerciseName, exerciseImage);
                        
                    }
                    else if (Model.MuskelListe.Any(m => m.MuskelName == muskelName) && !string.IsNullOrEmpty(exerciseImage2))
                    {
                        uebung = new Uebung(exerciseName, exerciseImage2);
                    }
                    else
                    {
                        continue;
                    }

                    switch (muskelName)
                    {
                        case "Chest":
                            Model.MuskelListe[0].UebungenListe.Add(uebung);
                            break;
                        case "Triceps":
                            Model.MuskelListe[1].UebungenListe.Add(uebung);
                            break;
                        case "Shoulders":
                            Model.MuskelListe[2].UebungenListe.Add(uebung);
                            break;
                        case "Biceps":
                            Model.MuskelListe[3].UebungenListe.Add(uebung);
                            break;
                        case "Middle Back":
                            Model.MuskelListe[4].UebungenListe.Add(uebung);
                            break;
                        case "Hamstrings":
                            Model.MuskelListe[5].UebungenListe.Add(uebung);

                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }

        private void MeineListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Muskel selectedMuskel = (Muskel)MeineListBox.SelectedItem;
            switch (selectedMuskel.MuskelName)
            {
                case "Chest":
                    MeinContentControl.Content = PageChest;
                    break;
                case "Triceps":
                    MeinContentControl.Content = PageTriceps;
                    break;
                case "Shoulders":
                    MeinContentControl.Content = PageShoulders;
                    break;
                case "Biceps":
                    MeinContentControl.Content = PageBiceps;
                    break;
                case "Middle Back":
                    MeinContentControl.Content = PageMiddleBack;
                    break;
                case "Hamstrings":
                    MeinContentControl.Content = PageHamstrings;
                    break;
                default:
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MeinContentControl.Content = PagePlan;
        }
    }
}

