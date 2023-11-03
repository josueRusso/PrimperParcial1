using Microsoft.EntityFrameworkCore;
using PrimerParcial.DAL;
using PrimerParcial.Model;
using System.Linq.Expressions;

namespace PrimerParcial.BLL
{
    public class IngresosBLL
    {
        public Context _contexto;

        public IngresosBLL(Context contexto)
        {
            _contexto = contexto;
        }

        public bool Existe(int ingresoId)
        {
            return _contexto.Ingresos.Any(i => i.IngresoId == ingresoId);
        }

        private bool Insertar(Ingresos ingresos)
        {
            _contexto.Ingresos.Add(ingresos);
            int creado = _contexto.SaveChanges();
            _contexto.Entry(ingresos).State = EntityState.Detached;
            return creado > 0;
        }

        private bool Modificar(Ingresos ingresos)
        {
            _contexto.Update(ingresos);
            int modificado = _contexto.SaveChanges();
            _contexto.Entry(ingresos).State = EntityState.Detached;
            return modificado > 0;
        }

        public bool Guardar(Ingresos ingresos)
        {
            if (!Existe(ingresos.IngresoId))
            {
                return Insertar(ingresos);
            }
            else
            {
                return Modificar(ingresos);
            }
        }

        public bool Eliminar(Ingresos ingresos)
        {
            _contexto.Ingresos.Remove(ingresos);
            int eliminado = _contexto.SaveChanges();
            _contexto.Entry(ingresos).State = EntityState.Detached;
            return eliminado > 0;
        }

        public Ingresos? Buscar(int IngresosId)
        {
            return _contexto.Ingresos.AsNoTracking().FirstOrDefault(i => i.IngresoId == IngresosId);
        }


        public List<Ingresos> GetList(Expression<Func<Ingresos, bool>> expression)
        {
            return _contexto.Ingresos.Where(expression).AsNoTracking().ToList();
        }

       
    }
}
