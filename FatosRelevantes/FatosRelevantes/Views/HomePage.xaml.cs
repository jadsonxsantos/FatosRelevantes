using FatosRelevantes.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FatosRelevantes.Views
{
    public partial class HomePage : ContentPage
    {
        // Request do JSON 
        private HttpClient _client = new HttpClient();
        ObservableCollection<FatoRelevante> FatosRelevantes;
        List<FatoRelevante> ItensJson;
        string UrlServidor = "https://fatosrelevantes-default-rtdb.firebaseio.com/" + ".json";
        public HomePage()
        {
            InitializeComponent();
            CarregarFatos();
        }

        private async void CarregarFatos()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(UrlServidor);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    // deserialize o Json para o Modelo de Dados Estabelecimento
                    ItensJson = JsonConvert.DeserializeObject<List<FatoRelevante>>(await response.Content.ReadAsStringAsync());
                    // Adiciona os dados em uma Lista!
                    FatosRelevantes = new ObservableCollection<FatoRelevante>(ItensJson);
                    //Atribui os dados para a ListView 
                    Lv_FatosRelevantes.ItemsSource = FatosRelevantes.Where(x => x.Disponivel == true).OrderByDescending(p => p.DataPublicacao);
                  
                    //Verificação da lista
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Verifique sua conexão", "Por favor verifique sua conexão e tente novamente mais tarde", "OK");
            }
           
        }

        [Obsolete]
        private async void Lv_FatosRelevantes_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = (FatoRelevante)e.Item;
            var lv = (ListView)sender;
            string action = await DisplayActionSheet("Fato Relevante: " + item.Empresa, "Cancelar", "", "Abrir", "Compartilhar");
            switch (action)
            {
                case "Cancelar":

                    // Do Something when 'Cancel' Button is pressed

                    break;

                case "Abrir":
                    // Ao clicar em abrir, abrir o navegador com o link do fato
                    if (e.Item == null)
                    {
                        return;
                    }

                    Device.OpenUri(new Uri(item.Link));


                    break;

                case "Compartilhar":

                    await Share.RequestAsync(new ShareTextRequest
                    {
                        Text = item.Empresa + Environment.NewLine + " (" + item.Descricao + ") - Acesse -> " + item.Link,
                        Uri = Environment.NewLine + "ℹ App Fatos Relevantes",
                        Title = "FATOS RELEVANTES"
                    });

                    break;
            }
            lv.SelectedItem = null;
        }

        private async void Lv_FatosRelevantes_Refreshing(object sender, EventArgs e)
        {
            try
            {
                CarregarFatos();
            }
            catch
            {
                await DisplayAlert("Verifique sua conexão", "Por favor verifique sua conexão e tente novamente mais tarde", "OK");
            }
            finally
            {
                Lv_FatosRelevantes.EndRefresh();
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            
          
        }
    }
}