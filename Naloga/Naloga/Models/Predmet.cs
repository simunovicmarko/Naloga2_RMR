using System;
using System.Collections.Generic;
using System.Text;
using static Naloga.FirebaseReaderWriter;

namespace Naloga.Models
{
    public class Predmet
    {
        public Guid Id { get; set; }
        public string Naziv { get; set; }
        public int Ects { get; set; }
        public Semester Semester { get; set; }

        //public Predmet(string naziv = "Dodaj naziv", int ects = 5)
        //{
        //    this.Id = GuId.NewGuId();
        //    this.Naziv = naziv;
        //    this.Ects = ects;
        //}

        //public Predmet(GuId Id, string naziv, Semester semester, int ects = 5) {
        //    this.Id = Id;
        //    this.naziv = Naziv;
        //    this.ects = ects;
        //    this.semester = semester;
        //}
        //public Predmet(string Naziv, Semester semester, int ects = 5) {
        //    this.Id = GuId.NewGuId();
        //    this.Naziv = Naziv;
        //    this.ects = ects;
        //    this.semester = semester;
    }

    //public string CellPredmet
    //{
    //    get
    //    {
    //        return $"Id: {Id}, Naziv: {Naziv}, ects: {ects}, semester: {semester}";
    //    }
    //}

}

