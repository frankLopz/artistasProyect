using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Acr.UserDialogs;
using artistasProyect.Entities;

namespace artistasProyect
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registros : ContentPage
    {

        public Registros()
        {
            InitializeComponent();
			InicializarRegistros();
		}


		public async void InicializarRegistros()
        {
			UserDialogs.Instance.ShowLoading("Recibiendo la informacion");

			var request = new HttpRequestMessage();
			request.RequestUri = new Uri("https://uri.somee.com/api/persona/getall");
			request.Method = HttpMethod.Get;
			request.Headers.Add("Accept", "application/json");
			var client = new HttpClient();
			HttpResponseMessage response = await client.SendAsync(request);
			if (response.StatusCode == HttpStatusCode.OK)
			{

				string content = await response.Content.ReadAsStringAsync();
				var resultado = JsonConvert.DeserializeObject<List<Personas>>(content);

				UserDialogs.Instance.HideLoading();

				ListaPersona.ItemsSource = resultado;
			}
		}


	}
}