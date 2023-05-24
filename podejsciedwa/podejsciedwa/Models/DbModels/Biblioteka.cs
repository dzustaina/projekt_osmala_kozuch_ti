using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace podejsciedwa.Models.DbModels
{
    public class Biblioteka
    {

        public int BibliotekaId { get; set; }   
        public string Nazwa { get; set; }
        public List<Film> Filmy { get; set; } = new List<Film>();

        public Biblioteka() { }
        public Biblioteka(int bibliotekaId, string nazwa, List<Film> filmy)
        {
            BibliotekaId = bibliotekaId;
            Nazwa = nazwa;
            Filmy = filmy;
        }
    }
}