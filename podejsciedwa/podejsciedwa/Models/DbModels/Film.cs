using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace podejsciedwa.Models.DbModels
{

    public enum Gatunek { Komedia, Horror, Fantasy, SciFi, Kryminal, Thriller, Akcji, Dramat, Romans }
    public class Film
    {
        

        public int FilmId { get; set; }
        public string Tytul { get; set; }
        
        public Gatunek Gatunek { get; set; }
        public Film() { }
        public Film(int filmId, string tytul, Gatunek gatunek)
        {
            FilmId = filmId;
            Tytul = tytul;
            Gatunek = gatunek;
        }
        public int? AktorId { get; set; }
        public virtual Aktor Aktor { get; set; }
        public int? BibliotekaId { get; set; }
        public virtual Biblioteka Biblioteka { get; set; }
    }
}