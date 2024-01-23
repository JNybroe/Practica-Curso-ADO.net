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

        private void Form1_Load(object sender, EventArgs e)
        {
            ArchivoDisco disco = new ArchivoDisco();
            lista = disco.Listar();
            dataGridView1.DataSource = lista;
            dataGridView1.Columns["UrlImagen"].Visible = false;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Disco seleccionado = (Disco)dataGridView1.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImagen);
        }
        private void cargarImagen(string url)
        {
            try
            {
                pictureBox1.Load(url);

            }
            catch (Exception)
            {
                pictureBox1.Load("https://t3.ftcdn.net/jpg/02/48/42/64/360_F_248426448_NVKLywWqArG2ADUxDq6QprtIzsF82dMF.jpg");
            }
        }
    }
}
