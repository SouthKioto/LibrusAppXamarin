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
            //AddSubjects();
        }
        public async void AddAdmin()
        {
            User user = new User()
            {
                Name = "Jan",
                Surname = "Kowalski",
                Login = "1234567",
                Password = "admin",
                IsTeacher = true
            };
            await App.Database.InsertUser(user);
        }

        public async void AddSubjects()
        {
            Subject subject = new Subject()
            {
                Name = "Chemia",
            };

            Subject subject1 = new Subject()
            {
                Name = "Biologia",
            };

            Subject subject2 = new Subject()
            {
                Name = "Geografia",
            };

            Subject subject3 = new Subject()
            {
                Name = "WF",
            };

            Subject subject4 = new Subject()
            {
                Name = "Matematyka",
            };

            await App.Database.InsertSubject(subject);
            await App.Database.InsertSubject(subject1);
            await App.Database.InsertSubject(subject2);
            await App.Database.InsertSubject(subject3);
            await App.Database.InsertSubject(subject4);
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