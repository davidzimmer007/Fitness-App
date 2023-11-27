using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessApp
{
    public class Muskel
    {
        public string MuskelName { get; set; }
        public List<Uebung> UebungenListe { get; set; }

        public Muskel(string name)
        {
            MuskelName = name;
            UebungenListe = new List<Uebung>();

        }
    }
}