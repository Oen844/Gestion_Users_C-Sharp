using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NumPrimos.DAO;
using NumPrimos.models;

namespace NumPrimos
{
    public partial class GestionClientes : Form
    {
        public GestionClientes()
        {
            InitializeComponent();
        }

        private void GestionClientes_Load(object sender, EventArgs e)
        {
            actualizarLista();

        }
        private void actualizarLista()
        {
            
            ClienteDao baseDatos = new ClienteDao();
            List<Cliente> listaDb = baseDatos.ObtenerlistadoClientes();

            listClientes.Items.Clear();
            for (int i = 0; i< listaDb.Count; i++)
            {
                Cliente cliente = listaDb[i];
                listClientes.Items.Add(cliente);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            Cliente cliente        = new Cliente();
            cliente.Nombre         = txtNombre.Text;
            cliente.Apellido       = txtApellido.Text;
            cliente.Telefono       = txtTelefono.Text;
            cliente.TarjetaCredito = txtTargetaCredito.Text;
            //MessageBox.Show(cliente.nombreCompleto);
            

            if (lblID.Text != "")
            {
                cliente.Id = lblID.Text;
            }

            ClienteDao baseDatos = new ClienteDao();
            baseDatos.Guardar(cliente);
            actualizarLista();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Cliente cliente = (Cliente)listClientes.SelectedItem;

            ClienteDao baseDatos = new ClienteDao();
            baseDatos.Eliminar(cliente);
            actualizarLista();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Cliente cliente = (Cliente)listClientes.SelectedItem;
            txtNombre.Text = cliente.Nombre;
            txtApellido.Text = cliente.Apellido;
            txtTelefono.Text = cliente.Telefono;
            txtTargetaCredito.Text = cliente.TarjetaCredito;
            lblID.Text = cliente.Id;


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            lblID.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtTargetaCredito.Text = "";
        }
    }
}
