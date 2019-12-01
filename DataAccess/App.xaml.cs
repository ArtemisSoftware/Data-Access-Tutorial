using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataAccess
{
    public partial class App : Application
    {

        private const string TitleKey = "Title";
        private const string NotificationsEnabledKey = "NotificationsEnabled";


        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }


        public string Title
        {
            get
            {
                if (Properties.ContainsKey(TitleKey))
                {
                    return Properties[TitleKey].ToString();
                }
                else
                {
                    return "";
                }

            }
            set
            {
                Properties[TitleKey] = value;
            }
        }


        public bool NotificationsEnabled
        {
            get
            {
                if (Properties.ContainsKey(NotificationsEnabledKey))
                {
                    return (bool) Properties[NotificationsEnabledKey];
                }
                else
                {
                    return false;
                }

            }
            set
            {
                Properties[NotificationsEnabledKey] = value;
            }
        }

    }
}
