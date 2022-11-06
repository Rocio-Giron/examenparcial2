using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public  class factura
    {
        //public int codigo { get; set; }
        //public DateTime fecha { get; set; }
       // public string codigoUsuario { get; set; }
        public string nombrecliente { get; set; }
        public string descrip { get; set; }
        public string descripcionRes { get; set; }
      //  public decimal precio { get; set; }
        public decimal ISV { get; set; }
        public decimal descuento { get; set; }
        public decimal subTotal { get; set; }
        public decimal total { get; set; }
        //public string CodigoTipo { get; set; }

    }
}
