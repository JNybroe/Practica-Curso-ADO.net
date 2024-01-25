using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Discos;
using Registros;


namespace DiscoTest
{
    public partial class VentanaAgregar : Form
    {
        public VentanaAgregar()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Disco disco = new Disco();
            
            ArchivoDisco arch = new ArchivoDisco();
            try
            {
                disco.Name = txtNombre.Text;
                disco.Tracks = int.Parse(txtTracks.Text);
                disco.UrlImagen = txtPortada.Text;
                disco.Genre = (Estilo)cboGenero.SelectedItem;
                disco.Formato = (Estilo)cboFormato.SelectedItem;
                disco.Fecha = dtpFechaLanzamiento.Value;

                arch.agregarDisco(disco);
                MessageBox.Show("Disco agregado");
                Close();

            }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void VentanaAgregar_Load(object sender, EventArgs e)
        {
            ArchivoEstilo archEstilo = new ArchivoEstilo();
            ArchivoTipo archTipo = new ArchivoTipo();
            try
            {
                cboGenero.DataSource = archEstilo.listar();
                cboFormato.DataSource= archTipo.listar();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
