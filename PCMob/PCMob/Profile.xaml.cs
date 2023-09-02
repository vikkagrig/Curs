using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCMob
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        private User user;
        public Profile(User user)
        {
            InitializeComponent();
            this.user = user;
            NewData();
            TapGestureRecognizer tapGesture1 = new TapGestureRecognizer();
            tapGesture1.Tapped += async (s, e) =>
            {
                    await Navigation.PushAsync(new Red(this.user, this));
            };
            red.GestureRecognizers.Add(tapGesture1);
        }
        public void NewData()
        {
            lastname.Text = "";
            firstname.Text = "";
            fathname.Text = "";
            hb.Text = "";
            pasp.Text = "";
            ege.Text = "";
            ph.Source = null;
            foreach (var e in App.database.GetItems().ToList())
                {
                    if (e.IDUser == user.IDUser)
                    {
                        lastname.Text = e.LastName;
                        firstname.Text = e.FirstName;
                        fathname.Text = e.FatherName;
                        hb.Text = e.DateBirthday.ToString().Substring(0, 10);
                        pasp.Text = e.PersonalyData;
                        ege.Text = e.Point.ToString();
                        MemoryStream stream = new MemoryStream(e.Photo);
                        ph.Source = ImageSource.FromStream(() => stream);
                    }
                }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Speciality(this.user));
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Spisky());
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new My(this.user));
        }

    }
}