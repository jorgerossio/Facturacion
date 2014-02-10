using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Transactions;



namespace DataLayer
{
    
    public  class FacturacionDao
    {
        List<HistoricoCustom> Lhistoricos = new List<HistoricoCustom>();
        static private string Constring = "Data Source=JORGE-EXO-PC\\MSSQL;Initial Catalog=Plapsa;User ID=sa; Password=003104";
        static private FacturacionDataContext db = new FacturacionDataContext(Constring);
        static private  TransactionScope transactionScope ;
        public List<HistoricoCustom> GetHistoricobydate(DateTime Fecha)
        {

                 var c = from com in db.GetTable<Historicos>()
                    join  o in db.GetTable<Contratos>()  
                    on com.contrato_id equals o.contrato_id   
                    join  Iva in db.GetTable<Codigos_Iva >() on  o.codigoiva_id equals Iva.codigoiva_id
                    where ((com.fec_cobro <= Fecha && com.factura_id == 0))
                    select new
                    {
                        canal_pago = com.canal_pago,
                        codigo_barras = com.codigo_barras,
                        codigo_consorcio = com.codigo_consorcio,
                        codigo_control = com.codigo_control,
                        codigo_pagoelectronico = com.codigo_pagoelectronico,
                        codigo_terminal = com.codigo_terminal,
                        codigo_unidad = com.codigo_unidad,
                        codigodemorado_id = com.codigodemorado_id,
                        codigorechazo_id = com.codigorechazo_id,
                        comision = com.comision,
                        contrato_id = com.contrato_id,
                        factura_id = com.factura_id,
                        fec_cobro = com.fec_cobro,
                        fec_descarga = com.fec_descarga,
                        fec_informado = com.fec_informado,
                        fec_transferencia = com.fec_transferencia,
                        historico_id = com.historico_id,
                        hora_cobro = com.hora_cobro,
                        hora_informado = com.hora_informado,
                        importe = com.importe,
                        iva = com.iva,
                        mediopago_id = com.mediopago_id,
                        mp_comision = com.mp_comision,
                        mp_iva = com.mp_iva,
                        neto = com.neto,
                        ordenpago_id = com.ordenpago_id,
                        transaccion_id = com.transaccion_id,
                        codigoiva_id = o.codigoiva_id

                    };
           
            foreach (var e in c)
            {

                HistoricoCustom hc = new HistoricoCustom();

                hc.canal_pago = e.canal_pago; hc.codigo_barras = e.codigo_barras; hc.codigo_consorcio = e.codigo_consorcio; hc.codigo_control = e.codigo_control; hc.codigo_pagoelectronico = e.codigo_pagoelectronico;
                hc.codigo_terminal = e.codigo_terminal; hc.codigo_unidad = e.codigo_unidad; hc.codigodemorado_id = e.codigodemorado_id; hc.codigorechazo_id = e.codigorechazo_id; hc.comision = e.comision; hc.contrato_id = e.contrato_id;
                hc.factura_id = e.factura_id; hc.fec_cobro = e.fec_cobro; hc.fec_descarga = e.fec_descarga; hc.fec_informado = e.fec_informado; hc.fec_transferencia = e.fec_transferencia; hc.historico_id = e.historico_id; hc.hora_cobro = e.hora_cobro; hc.hora_informado = e.hora_informado;
                hc.importe = e.importe; hc.iva = e.iva; hc.mediopago_id = e.mediopago_id; hc.mp_comision = e.mp_comision; hc.mp_iva = e.mp_iva; hc.neto = e.neto; hc.ordenpago_id = e.ordenpago_id; hc.transaccion_id = e.transaccion_id;
                hc.codigoiva_id = e.codigoiva_id;


                Lhistoricos.Add(hc);

            }



            return Lhistoricos;

        }
        public   Codigos_Iva  GetConiva (Historicos Hi)
        {


            //Codigos_Iva Iva = new Codigos_Iva();
            //Contratos Contratos = new Contratos();

       // Obtenemos El Contrato
            Contratos c = (from com in db.GetTable<Contratos>()
                    where ((com.contrato_id  == Hi.contrato_id))
                  select com).FirstOrDefault();


            Codigos_Iva cIva = (from com in db.GetTable<Codigos_Iva>()
                      where (com.codigoiva_id == c.codigoiva_id)
                      select com).FirstOrDefault();
                
            return cIva;

        }
        public int GetPuntoVenta(Historicos Hi )
        {


            //Codigos_Iva Iva = new Codigos_Iva();
            //Contratos Contratos = new Contratos();

            // Obtenemos El Contrato
            Contratos c = (from com in db.GetTable<Contratos>()
                           where ((com.contrato_id == Hi.contrato_id))
                           select com).FirstOrDefault();
            return c.puntoventa_id;

        }
        public String GetNumeroFactura(Codigos_Iva cIva, Historicos Historicos, int puntoventa, Boolean A)
        {




            transactionScope = new TransactionScope();

            char Cero = '0' ;

            Puntos_Ventas c = (from com in db.GetTable<Puntos_Ventas>()
                               where ((com.puntoventa_id == puntoventa))
                     select com).FirstOrDefault();

            string Numero;
            string auxpuntoventa;

            if (A) 
            {

                int Aux = c.nro_ult_fac_a +1 ;
                auxpuntoventa =   c.puntoventa_id.ToString();
                auxpuntoventa.PadLeft(4, Cero);
                Numero =   Aux.ToString();

            }
            else
            {
                auxpuntoventa = c.puntoventa_id.ToString();
                auxpuntoventa.PadLeft(4, Cero);
                int Aux = c.nro_ult_fac_b +1;
                Numero =   Aux.ToString();
            
            }
            return Numero;
        }
        private String Getmes(DateTime Fecha)
        {

          
            String Aux = Fecha.Month.ToString();
            String NombreMes="";


             switch (Aux)
             {

                 case "1" :
                     NombreMes = "Enero";
                     break;
                 case "2":
                     NombreMes = "Febrero";
                     break;
                 case "3":
                     NombreMes = "Marzo";
                     break;
                 case "4":
                     NombreMes = "Abril";
                     break;
                 case "5":
                     NombreMes = "Mayo";
                     break;
                 case "6":
                     NombreMes = "Junio";
                     break;
                 case "7":
                     NombreMes = "Julio";
                     break;
                 case "8":
                     NombreMes = "Agosto";
                     break;
                 case "9":
                     NombreMes = "Septiembre";
                     break;
                 case "10":
                     NombreMes = "Octubre";
                     break;
                 case "11":
                     NombreMes = "Noviembre";
                     break;
                 case "12":
                     NombreMes = "Diciembre";
                     break;

             }
             return NombreMes;

        
        }
        public Boolean Facturar(Historicos Historicos, String Numero, Char Clase, DateTime Fecha)
        {
            Facturas F = new Facturas();

            try
            {
                String Mes = Getmes(Fecha);

                F.concepto = " Comsion Mes " + Mes.ToString();
                F.contrato_id = Historicos.contrato_id;

                F.fecha = DateTime.Now;
                F.importe = Historicos.importe;
                F.iva = Historicos.iva;
                F.neto = Historicos.neto;
                F.nro_factura = int.Parse(Numero);
                F.puntoventa_id = 9;
                F.tipo_factura = Clase;

                db.Facturas.InsertOnSubmit(F);

                db.SubmitChanges();

                int id = F.factura_id;

                Historicos UpdateHistorico = (from com in db.GetTable<Historicos>()
                                              join o in db.GetTable<Contratos>()
                                              on com.contrato_id equals o.contrato_id
                                              join Iva in db.GetTable<Codigos_Iva>() on o.codigoiva_id equals Iva.codigoiva_id
                                              where ((com.historico_id == Historicos.historico_id))
                                              select com).SingleOrDefault<Historicos>();


               

                UpdateHistorico.factura_id = id;
                db.SubmitChanges();

                transactionScope.Complete();
                transactionScope.Dispose();
                transactionScope = null;
                 
            }
           
            catch (TransactionAbortedException ex)
            {
                transactionScope.Dispose();
                transactionScope = null;
                return false;
            }

            catch (SystemException ex)
            {
                transactionScope.Dispose();
                transactionScope = null;
                return false;

            }


            return true;

        }

        
    }
}
