using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessApp
{
    public class Muskeln 
    {

       
        public List<Muskel> MuskelListe { get; set; }

        public Muskeln()
        {

            MuskelListe = new List<Muskel>();
            MuskelListe.Add(new Muskel("Chest"));
            MuskelListe.Add(new Muskel("Triceps"));
            MuskelListe.Add(new Muskel("Shoulders"));
            MuskelListe.Add(new Muskel("Biceps"));
            MuskelListe.Add(new Muskel("Middle Back"));
            MuskelListe.Add(new Muskel("Hamstrings"));
            // In Zukunft Lats, Quadriceps, Abdominals usw.

        }
    }
}