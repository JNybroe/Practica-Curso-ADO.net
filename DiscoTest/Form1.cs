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
                sacarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void sacarColumnas()
        {
            dgVDiscos.Columns["UrlImagen"].Visible = false;
            dgVDiscos.Columns["ID"].Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Año");
            cboCampo.Items.Add("Total de canciones");

            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dgVDiscos.CurrentRow != null)
            {
                Disco seleccionado = (Disco)dgVDiscos.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.UrlImagen);
            }
           
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
            seleccionado = (Disco)dgVDiscos.CurrentRow.DataBoundItem;

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


        private void txtBoxFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Disco> listaFiltrada;
            string filtro = txtBoxFiltroRapido.Text;
            if (filtro.Length >= 2)
            {
                listaFiltrada = lista.FindAll(f => f.Name.ToLower().Contains(filtro.ToLower()) || f.Fecha.Year.ToString().Contains(filtro));
            }
            else
            {
                listaFiltrada = lista;
            }


            dgVDiscos.DataSource = null;
            dgVDiscos.DataSource = listaFiltrada;
            sacarColumnas();
        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();
            if(opcion == "Nombre")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Inicia con ");
                cboCriterio.Items.Add("Termina con ");
                cboCriterio.Items.Add("Contiene ");
            }
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Es menor a ");
                cboCriterio.Items.Add("Es mayor a ");
                cboCriterio.Items.Add("Es igual a ");
            }
        }

        private bool validarSeleccion()
        {
            if (cboCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Debes seleccionar un campo a filtrar","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            if(cboCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Debes seleccionar un criterio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ArchivoDisco arch = new ArchivoDisco();
            try
            {
                if (validarSeleccion())
                    return;
                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtBoxFiltro.Text;
                dgVDiscos.DataSource = arch.filtrar(campo,criterio,filtro);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtBoxFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cboCampo.SelectedIndex >= 1)
            {
                if((e.KeyChar < 48 || e.KeyChar > 54) && e.KeyChar !=8)
                {
                    e.Handled = true;
                }
            }
        }
    }
}
