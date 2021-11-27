using Naloga.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Naloga.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SyllabusPage : ContentPage
    {
        public ObservableCollection<Predmet> PredmetnikLetni { get; set; }
        public ObservableCollection<Predmet> PredmetnikZimski { get; set; }

        public SyllabusPage()
        {
            InitializeComponent();

            PredmetnikLetni = new ObservableCollection<Predmet>
            {
                new Predmet("Upravljanje IKT"),
                new Predmet("Podatkovne baze II"),
                new Predmet("Sistemska podpora IKT"),
                new Predmet("Podatkovno skladiščenje"),
                new Predmet("Izbirni predmet II2"),
                new Predmet("Izbirni predmet III2")

            };
            
            PredmetnikZimski = new ObservableCollection<Predmet>
            {
                new Predmet("Izbirni predmet IV3"),
                new Predmet("Praktično usposabljanje", 15),
                new Predmet("Diplomsko delo", 10)
            };

            MyListView.ItemsSource = PredmetnikLetni;
            MyListView.HeightRequest = PredmetnikLetni.Count * MyListView.RowHeight;
            MyListView1.ItemsSource = PredmetnikZimski;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
