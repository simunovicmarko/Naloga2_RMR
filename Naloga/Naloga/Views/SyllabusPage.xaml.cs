using Naloga.Models;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Naloga.FirebaseReaderWriter;

namespace Naloga.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SyllabusPage : ContentPage
    {
        public ObservableCollection<Predmet> PredmetnikLetni { get; set; }
        public ObservableCollection<Predmet> PredmetnikZimski { get; set; }

        public SyllabusPage() {
            InitializeComponent();
            //Init();


            //PredmetnikLetni = new ObservableCollection<Predmet>
            //{
            //    new Predmet("Upravljanje IKT", Semester.Letni),
            //    new Predmet("Podatkovne baze II", Semester.Letni),
            //    new Predmet("Sistemska podpora IKT", Semester.Letni),
            //    new Predmet("Podatkovno skladiščenje", Semester.Letni),
            //    new Predmet("Izbirni predmet II2", Semester.Letni),
            //    new Predmet("Izbirni predmet III2", Semester.Letni)

            //};

            //PredmetnikZimski = new ObservableCollection<Predmet>
            //{
            //    new Predmet("Izbirni predmet IV3", Semester.Zimski),
            //    new Predmet("Praktično usposabljanje", Semester.Zimski,15),
            //    new Predmet("Diplomsko delo", Semester.Zimski, 10)
            //};

            //FirebaseReaderWriter frw = new FirebaseReaderWriter();
            //foreach (var predmet in PredmetnikLetni) {
            //    frw.addPredmet(predmet);
            //}
            //foreach (var predmet in PredmetnikZimski) {
            //    frw.addPredmet(predmet);
            //}

            //MyListView.ItemsSource = PredmetnikLetni;
            //MyListView.HeightRequest = PredmetnikLetni.Count * MyListView.RowHeight;
            //MyListView1.ItemsSource = PredmetnikZimski;
        }

        protected override async void OnAppearing() {
            base.OnAppearing();
            await Init();
        }


        private async Task Init() {
            FirebaseReaderWriter frw = new FirebaseReaderWriter();
            var all = await frw.getAllPredmetAsync() ;
            PredmetnikLetni = new ObservableCollection<Predmet>(all.Where(x => x.Semester == Semester.Letni));
            PredmetnikZimski = new ObservableCollection<Predmet>(all.Where(x => x.Semester == Semester.Zimski));
            MyListView.ItemsSource = PredmetnikLetni;
            MyListView.HeightRequest = PredmetnikLetni.Count * MyListView.RowHeight;
            MyListView1.ItemsSource = PredmetnikZimski;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e) {
            if (e.Item == null)
                return;

            //await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private async void ZaposleniBtn_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new Employees());
        }
    }
}
