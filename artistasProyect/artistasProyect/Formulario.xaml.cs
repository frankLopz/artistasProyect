using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using artistasProyect.Modelos;
using System.Net;
using System.Net.Http;



using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace artistasProyect
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Formulario : ContentPage
    {
        public Formulario()
        {
            InitializeComponent();
        }
        private async void ConsultaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registros());
        }

        private async void Registrar_Clicked(object sender, EventArgs e)
        {
            Persona persona = new Persona
            {   
                Nombre = txtNombre.Text,
                ApellidoPatero = txtApaterno.Text,
                ApellidoMaterno = txtAmaterno.Text,
                Telefono = txtTelefono.Text,
                IdEstado = int.Parse(txtEstado.Text),
                IdMunicipio = int.Parse(txtMunicipio.Text),
                Colonia = txtColonia.Text,
                Dirreccion = txtDireccion.Text
            };

            Uri RequestUri = new Uri("https://uri.somee.com/api/persona/save");

            var client = new HttpClient();
            var json= JsonConvert. SerializeObject(persona);
            var contentJson = new StringContent(json, Encoding.UTF8,"application/json");
            var response = await client.PostAsync(RequestUri, contentJson);

            if (response.StatusCode==HttpStatusCode.OK)
            {
                await DisplayAlert("Datos", "Se realizo correctamente el registro","OK");
                txtNombre.Text = "";
                txtAmaterno.Text = "";
                txtApaterno.Text = "";
                txtTelefono.Text = "";
                txtEstado.Text = "";
                txtMunicipio.Text = "";
                txtColonia.Text = "";
                txtDireccion.Text = "";


            }
            else
            {
                await DisplayAlert("Error","Ocurrio un error durante el registro ","Ok");
            }

        }
    }
}