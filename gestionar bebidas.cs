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
    public partial class gestionar_bebidas : Form
    {
        Conexion c = new Conexion();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();

        public gestionar_bebidas()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir de formulario de bebida?", "Datos de la bebida", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Consultar_Click(object sender, EventArgs e)
        {
            consultar_bebida();
        }

        private void gestionar_bebidas_Load(object sender, EventArgs e)
        {
            
        }   
        public void Eliminar_bebida(int Codigo_bebida)
        {
            try
            {
                SqlCommand eliminar_b;
                eliminar_b = new SqlCommand("Delete from bebida Where  Codigo_bebida= @Codigo_bebida", c.conectar());
                eliminar_b.CommandType = CommandType.Text;
                eliminar_b.Parameters.AddWithValue("@Codigo_bebida", SqlDbType.Int).Value = Codigo_bebida;
                eliminar_b.ExecuteNonQuery();
                MessageBox.Show("La bebida ha sido eliminado exitosamente");
                consultar_bebida();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void actualizar_bebida(int Codigo_bebida, string Precio_bebida)
        {
            SqlCommand actualizar;
            actualizar = new SqlCommand("update bebida set Precio_bebida=@Precio_bebida  where Codigo_bebida=@Codigo_bebida", c.conectar());
            try
            {
                actualizar.Parameters.AddWithValue("@Codigo_bebida", Codigo_bebida);
                actualizar.Parameters.AddWithValue("@Precio_bebida", Precio_bebida);
                actualizar.ExecuteNonQuery();
                ds.Clear();

                consultar_bebida();
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
        public void agregar_bebida(int Codigo_bebida, string Nombre_bebida, string Precio_bebida)
        {
            SqlCommand insert;
            try
            {
                insert = new SqlCommand("insert into bebida(Codigo_bebida, Nombre_bebida, Precio_bebida)values (@Codigo_bebida, @Nombre_bebida, @Precio_bebida)", c.conectar());
                insert.CommandType = CommandType.Text;
                insert.Parameters.AddWithValue("@Codigo_bebida", SqlDbType.Int).Value = Codigo_bebida;
                insert.Parameters.AddWithValue("@Nombre_bebida", SqlDbType.NVarChar).Value = Nombre_bebida;
                insert.Parameters.AddWithValue("@Precio_bebida", SqlDbType.NVarChar).Value = Precio_bebida;
                insert.ExecuteNonQuery();
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.Text = "";

                


                MessageBox.Show(" Registro exitoso");

            }
            catch (Exception e)
            {
                MessageBox.Show("La bebida ya se encuentra registrado");
            }
        }
        public void consultar_bebida()
        {
            SqlCommand consulta_b;
            consulta_b = new SqlCommand("select*from bebida", c.conectar());
            consulta_b.CommandType = CommandType.Text;
            consulta_b.ExecuteNonQuery();
            ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter(consulta_b);
            da.Fill(ds, "bebida");
            try
            {
                dataGridView1.DataMember = ("bebida");
                dataGridView1.DataSource = ds;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            agregar_bebida(int.Parse(textBox1.Text), textBox2.Text, comboBox1.SelectedItem.ToString());

            consultar_bebida();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text="";
            textBox3.Text = "";
            comboBox2.Text="";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            actualizar_bebida(int.Parse(textBox3.Text), comboBox2.SelectedItem.ToString());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Eliminar_bebida(int.Parse(textBox3.Text));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            menu_administrador ma = new menu_administrador();
            ma.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
