using Mantenimiento.BusinessLogic;
using Mantenimiento.Common.Models;
using System;
using System.Windows.Forms;

namespace Mantenimiento.UI
{
    public partial class FrmMantenimiento : Form
    {
        public FrmMantenimiento()
        {
            InitializeComponent();
        }

        Logic logica = new Logic(); 
        int empId = 0;
        Empleados empleados = new Empleados();

        private void Mantenimiento_Load(object sender, EventArgs e)
        {
            dgvConsulta.DataSource = logica.EmpleadosList();
            dgvConsulta.AutoGenerateColumns = false;
            btnEliminar.Enabled = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            empleados.Nombre = txtNombre.Text.Trim();
            empleados.Apellidos = txtApellidos.Text.Trim();
            empleados.Edad = Convert.ToInt32(txtEdad.Text.Trim());
            empleados.Telefono = txtTelefono.Text.Trim();

            logica.AgregaroEditar(empleados, empId);

            Clear();
            dgvConsulta.DataSource = logica.EmpleadosList();
            MessageBox.Show("Datos guardados correctamente");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dgvConsulta_DoubleClick(object sender, EventArgs e)
        {
            if (dgvConsulta.CurrentCell.RowIndex != -1)
            {
                empId = Convert.ToInt32(dgvConsulta.CurrentRow.Cells["Id"].Value);
                empleados = logica.EmpleadoporId(empId);
                txtNombre.Text = empleados.Nombre;
                txtApellidos.Text = empleados.Apellidos;
                txtEdad.Text = empleados.Edad.ToString();
                txtTelefono.Text = empleados.Telefono;

            }
            btnAgregar.Text = "Editar";
            btnEliminar.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea eliminar este registro?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                logica.Eliminar(empleados);
                Clear();
                dgvConsulta.DataSource = logica.EmpleadosList();
                MessageBox.Show("Registro eliminado correctamente");
            }
        }

        private void Clear()
        {
            btnAgregar.Text = "Agregar";
            btnEliminar.Enabled = false;
            empId = 0;
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtEdad.Text = "";
            txtTelefono.Text = "";
            txtNombre.Focus();
        }

    }
}
