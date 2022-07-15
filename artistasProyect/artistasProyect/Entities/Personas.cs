using System;
using System.Collections.Generic;
using System.Text;

namespace artistasProyect.Entities
{
    public class Personas
    {
		public string ApellidoMaterno { get; set; }
		public string ApellidoPatero { get; set; }
		public string Colonia { get; set; }
		public string Dirreccion { get; set; }
		public int IdEstado { get; set; }
		public int IdMunicipio { get; set; }
		public string Nombre { get; set; }
		public string Telefono { get; set; }
		public int Id { get; set; }
		public string FullName => $"{Nombre} {ApellidoPatero} {ApellidoMaterno}";
		public string FullDireccion => $"{Dirreccion} {Colonia} {Telefono}";


	}

}
