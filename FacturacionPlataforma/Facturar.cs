using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Data.Linq;
using DataLayer;


namespace FacturacionPlataforma
{
    public class Facturar
    {

        FacturacionDao f = new FacturacionDao();
        public List<HistoricoCustom> FacturaraFecha(DateTime Fecha , Char Clase)
        {

        List<HistoricoCustom> AuxFacurasAfacturar;
        AuxFacurasAfacturar =  f.GetHistoricobydate(Fecha);
        ProcFacturacion(AuxFacurasAfacturar, Clase,Fecha);
        return null;
        
        
        }

        private bool   ProcFacturacion( List<HistoricoCustom> aProc , Char Clase ,DateTime  Fecha )

        {
            int numfac;
            int puntoventa;
            string NumeroFacturar;

            foreach (HistoricoCustom hi in aProc)
             {

                Codigos_Iva Ci = f.GetConiva(hi);
                puntoventa = f.GetPuntoVenta(hi );
                NumeroFacturar = GetNum(Ci, hi, puntoventa,Clase);
                if (NumeroFacturar != "0")
                {
                    f.Facturar(hi, NumeroFacturar,Clase,Fecha);
                }
             }

            return true; 
        
        }

        private string  GetNum(Codigos_Iva cIva , Historicos Historicos,int puntoventa, Char Clase)
        {

   
            string Numeroaux="0";

            if ((Clase == 'A') && (cIva.codigoiva_id == 5))                
                {
                    Numeroaux = f.GetNumeroFactura(cIva, Historicos, puntoventa, true);
                }

            if ((Clase == 'B') && (cIva.codigoiva_id != 5))
             
                {
                    Numeroaux = f.GetNumeroFactura(cIva, Historicos, puntoventa, false);
                }
           
            return Numeroaux;

        }

        public Boolean GenerarDocumentos(char Clase , List<HistoricoCustom> Comprobantes)
        {

            Impresion.Impresion Imp = new Impresion.Impresion();
            Imp.ImprimirFactura(Comprobantes,Clase);

            return true;


        }

    }
}
