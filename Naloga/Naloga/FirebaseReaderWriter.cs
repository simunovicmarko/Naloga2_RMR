using Firebase.Database;
using Firebase.Database.Query;
using Naloga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Naloga
{
    public partial class FirebaseReaderWriter
    {
        private readonly string childName = "Predmeti";
        private readonly FirebaseClient firebase = new FirebaseClient("https://rmr-test3-default-rtdb.firebaseio.com/");

        public async Task<IEnumerable<Predmet>> getAllPredmetAsync() {
            var temp = (await firebase.Child(childName).OnceAsync<Predmet>()).Select(item => new Predmet
                {
                    Id = item.Object.Id,
                    Naziv = item.Object.Naziv,
                    Semester = item.Object.Semester,
                    Ects = item.Object.Ects
                }).ToList();
            return temp;
        }

        public async Task<IEnumerable<Predmet>> getPredmetnik(Semester semester) {
            var predmeti = await getAllPredmetAsync();
            predmeti = predmeti.Where(p => p.Semester == semester);
            return predmeti;
        }



        public async void addPredmet(Predmet predmet) {
            await firebase.Child(childName).PostAsync(predmet);
        }
    }
}
