using Mantenimiento.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantenimiento.Common
{
    public interface IRepository
    {
        List<Empleados> ListadoEmpleados();

        void Agregar(Empleados empleados);

        Empleados EmpleadoPorId(int id);

        void Editar(Empleados empleados);

        void Eliminar(Empleados empleado);
    }
}
