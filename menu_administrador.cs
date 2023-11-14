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
    public partial class menu_administrador : Form
    {
        Conexion c = new Conexion();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();

        public menu_administrador()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Gestion_usuario gu = new Gestion_usuario();
            gu.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Gestionar_mesero gm = new Gestionar_mesero();
            gm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gestionar_mesa gma = new gestionar_mesa();
            gma.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Gestionar_platos gp = new Gestionar_platos();
            gp.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            gestionar_bebidas gb = new gestionar_bebidas();
            gb.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir de formulario del administrador?", "menu de administrador", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void menu_administrador_Load(object sender, EventArgs e)
        {

        }
        

        private void button9_Click(object sender, EventArgs e)
        {
            Datos_pedidos gm = new Datos_pedidos();
            gm.Show();
            this.Hide();
        }
        public void consultar_pedido(int id_pedido)
        {
            SqlCommand consulta_id;
            consulta_id = new SqlCommand("select*from pedido where id_pedido=@id_pedido", c.conectar());
            consulta_id.CommandType = CommandType.Text;
            consulta_id.Parameters.AddWithValue("@id_pedido", SqlDbType.Int).Value = id_pedido;
            consulta_id.ExecuteNonQuery();
            textBox2.Text = "";

            SqlDataAdapter da = new SqlDataAdapter(consulta_id);
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

        private void button8_Click(object sender, EventArgs e)
        {
            consultar_pedido(int.Parse(textBox2.Text));
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
