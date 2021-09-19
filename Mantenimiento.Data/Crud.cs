using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantenimiento.Data
{
    public class Crud
    {
        AppDbContext _DbContext = new AppDbContext();
        Empleado Empleadosdb;
        public Crud()
        {
            Empleadosdb = new Empleado();
        }

        public List<Empleado> ListadoEmpleados()
        {
            return _DbContext.Empleados.ToList();
        }

        public void Agregar(Empleado empleados)
        {
            _DbContext.Empleados.Add(empleados);
            _DbContext.SaveChanges();
        }

        public Empleado EmpleadoPorId(int id)
        {
            return _DbContext.Empleados.Where(a => a.Id == id).FirstOrDefault();
        }

        public void Editar(Empleado empleados)
        {
            _DbContext.Entry(empleados).State = EntityState.Modified;
            _DbContext.SaveChanges();
        }

        public void Eliminar(Empleado empleado)
        {
            _DbContext.Empleados.Remove(empleado);
            _DbContext.SaveChanges();
        }
    }
}
