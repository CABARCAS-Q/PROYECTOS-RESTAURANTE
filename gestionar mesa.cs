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
    public partial class gestionar_mesa : Form
    {
        Conexion c = new Conexion();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();

        public gestionar_mesa()
        {
            InitializeComponent();
        }

        private void gestionar_mesa_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir de formulario de mesa?", "Datos de la mesa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        public void agregar_mesa(int Codigo_mesa, string Color_mesa, string Cupo_mesa, string disponibilidad_mesa)
        {
            SqlCommand insert;
            try
            {
                insert = new SqlCommand("insert into mesa(Codigo_mesa, Color_mesa,Cupo_mesa,disponibilidad_mesa )values (@Codigo_mesa, @Color_mesa, @Cupo_mesa,@disponibilidad_mesa)", c.conectar());
                insert.CommandType = CommandType.Text;
                insert.Parameters.AddWithValue("@Codigo_mesa", SqlDbType.Int).Value = Codigo_mesa;
                insert.Parameters.AddWithValue("@Color_mesa", SqlDbType.NVarChar).Value = Color_mesa;
                insert.Parameters.AddWithValue("@Cupo_mesa", SqlDbType.NVarChar).Value = Cupo_mesa;
                insert.Parameters.AddWithValue("@disponibilidad_mesa", SqlDbType.NVarChar).Value = disponibilidad_mesa;
                insert.ExecuteNonQuery();
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.Text = "";
                comboBox3.Text = "";



                MessageBox.Show(" Registro exitoso");

            }
            catch (Exception e)
            {
                MessageBox.Show("La mesa ya se encuentra registrado");
            }
        }
        public void Eliminar_mesa(int Codigo_mesa)
        {
            try
            {
                SqlCommand eliminar_m;
                eliminar_m = new SqlCommand("Delete from mesa Where Codigo_mesa = @Codigo_mesa", c.conectar());
                eliminar_m.CommandType = CommandType.Text;
                eliminar_m.Parameters.AddWithValue("@Codigo_mesa", SqlDbType.Int).Value = Codigo_mesa;
                eliminar_m.ExecuteNonQuery();
                MessageBox.Show("La mesa ha sido eliminado exitosamente");
                consultar_mesa();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void actualizar_mesa(int Codigo_mesa, string Color_mesa, string Cupo_mesa)
        {
            SqlCommand actualizar;
            actualizar = new SqlCommand("update mesa set Color_mesa=@Color_mesa,Cupo_mesa=@Cupo_mesa  where Codigo_mesa=@Codigo_mesa", c.conectar());
            try
            {
                actualizar.Parameters.AddWithValue("@Codigo_mesa", Codigo_mesa);
                actualizar.Parameters.AddWithValue("@Color_mesa", Color_mesa);
                actualizar.Parameters.AddWithValue("@Cupo_mesa", Cupo_mesa);
                actualizar.ExecuteNonQuery();
                ds.Clear();
                consultar_mesa();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                c.cerrar();
            }
        }
        public void consultar_mesa()
        {
            SqlCommand consulta_mesa;
            consulta_mesa = new SqlCommand("select*from mesa", c.conectar());
            consulta_mesa.CommandType = CommandType.Text;
            consulta_mesa.ExecuteNonQuery();
            ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter(consulta_mesa);
            da.Fill(ds, "mesa");
            try
            {
                dataGridView1.DataMember = ("mesa");
                dataGridView1.DataSource = ds;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void Consultar_Click(object sender, EventArgs e)
        {
            consultar_mesa();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            agregar_mesa(int.Parse(textBox1.Text), textBox2.Text,comboBox1.SelectedItem.ToString(),comboBox3.SelectedItem.ToString());

            consultar_mesa();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            actualizar_mesa(int.Parse(textBox3.Text),textBox4.Text, comboBox2.SelectedItem.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Eliminar_mesa(int.Parse(textBox3.Text));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString(); 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            menu_administrador ma = new menu_administrador();
            ma.Show();
            this.Hide();
        }
    }
}
