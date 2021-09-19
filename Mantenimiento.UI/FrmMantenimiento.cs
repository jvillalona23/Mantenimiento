using Mantenimiento.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mantenimiento.UI
{
    public partial class FrmMantenimiento : Form
    {
        public FrmMantenimiento()
        {
            InitializeComponent();
        }

        Crud db = new Crud();
        int empId = 0;
        Empleado empleado = new Empleado();

        private void Mantenimiento_Load(object sender, EventArgs e)
        {
            dgvConsulta.DataSource = db.ListadoEmpleados();
            dgvConsulta.AutoGenerateColumns = false;
            btnEliminar.Enabled = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            empleado.Nombre = txtNombre.Text.Trim();
            empleado.Apellidos = txtApellidos.Text.Trim();
            empleado.Edad = Convert.ToInt32(txtEdad.Text.Trim());
            empleado.Telefono = txtTelefono.Text.Trim();
            if (empId > 0)
            {
                db.Editar(empleado);
            }
            else
            {
               db.Agregar(empleado);
            }
            
            dgvConsulta.DataSource = db.ListadoEmpleados();
            MessageBox.Show("Datos guardados correctamente");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnAgregar.Text = "Agregar";
            empId = 0;
        }

        private void dgvConsulta_DoubleClick(object sender, EventArgs e)
        {
            if (dgvConsulta.CurrentCell.RowIndex != -1)
            {
                empId = Convert.ToInt32(dgvConsulta.CurrentRow.Cells["Id"].Value);
                empleado = db.EmpleadoPorId(empId);
                txtNombre.Text = empleado.Nombre;
                txtApellidos.Text = empleado.Apellidos;
                txtEdad.Text = empleado.Edad.ToString();
                txtTelefono.Text = empleado.Telefono;

            }
            btnAgregar.Text = "Editar";
            btnEliminar.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea eliminar este registro?", "Eliminar ?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.Eliminar(empleado);
                //clear()
                dgvConsulta.DataSource = db.ListadoEmpleados();
                MessageBox.Show("Registro eliminado correctamente");
            }
        }
    }
}
