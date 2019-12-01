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

            BindingContext = Application.Current;

            CheckFile();

        }


        private async void CheckFile()
        {
             bool resultado = await PCLHelper.ArquivoExisteAsync("ficheiro");

            txt_arquivo.Text = "Existe arquivo: " + resultado + "";

        }
    }
}
