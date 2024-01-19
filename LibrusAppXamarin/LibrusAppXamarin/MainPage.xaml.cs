using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LibrusAppXamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void LoginAndGoToMainPage(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(login_entry.Text) || String.IsNullOrEmpty(haslo_entry.Text))
            {

            }
        }
    }
}
