using PNotes.Data;
using PNotes.Models;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PNotes
{
    public partial class App : Application
    {

        static SQLiteHelper database;

        internal static UserInfo _CurrentUser;

        public static int _UserID { get; set; }

        internal static SQLiteHelper Database
        {
            get
            {
                if (database == null)
                {
                    database = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
                }
                return database;
            }
        }
        public App() 
        {
            InitializeComponent();

            //MainPage = new MainPage();

            MainPage = new NavigationPage(new PNotes.View.MainComplaintPage());
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
