using LibrusAppXamarin.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LibrusAppXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            //AddAdmin();
        }
        public async void AddAdmin()
        {
            User user = new User()
            {
                Name = "Jan",
                Surname = "Kowalski",
                Login = "123456789",
                Password = "admin",
                IsTeacher = true
            };
            await App.Database.InsertUser(user);
        }

        private async void LogiClickCheckPerson(object sender, EventArgs e)
        {
            var users = await App.Database.FilterUsers(loginEntry.Text, passwordEntry.Text);
            if (loginEntry.Text.Length != 7 || users.Count == 0)
            {
                await DisplayAlert("Błąd", "Podano nieprawidlowe dane", "OK");
                return;
            }

            var user = users.ElementAt(0);
            await Navigation.PushAsync(new MainPage(user));
        }
    }
}