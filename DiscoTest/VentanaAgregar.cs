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
        private Disco disco = null;
        public VentanaAgregar()
        {
            InitializeComponent();
        }
        public VentanaAgregar(Disco disco)
        {
            InitializeComponent();
            this.disco = disco;
            Text = "Modificar disco";
            btnAgregar.Text = "Modificar";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            ArchivoDisco arch = new ArchivoDisco();
            try
            {
                if(disco == null)
                {
                    disco = new Disco();
                }
                disco.Name = txtNombre.Text;
                disco.Tracks = int.Parse(txtTracks.Text);
                disco.UrlImagen = txtPortada.Text;
                disco.Genre = (Estilo)cboGenero.SelectedItem;
                disco.Formato = (Estilo)cboFormato.SelectedItem;
                disco.Fecha = dtpFechaLanzamiento.Value;
               
                if(disco.ID != 0)
                {
                    arch.modificarDisco(disco);
                    MessageBox.Show("Disco modificado");
                }
                else
                {
                    arch.agregarDisco(disco);
                    MessageBox.Show("Disco agregado");
                }
                Close();
            }
            catch (Exception ex)
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
                cboGenero.ValueMember = "Id";
                cboGenero.DisplayMember = "Description";
                cboFormato.DataSource= archTipo.listar();
                cboFormato.ValueMember= "Id";
                cboFormato.DisplayMember= "Description";

                if(disco != null)
                {
                    txtNombre.Text = disco.Name;
                    txtTracks.Text = disco.Tracks.ToString();
                    txtPortada.Text = disco.UrlImagen;
                    cargarImagen(disco.UrlImagen);
                    dtpFechaLanzamiento.Text = disco.Fecha.ToString();
                    cboGenero.SelectedValue = disco.Genre.Id;
                    cboFormato.SelectedValue = disco.Formato.Id;
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtPortada_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtPortada.Text);
        }
        private void cargarImagen(string url)
        {
            try
            {
                pBoxAgregar.Load(url);

            }
            catch (Exception)
            {
                pBoxAgregar.Load("https://t3.ftcdn.net/jpg/02/48/42/64/360_F_248426448_NVKLywWqArG2ADUxDq6QprtIzsF82dMF.jpg");
            }
        }
    }
}
