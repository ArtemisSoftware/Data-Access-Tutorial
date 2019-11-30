using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DataAccess
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            if (Application.Current.Properties.ContainsKey("Title"))
            {
                title.Text = Application.Current.Properties["Title"].ToString();
            }

            if (Application.Current.Properties.ContainsKey("NotificationsEnabled"))
            {
                notificationsEnabled.On = (bool) Application.Current.Properties["NotificationsEnabled"];
            }
        }


        private void OnChange(object sender, System.EventArgs e)
        {
            Application.Current.Properties["Title"] = title.Text;
            Application.Current.Properties["NotificationsEnabled"] = notificationsEnabled.On;
        }
    }
}
