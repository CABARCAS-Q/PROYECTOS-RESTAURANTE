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
    public partial class Gestion_usuario : Form
    {
        Conexion c = new Conexion();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();

        public Gestion_usuario()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Gestion_usuario_Load(object sender, EventArgs e)
        {

        }
        public void consultar()
        {
            SqlCommand consulta;
            consulta = new SqlCommand("select*from usuario", c.conectar());
            consulta.CommandType = CommandType.Text;
            consulta.ExecuteNonQuery();
            ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter(consulta);
            da.Fill(ds, "usuario");
            try
            {
                dataGridView1.DataMember = ("usuario");
                dataGridView1.DataSource = ds;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void actualizar(int Id_usuario, string Contraseña_usuario)
        {
            SqlCommand actualizacion;
            actualizacion = new SqlCommand("update usuario set Contraseña_usuario=@Contraseña_usuario  where Id_usuario=@Id_usuario", c.conectar());
            try
            {
                actualizacion.Parameters.AddWithValue("@Id_usuario", Id_usuario);
                actualizacion.Parameters.AddWithValue("@Contraseña_usuario", Contraseña_usuario);
                actualizacion.ExecuteNonQuery();
                ds.Clear();
                consultar();
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
        public void Eliminar(int Id_usuario)
        {
            try
            {
                SqlCommand eliminar;
                eliminar = new SqlCommand("Delete from usuario Where Id_usuario = @Id_usuario", c.conectar());
                eliminar.CommandType = CommandType.Text;
                eliminar.Parameters.AddWithValue("@Id_usuario", SqlDbType.Int).Value = Id_usuario;
                eliminar.ExecuteNonQuery();
                MessageBox.Show("El Usuario ha sido eliminado exitosamente");
                consultar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void insertar_registro(int Id_usuario, string Contraseña_usuario, string Tipo_usuario)
        {
            SqlCommand insert;
            try
            {
                insert = new SqlCommand("insert into usuario(Id_usuario, Contraseña_usuario, Tipo_usuario)values (@Id_usuario, @Contraseña_usuario, @Tipo_usuario)", c.conectar());
                insert.CommandType = CommandType.Text;
                insert.Parameters.AddWithValue("@Id_usuario", SqlDbType.Int).Value = Id_usuario;
                insert.Parameters.AddWithValue("@Contraseña_usuario", SqlDbType.NVarChar).Value = Contraseña_usuario;
                insert.Parameters.AddWithValue("@Tipo_usuario",SqlDbType.NVarChar).Value = Tipo_usuario;
                insert.ExecuteNonQuery();
                textBox3.Text = "";
                textBox4.Text = "";
                comboBox1.Text = "";


                MessageBox.Show(" Registro exitoso");

            }
            catch (Exception e)
            {
                MessageBox.Show("El usuario ya se encuentra registrado");
            }
        }

        private void Consultar_Click(object sender, EventArgs e)
        {
            consultar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            actualizar(int.Parse(textBox3.Text), textBox4.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insertar_registro(int.Parse(textBox1.Text), textBox2.Text,comboBox1.SelectedItem.ToString());
            consultar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Eliminar(int.Parse(textBox3.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Focus();
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir de formulario del usuario?", "Datos de usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
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
