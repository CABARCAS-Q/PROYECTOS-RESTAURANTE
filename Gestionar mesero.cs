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
    public partial class Gestionar_mesero : Form
    {
        Conexion c = new Conexion();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();

        public Gestionar_mesero()
        {
            InitializeComponent();
        }

        public void agregar_mesero(int Id_mesero, string Nombre_mesero, string telefono_mesero, string disponibilidad_mesero)
        {
            SqlCommand insert;
            try
            {
                insert = new SqlCommand("insert into mesero(Id_mesero, Nombre_mesero,telefono_mesero,disponibilidad_mesero )values (@Id_mesero, @Nombre_mesero, @telefono_mesero,@disponibilidad_mesero)", c.conectar());
                insert.CommandType = CommandType.Text;
                insert.Parameters.AddWithValue("@Id_mesero", SqlDbType.Int).Value = Id_mesero;
                insert.Parameters.AddWithValue("@Nombre_mesero", SqlDbType.NVarChar).Value = Nombre_mesero;
                insert.Parameters.AddWithValue("@telefono_mesero", SqlDbType.NVarChar).Value = telefono_mesero;
                insert.Parameters.AddWithValue("@disponibilidad_mesero", SqlDbType.NVarChar).Value = disponibilidad_mesero;
                insert.ExecuteNonQuery();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox5.Text = "";
                comboBox1.Text = "";



                MessageBox.Show(" Registro exitoso");

            }
            catch (Exception e)
            {
                MessageBox.Show("El mesero ya se encuentra registrado");
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir de formulario del mesero?", "Datos de mesero", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }



        private void Consultar_Click(object sender, EventArgs e)
        {
            consultar_mesero();
        }


        private void Gestionar_mesero_Load(object sender, EventArgs e)

        {

        }
        public void Eliminar_mesero(int Id_mesero)
        {
            try
            {
                SqlCommand eliminar;
                eliminar = new SqlCommand("Delete from mesero Where Id_mesero = @Id_mesero", c.conectar());
                eliminar.CommandType = CommandType.Text;
                eliminar.Parameters.AddWithValue("@Id_mesero", SqlDbType.Int).Value = Id_mesero;
                eliminar.ExecuteNonQuery();
                MessageBox.Show("El mesero ha sido eliminado exitosamente");
                consultar_mesero();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void actualizar_mesero(int id_mesero, string telefono_mesero)
        {
            SqlCommand actualizar;
            actualizar = new SqlCommand("update mesero set telefono_mesero=@telefono_mesero  where id_mesero=@id_mesero", c.conectar());
            try
            {
                actualizar.Parameters.AddWithValue("@id_mesero", id_mesero);
                actualizar.Parameters.AddWithValue("@telefono_mesero", telefono_mesero);
                actualizar.ExecuteNonQuery();
                ds.Clear();
                consultar_mesero();
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

        public void consultar_mesero()
        {
            SqlCommand consulta_mesero;
            consulta_mesero = new SqlCommand("select*from mesero", c.conectar());
            consulta_mesero.CommandType = CommandType.Text;
            consulta_mesero.ExecuteNonQuery();
            ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter(consulta_mesero);
            da.Fill(ds, "mesero");
            try
            {
                dataGridView1.DataMember = ("mesero");
                dataGridView1.DataSource = ds;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            agregar_mesero(int.Parse(textBox1.Text),(textBox2.Text),textBox5.Text, comboBox1.SelectedItem.ToString()) ;

            consultar_mesero();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            actualizar_mesero(int.Parse(textBox3.Text), textBox4.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Eliminar_mesero(int.Parse(textBox3.Text));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            menu_administrador ma = new menu_administrador();
            ma.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
