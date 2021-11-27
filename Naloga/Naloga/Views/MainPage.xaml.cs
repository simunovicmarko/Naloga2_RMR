using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Naloga.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        IAuth auth;
        private string token;

        public MainPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
            //FirebaseApp.initializeApp();
        }

        private async void LoginBtn_Clicked(object sender, EventArgs e)
        {
            //bool loggedIn = await Login(NameEntry.Text, PasswordEntry.Text);
            bool loggedIn = await Login("admin@admin.com", "123456");
            if (loggedIn) {
                await Navigation.PushAsync(new SyllabusPage());
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(1);
            NameEntry.Focus();
        }

        private async Task<bool> Login(string name, string password)
        {
            token = await auth.LoginWithEmailPassword(name, password);

            return token != null;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }
    }
}