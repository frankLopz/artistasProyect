using System;
using System.Collections.Generic;
using System.Text;

namespace artistasProyect.Modelos
{
    public class Persona
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPatero { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Telefono { get; set; }
        public int IdEstado { get; set; }
        public int IdMunicipio { get; set; }
        public object Colonia { get; set; }
        public string Dirreccion { get; set; }
    }
}
