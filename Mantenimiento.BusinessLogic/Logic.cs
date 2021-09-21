using Mantenimiento.Common.Models;
using Mantenimiento.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantenimiento.BusinessLogic
{
    public class Logic
    {
        EmpleadoRepository _empleadoRepository;
        public Logic()
        {
            _empleadoRepository = new EmpleadoRepository();
        }
        public List<Empleados> EmpleadosList()
        {
            return _empleadoRepository.ListadoEmpleados();
        }

        public void AgregaroEditar(Empleados empleados, int empid)
        {
            if (empid > 0)
            {
                _empleadoRepository.Editar(empleados);
            }
            else
            {
                _empleadoRepository.Agregar(empleados);
            }
        }

        public Empleados EmpleadoporId(int id)
        {
            return _empleadoRepository.EmpleadoPorId(id);
        }

        public void Eliminar(Empleados empleados)
        {
            _empleadoRepository.Eliminar(empleados);
        }


    }
}
