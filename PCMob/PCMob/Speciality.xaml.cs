using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.DataGrid;
using static System.Net.Mime.MediaTypeNames;

namespace PCMob
{
    public class TestData
    {
        public string Column1 { get; set; }
        public string Column2 { get; set; }
        public int Column3 { get; set; }
        public int Column4 { get; set; }
        public int Column5 { get; set; }
        public int Column6 { get; set; }
        public int Column7 { get; set; }
    }
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Speciality : ContentPage
    {
        User user;
        Entrant entrant;
        public Speciality(User user)
        {
            foreach (var e in App.database.GetItems().ToList())
            {
                if (e.IDUser == user.IDUser)
                {
                    entrant = App.database.GetItem(e.IDEntrant);
                }
            }
            InitializeComponent();
            this.user = user;
            for (int i = 0; i < App.database.FGetItems().ToList().Count; i++)
            {
                inst.Items.Add(App.database.FGetItems().ToList()[i].Name);
            }
            for (int i = 0; i < App.database.SGetItems().ToList().Count; i++)
            {
                spec.Items.Add(App.database.SGetItems().ToList()[i].Name);
            }
            foreach (var i in App.database.LGetItems().ToList())
            {
                if (i.IDEntrant == entrant.IDEntrant)
                {
                    foreach (String c in pr.Items)
                    {
                        if (int.Parse(c.ToString()) == i.Priority)
                        {
                            pr.Items.Remove(c);
                            break;
                        }
                    }
                }
            }
        }

        private void inst_SelectedIndexChanged(object sender, EventArgs e)
        {
            table.IsVisible = true;
            table.HeightRequest = 150;
            int n = 0;
            int index = inst.SelectedIndex;
            List<TestData> data = new List<TestData>();
            foreach (var item in App.database.SGetItems().ToList())
            {
                if (item.IDFac == index + 1)
                {
                    data.Add(new TestData
                    {
                        Column1 = item.Code,
                        Column2 = item.Name,
                        Column3 = (int)item.PlaceBudget,
                        Column4 = (int)item.PlaceCommerce,
                        Column5 = (int)item.Duration,
                        Column6 = (int)item.Mark,
                        Column7 = (int)item.Cost
                    });
                    n++;
                }
            }
            table.ItemsSource = data;
            table.CellStyle = new GridCellStyle
            {
                BackgroundColor = Color.White
            }; jhbhbn;
            num.Text = n.ToString();
                if (n == 1)
                {
                    text.Text = " специальность";
                }
                else if (n == 2 || n == 3 || n == 4)
                {
                    text.Text = " специальности";
                }
                else
                    text.Text = " специальностей";
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if(spec.SelectedIndex != -1 && pr.SelectedIndex != -1 && form.SelectedIndex != -1)
            {
                bool flag = true;
                    int id = 0;
                    foreach (var i in App.database.SGetItems().ToList())
                    {
                        if (i.Code == spec.SelectedItem.ToString())
                            id = i.IDSpec;
                    }
                    foreach (var l in App.database.LGetItems().ToList())
                    {
                        if (l.IDSpec == id && l.IDEntrant == entrant.IDEntrant)
                        {
                        DisplayAlert("Уведомление", "Вы уже подали заявление на эту специальности", "ОK");
                        flag = false;
                            break;
                        }
                    }
                    if (flag == true)
                    {
                        List list = new List()
                        {
                            FormStudy = form.SelectedItem.ToString(),
                            Priority = int.Parse(pr.SelectedItem.ToString()),
                            IDSpec = id,
                            IDEntrant = entrant.IDEntrant
                        };
                    App.database.LSaveItem(list);
                    DisplayAlert("Уведомление", "Заявление успешно подано", "ОK");
                    await Navigation.PopAsync();
                }
            }
            else
            {
                DisplayAlert("Уведомление", "Не все поля заполнены", "ОK");
            }
        }
    }
}