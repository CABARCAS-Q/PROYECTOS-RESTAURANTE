using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace proyecto__gestion_de_pedido
{
    public partial class Datos_pedidos : Form
    {

        Conexion c = new Conexion();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();

        public Datos_pedidos()
        {
            InitializeComponent();
        }

        private void Datos_pedidos_Load(object sender, EventArgs e)
        {

        }
        public void consultar_pedido()
        {
            SqlCommand consulta_pedido;
            consulta_pedido = new SqlCommand("select*from pedido", c.conectar());
            consulta_pedido.CommandType = CommandType.Text;
            consulta_pedido.ExecuteNonQuery();
            ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter(consulta_pedido);
            da.Fill(ds, "pedido");
            try
            {
                dataGridView1.DataMember = ("pedido");
                dataGridView1.DataSource = ds;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            consultar_pedido();
        }
        public void Eliminar_pedido(int id_pedido)
        {
            try
            {
                SqlCommand eliminar_p;
                eliminar_p = new SqlCommand("Delete from pedido Where  id_pedido= @id_pedido", c.conectar());
                eliminar_p.CommandType = CommandType.Text;
                eliminar_p.Parameters.AddWithValue("@id_pedido", SqlDbType.Int).Value = id_pedido;
                eliminar_p.ExecuteNonQuery();
                MessageBox.Show("el pedido ha sido eliminado exitosamente");
                textBox1.Text = "";
                consultar_pedido();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            menu_administrador gm = new menu_administrador();
            gm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Eliminar_pedido(int.Parse(textBox1.Text));
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
