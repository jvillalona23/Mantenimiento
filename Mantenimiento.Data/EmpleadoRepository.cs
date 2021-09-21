using Mantenimiento.Common;
using Mantenimiento.Common.Models;
using Mantenimiento.Data.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Mantenimiento.Data
{
    public class EmpleadoRepository : IRepository
    {
        AppDbContext _DbContext = new AppDbContext();

        public List<Empleados> ListadoEmpleados()
        {
            return _DbContext.Empleados.ToList();
        }

        public void Agregar(Empleados empleados)
        {
            _DbContext.Empleados.Add(empleados);
            _DbContext.SaveChanges();
        }

        public Empleados EmpleadoPorId(int id)
        {
            return _DbContext.Empleados.Where(a => a.Id == id).FirstOrDefault();
        }

        public void Editar(Empleados empleados)
        {
            _DbContext.Entry(empleados).State = EntityState.Modified;
            _DbContext.SaveChanges();
        }

        public void Eliminar(Empleados empleado)
        {
            _DbContext.Empleados.Remove(empleado);
            _DbContext.SaveChanges();
        }
    }
}
