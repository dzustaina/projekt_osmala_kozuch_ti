using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace podejsciedwa.Models.DbModels
{
    public class Aktor
    {
        
        public int AktorId { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public List<Film> Filmy { get; set; } = new List<Film>();
        
        public Aktor() { }
        public Aktor(int aktorId, string imie, string nazwisko, List<Film> filmy)
        {
            AktorId = aktorId;
            Imie = imie;
            Nazwisko = nazwisko;
            Filmy = filmy;
        }
    }
}