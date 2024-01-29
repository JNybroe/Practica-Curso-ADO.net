using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discos
{
    public class Disco
    {
        public int ID {  get; set; }
        [DisplayName ("Nombre")]
        public string Name { get; set; }
        public DateTime Fecha { get; set; }
        public string UrlImagen { get; set; }
        [DisplayName ("Total de canciones")]
        public int Tracks { get; set; }
        [DisplayName ("Género")]
        public Estilo Genre { get; set; }
        public Estilo Formato { get; set; }
    }
}
