using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FatosRelevantes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Sobre : ContentPage
    {
        string Chave_pix_Aleatoria = "jadson0102@live.com";
        string currentVersion = VersionTracking.CurrentVersion;
        public Sobre()
        {
            InitializeComponent();
            InfoApp.Text = "FATOS RELEVANTES " + currentVersion;
        }

        private async void Telegram_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://t.me/appfatosrelevantes", BrowserLaunchMode.SystemPreferred);
        }

        private async void Instagram_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://instagram.com/jadsonxsantos", BrowserLaunchMode.SystemPreferred);
        }

        private async void Copiar_Pix_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(Chave_pix_Aleatoria);
            await DisplayAlert("Chave Pix (E-mail) Copiada!", "Pix copiado: " + Chave_pix_Aleatoria, "OK");
        }

        private async void PicPay_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync("https://picpay.me/jadsonxsantos", BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception)
            {
                // An unexpected error occured. No browser may be installed on the device.
            }
        }

        private async void InfoApp_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://linktr.ee/jadsonxsantos", BrowserLaunchMode.SystemPreferred);
        }
    }
}