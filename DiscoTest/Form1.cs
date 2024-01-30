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
    public partial class Form1 : Form
    {
        private List<Disco> lista;
        public Form1()
        {
            InitializeComponent();
        }
        private void cargar()
        {
            try
            {
                ArchivoDisco disco = new ArchivoDisco();
                lista = disco.Listar();
                dgVDiscos.DataSource = lista;
                dgVDiscos.Columns["UrlImagen"].Visible = false;
                dgVDiscos.Columns["ID"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }         
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Disco seleccionado = (Disco)dgVDiscos.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImagen);
        }
        private void cargarImagen(string url)
        {
            try
            {
                pbDiscos.Load(url);

            }
            catch (Exception)
            {
                pbDiscos.Load("https://t3.ftcdn.net/jpg/02/48/42/64/360_F_248426448_NVKLywWqArG2ADUxDq6QprtIzsF82dMF.jpg");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            VentanaAgregar ventanaAgregar = new VentanaAgregar();
            ventanaAgregar.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Disco seleccionado;
            seleccionado = (Disco) dgVDiscos.CurrentRow.DataBoundItem;

            VentanaAgregar modificar = new VentanaAgregar(seleccionado);
            modificar.ShowDialog();
            cargar();
        }

        private void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            ArchivoDisco archivo = new ArchivoDisco();
            Disco seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Desea eliminar el disco seleccionado?","Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(respuesta == DialogResult.Yes)
                {
                    seleccionado = (Disco)dgVDiscos.CurrentRow.DataBoundItem;
                    archivo.eliminarDiscoFisico(seleccionado.ID);
                    cargar();
                }      

            }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
