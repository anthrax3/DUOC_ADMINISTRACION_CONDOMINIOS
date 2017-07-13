using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigescoDAL.Modelo
{
    public class PagosDAL
    {
        public int PagarGastoComun(PAGO nuevo,string[]gastos)
        {
            int id_pago = 0;
            try
            {                
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.PAGO
                                 orderby a.ID_PAGO descending
                                 select a.ID_PAGO).FirstOrDefault();
                    id_pago = int.Parse(query.ToString());
                    nuevo.ID_PAGO = id_pago+1;
                    context.PAGO.Add(nuevo);                    
                    int contar = gastos.Length;
                    var query2 = (from a in context.PAGOXGASTO
                                 orderby a.ID_PAGOXGASTO descending
                                 select a.ID_PAGOXGASTO).FirstOrDefault();
                    int id_pxg = int.Parse(query2.ToString());
                    context.SaveChanges();
                    for (int i=1;i<contar;i++)
                    {
                        PAGOXGASTO pxg = new PAGOXGASTO();
                        id_pxg=id_pxg + 1;
                        int gasto = int.Parse(gastos[i]);
                        pxg.ID_PAGOXGASTO = id_pxg;
                        pxg.ID_PAGO = id_pago;
                        pxg.ID_GASTO = gasto;
                        context.PAGOXGASTO.Add(pxg);
                        var query3 = (from c in context.GASTO
                                     where c.ID_GASTO == gasto
                                     select c).FirstOrDefault();
                        query3.ESTADO = "PAGADO";
                        context.SaveChanges();
                    }                    
                    return id_pago;
                }
            }
            catch (Exception e)
            {
                return id_pago;
            }
        }

    }//fin clase
}
