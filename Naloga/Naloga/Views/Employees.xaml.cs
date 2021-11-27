using Naloga.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Naloga.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Employees : ContentPage
    {
        public ObservableCollection<Employee> employees = new ObservableCollection<Employee>()
        {
            new Employee{ID = -1, Name = "Čakam"}
        };

        public Employees() {
            InitializeComponent();
            MyListView.ItemsSource = employees;
        }

        protected override async void OnAppearing() {
            base.OnAppearing();
            await Init();
        }

        private async Task Init() {
            List<Employee> employees = await getEmployeesAsync();
            MyListView.ItemsSource = new ObservableCollection<Employee>(employees.Take(20));
        }



        private async Task<List<Employee>> getEmployeesAsync() {
            HttpClient client = new HttpClient();
            List<Employee> employees = null;
            string uri = "https://dummy.restapiexample.com/api/v1/employees";
            try {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode) {
                    string content = await response.Content.ReadAsStringAsync();
                    JObject parsedObj = JObject.Parse(content);
                    JToken data = parsedObj["data"];
                    employees = JsonConvert.DeserializeObject<List<Employee>>(data.ToString());
                }
            }
            catch (Exception e) {
                Debug.WriteLine(e.Message);
                throw;
            }

            return employees;
        }
    }
}
