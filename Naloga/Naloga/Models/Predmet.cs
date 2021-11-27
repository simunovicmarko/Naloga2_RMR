using System;
using System.Collections.Generic;
using System.Text;

namespace Naloga.Models
{
    public class Predmet
    {
        private Guid id;
        private string naziv;
        private int ects;
        private string semester;


        public Predmet(string naziv = "Dodaj naziv", int ects = 5)
        {
            this.id = Guid.NewGuid();
            this.Naziv = naziv;
            this.Ects = ects;
        }

        public Predmet(Guid id, string naziv, int ects, string semester) {
            this.id = id;
            this.naziv = naziv;
            this.ects = ects;
            this.semester = semester;
        }
        public Predmet(string naziv, int ects, string semester) {
            this.id = Guid.NewGuid();
            this.naziv = naziv;
            this.ects = ects;
            this.semester = semester;
        }

        public string CellPredmet
        {
            get
            {
                return $"id: {id}, naziv: {naziv}, ects: {ects}, semester: {semester}";
            }
        }

        public Guid Id { get => id; set => id = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public int Ects { get => ects; set => ects = value; }
        public string Semester { get => semester; set => semester = value; }
    }
}
