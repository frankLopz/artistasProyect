using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Acr.UserDialogs;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using artistasProyect.Entities;
using System.Net.Http.Headers;

namespace artistasProyect
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Formulario : ContentPage
    {
        public IList<EstadosEntities> EstadoModel { get; set; }
        public IList<Municipios> Municipios { get; private set; }
        public Formulario()
        {
            InitializeComponent();
            BindingContext = this;
            InicializarEstados();
        }
        private async void ConsultaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registros());
        }

        
        private async void InicializarEstados()
        {
            UserDialogs.Instance.ShowLoading("Recibiendo la informacion del servidor");

            EstadoModel = new List<EstadosEntities>();


            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://uri.somee.com/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var url = "api/direccion/estados";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode(); 
                var res = await response.Content.ReadAsStringAsync();
                List<EstadosEntities> resultado = JsonConvert.DeserializeObject<List<EstadosEntities>>(res);

                UserDialogs.Instance.HideLoading();

                if (resultado.Count >0)
                {
                    foreach (EstadosEntities estado in resultado)
                    {
                        EstadoModel.Add(estado);
                    }

                }
                else
                {
                    await DisplayAlert("Alerta", "No se encontraron datos disponibles", "Ok");
                }

            }
            catch (Exception e)
            {

                string error = e.Message;
                await DisplayAlert("Error", "Ha ocurrido un error al cargar la informacion", "Ok");
            }
            pickerEstado.SetBinding(Picker.ItemsSourceProperty, "EstadoModel");
            pickerEstado.ItemDisplayBinding = new Binding("Nombre");
        }







        private async void Registrar_Clicked(object sender, EventArgs e)
        {
            UserDialogs.Instance.ShowLoading("Enviando la informacion");

            Personas persona = new Personas
            {   
                Nombre = txtNombre.Text,
                ApellidoPatero = txtApaterno.Text,
                ApellidoMaterno = txtAmaterno.Text,
                Telefono = txtTelefono.Text,
                IdEstado =((EstadosEntities)pickerEstado.SelectedItem).Id,
                IdMunicipio =((Municipios)pickerMunicipio.SelectedItem).Id,
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
                UserDialogs.Instance.HideLoading();

                await DisplayAlert("Datos", "Se realizo correctamente el registro","OK");
                txtNombre.Text = "";
                txtAmaterno.Text = "";
                txtApaterno.Text = "";
                txtTelefono.Text = "";
                txtColonia.Text = "";
                txtDireccion.Text = "";
                pickerEstado.SelectedItem = 0;
                pickerMunicipio.SelectedItem = 0;


            }
            else
            {
                UserDialogs.Instance.HideLoading();

                await DisplayAlert("Error","Ocurrio un error durante el registro ","Ok");

            }

        }

        private async void pickerEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pickerEstado.SelectedIndex !=-1)
            {
                Municipios = new List<Municipios>();

                try
                {
                    var url = "api/direccion/municipios?id=" + ((EstadosEntities)pickerEstado.SelectedItem).Id;
                    var request = new HttpRequestMessage();
                    request.RequestUri = new Uri("https://uri.somee.com/"+url);
                    request.Method = HttpMethod.Get;
                    request.Headers.Add("Accept", "application/json");
                    var client = new HttpClient();
                    HttpResponseMessage response = await client.SendAsync(request);
                    string content = await response.Content.ReadAsStringAsync();


                    List<Municipios> resultado = JsonConvert.DeserializeObject<List<Municipios>>(content);
                    UserDialogs.Instance.HideLoading();

                    if (resultado.Count > 0)
                    {
                        foreach (Municipios municipios in resultado)
                        {
                            Municipios.Add(municipios);

                        }
                    }
                    else
                    {
                        await DisplayAlert("Alerta", "No se encontro la informacion sobre los Municipios", "OK");
                    }
                    pickerMunicipio.SetBinding(Picker.ItemsSourceProperty, "Municipios");
                    pickerMunicipio.ItemDisplayBinding = new Binding("Nombre");
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                    await DisplayAlert(error, "Ha ocurrido un error \n por favor reinicie la app", "Ok");
                }
                BindingContext = this;
            }

        }
    }
}