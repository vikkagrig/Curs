using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static SQLite.SQLite3;

namespace PCMob
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Reg : ContentPage
    {
        byte[] data = null;
        public Reg()
        {
            InitializeComponent();
            var tapFinance = new TapGestureRecognizer();
            var tapFinance2 = new TapGestureRecognizer();
            tapFinance.Tapped += async (s, e) =>
            {
                pas.IsPassword = false;
                im1.WidthRequest = 0;
                im2.WidthRequest = 20;
                im1.IsVisible = false;
                im2.IsVisible = true;
            };
            im1.GestureRecognizers.Add(tapFinance);
            tapFinance2.Tapped += async (s, e) =>
            {
                pas.IsPassword = true;
                im1.WidthRequest = 20;
                im2.WidthRequest = 0;
                im2.IsVisible = false;
                im1.IsVisible = true;
            };
            im2.GestureRecognizers.Add(tapFinance2);
            var tapFinance3 = new TapGestureRecognizer();
            var tapFinance4 = new TapGestureRecognizer();
            tapFinance3.Tapped += async (s, e) =>
            {
                pas2.IsPassword = false;
                im3.WidthRequest = 0;
                im4.WidthRequest = 20;
                im3.IsVisible = false;
                im4.IsVisible = true;
            };
            im3.GestureRecognizers.Add(tapFinance3);
            tapFinance4.Tapped += async (s, e) =>
            {
                pas2.IsPassword = true;
                im3.WidthRequest = 20;
                im4.WidthRequest = 0;
                im4.IsVisible = false;
                im3.IsVisible = true;
            };
            im4.GestureRecognizers.Add(tapFinance4);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (log.Text != null && pas.Text != "" && pas2.Text != null && f.Text != null && i.Text != null && o.Text != null && p.Text != null && ege.Text != null &&
               log.Text.Trim() != "" && pas.Text.Trim() != "" && pas2.Text.Trim() != "" && f.Text.Trim() != "" && i.Text.Trim() != "" &&
                   o.Text.Trim() != "" && d.Date != null && p.Text.Trim() != "" && ege.Text.Trim() != "" && data != null &&
                   int.Parse(ege.Text.Trim()) > 0 && int.Parse(ege.Text.Trim()) < 500)
                {
                    if (pas.Text == pas2.Text)
                    {
                        try
                        {
                            User user = new User()
                            {
                                Login = log.Text.Trim(),
                                Password = pas.Text.Trim(),
                                Role = "Абитуриент"
                            };
                            App.Database.USaveItem(user);
                            Entrant entrant = new Entrant()
                            {
                                IDUser = user.IDUser,
                                FirstName = i.Text.Trim(),
                                LastName = f.Text.Trim(),
                                FatherName = o.Text.Trim(),
                                PersonalyData = p.Text.Trim(),
                                DateBirthday = d.Date,
                                Point = int.Parse(ege.Text.Trim()),
                                Photo = data
                            };
                            App.Database.SaveItem(entrant);
                            DisplayAlert("Уведомление", "Пользователь успешно добавлен", "ОK");
                            await Navigation.PopAsync();
                        }
                        catch
                        {
                            DisplayAlert("Уведомление", "Ошибка", "ОK");
                        }
                    }
                    else
                    {
                        DisplayAlert("Уведомление", "Пароли не совпадают", "ОK");
                    }
                }
                else
                {
                    DisplayAlert("Уведомление", "Не все поля заполнены", "ОK");
                }
            }
           catch
            {
                DisplayAlert("Уведомление", "Ошибка", "ОK");
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                var ph = await MediaPicker.PickPhotoAsync();
                var newFile = Path.Combine(FileSystem.AppDataDirectory, ph.FileName);
            using (var stream = await ph.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
            {
                await stream.CopyToAsync(newStream);
            }
            using (var newStream = File.OpenRead(newFile))
            {
                MemoryStream ms = new MemoryStream();
                newStream.Position = 0;
                newStream.Position = 0;
                newStream.CopyTo(ms);
                data = ms.ToArray();
            }
                im.Text = "Успешно загружено";
            }
            catch
            {
                im.Text = "Ошибка";
            }
        }
    }
}