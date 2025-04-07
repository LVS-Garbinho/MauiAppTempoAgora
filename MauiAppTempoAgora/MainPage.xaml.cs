using MauiAppTempoAgora.Models;
using MauiAppTempoAgora.Services;

namespace MauiAppTempoAgora
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void Button_Clicked(object sender, EventArgs e)
        {
            try
            { 
                if(!string.IsNullOrEmpty(txt_cidade.Text))
                {
                    Tempo? t = await DataService.GetPrevisao(txt_cidade.Text);

                    if (t != null)
                    {
                        string dados_previsao = "";

                        dados_previsao = $"Latitude:{t.lat} \n" +
                                         $"Longitude:{t.lon} \n" +
                                         $"Nascer do sol:{t.sunrise} \n" +
                                         $"Por do sol:{t.sunset} \n" +
                                         $"Temp Máx:{t.temp_max} \n" +
                                         $"Temp Min:{t.temp_min} \n" +
                                         $"Como está o clima:{t.description} \n" +
                                         $"Velocidade do vento:{t.speed} \n" +
                                         $"Visibilidade:{t.visibility} \n";

                    } else
                    {
                        lbl_res.Text = "A previsão não foi encontrada. Por favor, verifique se o nome da cidade foi digitado corretamente.";
                    }
                   
                } else
                {
                    lbl_res.Text = "Preencha a Cidade.";
                }

            } catch(Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }
    }

}
