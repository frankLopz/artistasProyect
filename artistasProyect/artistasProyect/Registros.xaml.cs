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

namespace artistasProyect
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registros : ContentPage
    {

        public Registros()
        {
            InitializeComponent();
		}


		public class PersonaVM
		{
			public string ApellidoMaterno { get; set; }
			public string ApellidoPatero { get; set; }
			public string Colonia { get; set; }
			public string Dirreccion { get; set; }
			public int IdEstado { get; set; }
			public int IdMunicipio { get; set; }
			public string Nombre { get; set; }
			public double Telefono { get; set; }
			public int Id { get; set; }
			public string FullName => $"{Nombre} {ApellidoPatero} {ApellidoMaterno}";

			public string FullDireccion => $"{Dirreccion} {Colonia} {Telefono}";
		}

		private async void Button_ClickedAsync(object sender, EventArgs e)
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
				var resultado = JsonConvert.DeserializeObject<List<PersonaVM>>(content);

				UserDialogs.Instance.HideLoading();

				ListaPersona.ItemsSource = resultado;
			}

		}
	}
}