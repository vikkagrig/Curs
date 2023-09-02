﻿using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace PCMob
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "PC.db";
        public static Reposit database;
        public static Reposit Database
        {
            get
            {
                if (database == null)
                {
                    database = new Reposit(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
