using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCMob
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Red : ContentPage
    {
        byte[] img = null;
        User user;
        Profile profile;
        public Red(User user, Profile profile)
        {
            InitializeComponent();
            this.user = user;
            foreach (var e in App.database.GetItems().ToList())
            {
                if (e.IDUser == user.IDUser)
                {
                    f.Text = e.LastName;
                    i.Text = e.FirstName;
                    o.Text = e.FatherName;
                    d.Date = (DateTime)e.DateBirthday;
                    p.Text = e.PersonalyData;
                    ege.Text = e.Point.ToString();
                }
            }

            this.profile = profile;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (im.Text == "Успешно загружено")
                {
                    Entrant entrant = null;
                    foreach (var en in App.database.GetItems().ToList())
                    {
                        if (en.IDUser == this.user.IDUser)
                        {
                            entrant = App.database.GetItem(en.IDEntrant);
                            break;
                        }
                    }
                    if (f.Text.Trim() != "" && i.Text.Trim() != "" && o.Text.Trim() != "" && p.Text.Trim() != "" && ege.Text.Trim() != "" && int.Parse(ege.Text.Trim()) > 0 && int.Parse(ege.Text.Trim()) < 500)
                    {
                        try
                        {
                            if (d.Date < DateTime.ParseExact("01.01.2010".ToString(), "dd.mm.yyyy", System.Globalization.CultureInfo.InvariantCulture) && d.Date > DateTime.ParseExact("01.01.1923".ToString(), "dd.mm.yyyy", System.Globalization.CultureInfo.InvariantCulture))
                            {
                                entrant.LastName = f.Text;
                                entrant.FirstName = i.Text;
                                entrant.FatherName = o.Text;
                                entrant.DateBirthday = d.Date;
                                entrant.PersonalyData = p.Text;
                                entrant.Point = int.Parse(ege.Text);
                                entrant.Photo = img;
                                App.database.SaveItem(entrant);
                                profile.NewData();
                                DisplayAlert("Уведомление", "Успешно изменено", "ОK");
                                await Navigation.PopAsync();
                            }
                            else
                            {
                                DisplayAlert("Уведомление", "Неверная дата рождения", "ОK");
                            }
                        }
                        catch
                        {
                            DisplayAlert("Уведомление", "Неверно введены данные", "ОK");
                        }
                    }
                    else
                    {
                        DisplayAlert("Уведомление", "Неверно введены данные", "ОK");
                    }
                }
                else
                {
                    Entrant entrant = null;
                    foreach (var en in App.database.GetItems().ToList())
                    {
                        if (en.IDUser == this.user.IDUser)
                        {
                            entrant = App.database.GetItem(en.IDEntrant);
                            break;
                        }
                    }
                    if (f.Text.Trim() != "" && i.Text.Trim() != "" && o.Text.Trim() != "" && p.Text.Trim() != "" && ege.Text.Trim() != "" && int.Parse(ege.Text.Trim()) > 0 && int.Parse(ege.Text.Trim()) < 500)
                    {
                        try
                        {
                            if (d.Date < DateTime.ParseExact("01.01.2010".ToString(), "dd.mm.yyyy", System.Globalization.CultureInfo.InvariantCulture) && d.Date > DateTime.ParseExact("01.01.1923".ToString(), "dd.mm.yyyy", System.Globalization.CultureInfo.InvariantCulture))
                            {
                                entrant.LastName = f.Text;
                                entrant.FirstName = i.Text;
                                entrant.FatherName = o.Text;
                                entrant.DateBirthday = d.Date;
                                entrant.PersonalyData = p.Text;
                                entrant.Point = int.Parse(ege.Text);
                                App.database.SaveItem(entrant);
                                profile.NewData();
                                DisplayAlert("Уведомление", "Успешно изменено", "ОK");
                                await Navigation.PopAsync();
                            }
                            else
                            {
                                DisplayAlert("Уведомление", "Неверная дата рождения", "ОK");
                            }
                        }
                        catch
                        {
                            DisplayAlert("Уведомление", "Неверно введены данные", "ОK");
                        }
                    }
                    else
                    {
                        DisplayAlert("Уведомление", "Неверно введены данные", "ОK");
                    }
                }
            }
            catch
            {
                DisplayAlert("Уведомление", "Неверно введены данные", "ОK");
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
                    img = ms.ToArray();
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