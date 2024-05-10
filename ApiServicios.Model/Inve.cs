using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServicios.Model
{
    public class Inve
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int Cantidad { get; set;}
        public string FechaR { get; set;}
        public string FechaE { get; set;}
        public string Bodega { get; set;}
        public string Placa { get; set;}
        public int Precio { get; set;}
        public int Descuento { get; set; }
        public string Guia { get; set;}

    }
}
