using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;

namespace PCMob
{
    public partial class MainPage : ContentPage
    {
        bool isClosed = false;
        bool flag = false;
        public MainPage()
        {
            InitializeComponent();
            if (flag == false)
            {
                try
                {
                    foreach (var i in App.Database.FGetItems().ToList())
                    {
                        App.Database.FDeleteItem(i.IDFac);
                    }
                    foreach (var i in App.Database.SGetItems().ToList())
                    {
                        App.Database.SDeleteItem(i.IDSpec);
                    }
                }
                catch { }
                Faculty[] faculty = new Faculty[6];
                Spaciality[] spacialities = new Spaciality[31];
                faculty[0] = new Faculty()
                {
                    Name = "Институт авиации и электронного приборостроения",
                    Description = "Описание ИАНТЭ"
                };
                faculty[1] = new Faculty()
                {
                    Name = "Физико-математический факультет",
                    Description = "Описание ФМФ"
                };
                faculty[2] = new Faculty()
                {
                    Name = "Институт автоматики и электронного приборостроения",
                    Description = "Описание ИАЭП"
                };
                faculty[3] = new Faculty()
                {
                    Name = "Институт компьютерных технологий и защиты информации",
                    Description = "Описание ИКТЗИ"
                };
                faculty[4] = new Faculty()
                {
                    Name = "Институт радиоэлектроники, фотоники и цифровых технологий",
                    Description = "Описание ИРЭФ-ЦТ"
                };
                faculty[5] = new Faculty()
                {
                    Name = "Институт инженерной экономики и предпринимательства",
                    Description = "Описание ИИЭиП"
                };
                for (int i = 0; i < 6; i++)
                {
                    App.Database.FSaveItem(faculty[i]);
                }
                spacialities[0] = new Spaciality()
                {
                    Name = "Теплоэнергетика и теплотехника",
                    Code = "13.03.01",
                    Duration = 4,
                    PlaceBudget = 25,
                    PlaceCommerce = 5,
                    Mark = 172,
                    Cost = 135000,
                    IDFac = 1
                };
                spacialities[1] = new Spaciality()
                {
                    Name = "Энергетическое машиностроение",
                    Code = "13.03.03",
                    Duration = 4,
                    PlaceBudget = 30,
                    PlaceCommerce = 5,
                    Mark = 173,
                    Cost = 135000,
                    IDFac = 1
                };
                spacialities[2] = new Spaciality()
                {
                    Name = "Лазерная техника и лазерные технологии",
                    Code = "12.03.05",
                    Duration = 4,
                    PlaceBudget = 20,
                    PlaceCommerce = 5,
                    Mark = 215,
                    Cost = 135000,
                    IDFac = 2
                };
                spacialities[3] = new Spaciality()
                {
                    Name = "Техническая физика",
                    Code = "16.03.13",
                    Duration = 4,
                    PlaceBudget = 40,
                    PlaceCommerce = 5,
                    Mark = 166,
                    Cost = 165000,
                    IDFac = 2
                };
                spacialities[4] = new Spaciality()
                {
                    Name = "Наноинженерия",
                    Code = "28.03.02",
                    Duration = 4,
                    PlaceBudget = 25,
                    PlaceCommerce = 5,
                    Mark = 190,
                    Cost = 180000,
                    IDFac = 2
                };
                spacialities[5] = new Spaciality()
                {
                    Name = "Машиностроение",
                    Code = "15.03.01",
                    Duration = 4,
                    PlaceBudget = 22,
                    PlaceCommerce = 5,
                    Mark = 183,
                    Cost = 148000,
                    IDFac = 1
                };
                spacialities[6] = new Spaciality()
                {
                    Name = "Конструкторско-технологическое обеспечение машиностроительных производств",
                    Code = "15.03.05",
                    Duration = 4,
                    PlaceBudget = 42,
                    PlaceCommerce = 5,
                    Mark = 179,
                    Cost = 148000,
                    IDFac = 1
                };
                spacialities[7] = new Spaciality()
                {
                    Name = "Материаловедение и технологии материалов",
                    Code = "22.03.01",
                    Duration = 4,
                    PlaceBudget = 44,
                    PlaceCommerce = 5,
                    Mark = 202,
                    Cost = 148000,
                    IDFac = 1
                };
                spacialities[8] = new Spaciality()
                {
                    Name = "Эксплуатация транспортно-технологических машин и комплексов",
                    Code = "23.03.03",
                    Duration = 4,
                    PlaceBudget = 40,
                    PlaceCommerce = 10,
                    Mark = 178,
                    Cost = 148000,
                    IDFac = 1
                }; 
                spacialities[9] = new Spaciality()
                {
                    Name = "Авиастроение",
                    Code = "24.03.04",
                    Duration = 4,
                    PlaceBudget = 55,
                    PlaceCommerce = 20,
                    Mark = 227,
                    Cost = 185000,
                    IDFac = 1
                };
                spacialities[10] = new Spaciality()
                {
                    Name = "Двигатели летательных аппаратов",
                    Code = "24.03.05",
                    Duration = 4,
                    PlaceBudget = 25,
                    PlaceCommerce = 15,
                    Mark = 195,
                    Cost = 185000,
                    IDFac = 1
                };
                spacialities[11] = new Spaciality()
                {
                    Name = "Техническая эксплуатация летательных аппаратов и двигателей",
                    Code = "25.03.01",
                    Duration = 4,
                    PlaceBudget = 14,
                    PlaceCommerce = 15,
                    Mark = 184,
                    Cost = 185000,
                    IDFac = 1
                };
                spacialities[12] = new Spaciality()
                {
                    Name = "Кораблестроение, океанотехника и системотехника объектов морской инфраструктуры",
                    Code = "26.03.02",
                    Duration = 4,
                    PlaceBudget = 15,
                    PlaceCommerce = 5,
                    Mark = 178,
                    Cost = 180000,
                    IDFac = 1
                };
                spacialities[13] = new Spaciality()
                {
                    Name = "Проектирование авиационных и ракетных двигателей",
                    Code = "24.05.02",
                    Duration = 5,
                    PlaceBudget = 40,
                    PlaceCommerce = 5,
                    Mark = 194,
                    Cost = 185000,
                    IDFac = 1
                };
                spacialities[14] = new Spaciality()
                {
                    Name = "Самолето- и вертолетостроение",
                    Code = "24.05.07",
                    Duration = 5,
                    PlaceBudget = 70,
                    PlaceCommerce = 10,
                    Mark = 214,
                    Cost = 185000,
                    IDFac = 1
                };
                for (int i = 0; i < 15; i++)
                {
                    App.database.SSaveItem(spacialities[i]);
                }
                flag = true;
            }
            isClosed = false;
            TapGestureRecognizer tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += async (s, e) =>
            {
                 await Navigation.PushAsync(new Gost());
            };
            enter.GestureRecognizers.Add(tapGesture);
            TapGestureRecognizer tapGesture2 = new TapGestureRecognizer();
            tapGesture2.Tapped += async (s, e) =>
            {
                 await Navigation.PushAsync(new Reg());
            };
            reg.GestureRecognizers.Add(tapGesture2);
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
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (log.Text != null && pas.Text != null && log.Text != "" && pas.Text != "")
            {
                try
                {
                    List<User> users = App.database.UGetItems().ToList();
                    foreach (var i in users)
                    {
                        if (i.Login == log.Text && i.Password == pas.Text)
                        {
                            Navigation.PushAsync(new Profile(i));
                            isClosed = true;
                            break;
                        }
                    }
                    if (isClosed == false)
                    {
                        DisplayAlert("Уведомление", "Указанного пользователя не существует", "ОK");
                    }
                }
                catch
                {
                    DisplayAlert("Уведомление", "Ошибка", "ОK");
                }
            }
            else
                DisplayAlert("Уведомление", "Не все поля заполнены", "ОK");
        }
    }
}
