using artistasProyect.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace artistasProyect
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaArtistaView : ContentPage
    {
        public IList<Artistas> Artista { get; set; }
        public ListaArtistaView()
        {
            InitializeComponent();
            Artista = new List<Artistas>();

            Artista.Add(new Artistas
            {
                Nombre = "Los Amigos Invisibles",
                Genero = "Acid Jazz, Disco, Funk, Salsa, merengue , Pop rock y otros diversos ritmos hispanoamericanos",
                Descripcion = "Los Amigos Invisibles iniciaron su historia en 1991, este 2021 cumplen 30 años como grupo y 25 de haber grabado su primer disco. \n Fue con ayuda de amigos y conocidos que la banda consiguió las herramientas para preparar A typical & autoctonal venezuelan dance band, álbum que marcó su debut y donde plasmaron toda su creatividad sin importar las reglas de la industria.",
                Imagen = "LosAmigos"
            });

            Artista.Add(new Artistas
            {
                Nombre = "Zoé",
                Genero = "Rock psicodélico, Neo - psicodelia, Rock alternativo, Rock espacial1",
                Descripcion = "Zoé es una banda de rock mexicana formada en 1995 y oficializada en 1997. \n Es liderada por León Larregui (voz) e integrada además por Sergio Acosta (guitarra), Jesús Báez (teclados), Ángel Mosqueda (bajo) y Rodrigo Guardiola (batería).\n Se caracteriza por tener influencias del rock psicodélico y de la música electrónica.",
                Imagen = "zoe"
            });

            Artista.Add(new Artistas
            {
                Nombre = "Cafe Tacuba",
                Genero = "Alterlatino; Rock alternativo; Art pop; Música latina",
                Descripcion = "Café Tacvba es una banda mexicana de rock alternativo procedente de la Ciudad Satélite, en el municipio de Naucalpan, Estado de México, México. El grupo se conformó en el año 1989.\n el grupo es reconocido por su proyecto cultural vanguardista el cual mezcla el rock y sus temas habituales con letras, historias y sonidos extraídos de la cultura popular mexicana, esto último gracias al uso en diversas canciones de instrumentos como tololoche y jarana",
                Imagen = "cafeTacuba"
            });

            Artista.Add(new Artistas
            {
                Nombre = "Los Choclok",
                Genero = "reggae, ska, cumbia, Musica Latina",
                Descripcion = "La banda surgió hace casi siete años, nosotros somos originarios del sur de Veracruz, algunos del municipio de Cosoleacaque y otros del municipio de Chinameca \n el nombre de “Los Choclock” hace referencia a una onomatopeya coital \n choclok  es un mensaje subliminal para que toda la banda se quede con eso y se acuerde de nosotros a la hora del cachondeo.",
                Imagen = "choclok"
            });

            Artista.Add(new Artistas
            {
                Nombre = "DLD",
                Genero = "Pop, Pop rock, Rock alternativo",
                Descripcion = "DLD, es una banda de Rock y Pop mexicana proveniente del Estado de México, México. La banda fue formada en noviembre de 1998. \n Dildo, como se hacían llamar, capturó la atención de varias compañías discográficas, logrando conseguir su primer contrato con una firma de rock independiente de México. \n La banda decide abreviar el nombre de Dildo a DLD, para evitar problemas legales, y al mismo tiempo no ofender la susceptibilidad de la gente que sentía muy fuerte la palabra.",
                Imagen = "dld"
            });

            Artista.Add(new Artistas
            {
                Nombre = "La Gusana Ciega",
                Genero = "Pop rock, Indie pop, Rock alternativo, Rock en español",
                Descripcion = "La Gusana Ciega es un grupo de rock alternativo mexicano formado por Daniel Gutiérrez (voz y guitarra), Germán Arroyo (batería) y Luis Ernesto Martínez (bajo). \n El grupo empezó a obtener un lugar reconocido en la escena musical 'Underground' de la Ciudad de México después de varios años de tocar en bares y antros de la urbe.",
                Imagen = "laGusana"
            });

            Artista.Add(new Artistas
            {
                Nombre = "Morat",
                Genero = "Black metal, folk, Pop rock, Trap, World Music",
                Descripcion = "Morat es una banda colombiana de folk-pop formada originalmente en Bogotá en 2011. Se dieron a conocer en 2015 con su éxito Mi nuevo vicio. \n Comenzaron tocando juntos en varias ocasiones y cuando cursaban la secundaria",
                Imagen = "morat"
            });

            BindingContext = this;
        }
        void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Artistas selectedItem = e.CurrentSelection[0] as Artistas;
            DisplayAlert($"{ selectedItem.Nombre}", $"{selectedItem.Descripcion}", "Ok");

        }

        private void miListaArtistas(object sender, SelectedItemChangedEventArgs e)
        {
          var Artista = e.SelectedItem as Artistas;
            DisplayAlert("Selected",$"{Artista.Nombre}\n{Artista.Descripcion}","Ok");
        }


        private async void RegistroClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Formulario());
        }



    }
}