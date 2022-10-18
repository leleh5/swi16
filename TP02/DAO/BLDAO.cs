using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP02.Models;

namespace TP02.DAO
{
    public class BLDAO
    {
        public void Adiciona(BL bl)
        {
            using(var context=new PortoContext())
            {
                context.BLs.Add(bl);
                context.SaveChanges();
            }
        }

        public IList<BL> Lista()
        {
            using (var context=new PortoContext())
            {
                return context.BLs.ToList();
            }
        }

        public BL BuscaPorNumero(int numero)
        {
            using (var context= new PortoContext())
            {
                return context.BLs.Find(numero);
            }
        }

        public void Atualiza(BL bl)
        {
            using(var context= new PortoContext())
            {
                context.Entry(bl).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}