using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;

namespace Impresion
{

   
    public class Impresion
    {
        
        protected IDEALSoftware.VpeProfessional.VpeControl Vpc;

        public void ImprimirFactura(List<HistoricoCustom> Comprobantes , char Clase)
        { 
        

        this.Vpc =  new IDEALSoftware.VpeProfessional.VpeControl();
        this.Vpc.OpenDoc();
        this.Vpc.Print(1.5, 1, "Hello World!");

        this.Vpc.WriteDoc("c:\\facturacion\\MyDocument.pdf");
        this.Vpc.Preview();
            
          
        }
    }
}
