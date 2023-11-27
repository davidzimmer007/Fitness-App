using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp
{
    public class User
    {
        // Jeder Wochentag hat eine liste mit den Übungen die man macht
        Dictionary<string, List<Uebung>> Plan = new Dictionary<string, List<Uebung>>
        {
            {"Montag",new List<Uebung>()},
            {"Dienstag",new List<Uebung>()},
            {"Mittwoch",new List<Uebung>()},
            {"Donnerstag",new List<Uebung >()},
            {"Freitag",new List< Uebung >()},
            {"Samstag",new List<Uebung>() },
            {"Sonntag",new List<Uebung>() }
        };

        public User()
        {
            Plan.Add("",new List<Uebung>());
        }

        public void AddUebung(string wochentag, Uebung uebung)
        {         
                Plan[wochentag].Add(uebung);
        }

        public void DeleteUebung(Uebung uebung)
        {
            foreach (var item in Plan)
            {
                item.Value.RemoveAll(u => u.Equals(uebung));
            }

        }

        public void SortNachSaetzeAll()
        {
            foreach (var p in Plan)
            {
                p.Value.Sort((u1, u2) => u1.Saetze.CompareTo(u2.Saetze)); 
            }
        }

        public void SortNachSaetzeTag(string wochentag)
        {
                Plan[wochentag].Sort((u1, u2) => u1.Saetze.CompareTo(u2.Saetze));
        }
    }
}
