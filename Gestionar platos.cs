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
    public partial class Gestionar_platos : Form

    {
        Conexion c = new Conexion();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();

        public Gestionar_platos()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir de formulario de platos?", "Datos del plato", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            agregar_plato(int.Parse(textBox1.Text), textBox2.Text, comboBox1.SelectedItem.ToString());

            consultar_plato();
        }
        public void agregar_plato(int Codigo_plato, string Nombre_plato, string Precio_plato)
        {
            SqlCommand insert;
            try
            {
                insert = new SqlCommand("insert into plato(Codigo_plato, Nombre_plato, Precio_plato)values (@Codigo_plato, @Nombre_plato, @Precio_plato)", c.conectar());
                insert.CommandType = CommandType.Text;
                insert.Parameters.AddWithValue("@Codigo_plato", SqlDbType.Int).Value = Codigo_plato;
                insert.Parameters.AddWithValue("@Nombre_plato", SqlDbType.NVarChar).Value = Nombre_plato;
                insert.Parameters.AddWithValue("@Precio_plato", SqlDbType.NVarChar).Value = Precio_plato;
                insert.ExecuteNonQuery();
                textBox1.Text = "";  
                textBox2.Text = "";



                MessageBox.Show(" Registro exitoso");

            }
            catch (Exception e)
            {
                MessageBox.Show("El plato ya se encuentra registrado");
            }
        }
        public void consultar_plato()
        {
            SqlCommand consulta_b;
            consulta_b = new SqlCommand("select*from plato", c.conectar());
            consulta_b.CommandType = CommandType.Text;
            consulta_b.ExecuteNonQuery();
            ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter(consulta_b);
            da.Fill(ds, "plato");
            try
            {
                dataGridView1.DataMember = ("plato");
                dataGridView1.DataSource = ds;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void actualizar_plato(int Codigo_plato, string Precio_plato)
        {
            SqlCommand actualizar;
            actualizar = new SqlCommand("update plato set Precio_plato=@Precio_plato  where Codigo_plato=@Codigo_plato", c.conectar());
            try
            {
                actualizar.Parameters.AddWithValue("@Codigo_plato", Codigo_plato);
                actualizar.Parameters.AddWithValue("@Precio_plato", Precio_plato);
                actualizar.ExecuteNonQuery();
                ds.Clear();
                consultar_plato();
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

        private void button2_Click(object sender, EventArgs e)
        {
            actualizar_plato(int.Parse(textBox3.Text), comboBox2.SelectedItem.ToString());
        }

        private void Consultar_Click(object sender, EventArgs e)
        {
            consultar_plato();
        }
        public void Eliminar_plato(int Codigo_plato)
        {
            try
            {
                SqlCommand eliminar_b;
                eliminar_b = new SqlCommand("Delete from plato Where  Codigo_plato= @Codigo_plato", c.conectar());
                eliminar_b.CommandType = CommandType.Text;
                eliminar_b.Parameters.AddWithValue("@Codigo_plato", SqlDbType.Int).Value = Codigo_plato;
                eliminar_b.ExecuteNonQuery();
                MessageBox.Show("el plato ha sido eliminado exitosamente");
                consultar_plato();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Eliminar_plato(int.Parse(textBox3.Text));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void Gestionar_platos_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            menu_administrador ma = new menu_administrador();
            ma.Show();
            this.Hide();
        }
    }

}
