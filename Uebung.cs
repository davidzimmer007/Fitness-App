using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FitnessApp
{
    public class Uebung
    {
        public Uri Image { get; set; }
        public string Name { get; set; }
        public int Saetze { get; set; }
        public int Wiederholungen { get; set; }
        public Uebung(string name, string uri)
        {
            Name = name;
            Image =  new Uri(uri);
        }




        
    }
}