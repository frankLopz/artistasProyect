using System;
using System.Collections.Generic;
using System.Text;

namespace artistasProyect.Entities
{
    public class Artistas
    {
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public string VideoUrl { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
