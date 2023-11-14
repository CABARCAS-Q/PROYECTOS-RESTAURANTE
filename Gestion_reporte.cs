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
    public partial class Gestion_reporte : Form
    {
        Conexion c = new Conexion();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();

        public Gestion_reporte()
        {
            InitializeComponent();
        }
        public void consultar()
        {
            SqlCommand consulta;
            consulta = new SqlCommand("select*from pedido", c.conectar());
            consulta.CommandType = CommandType.Text;
            consulta.ExecuteNonQuery();
            ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter(consulta);
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
            consultar();
        }

        private void Gestion_reporte_Load(object sender, EventArgs e)
        {

        }
        public void actualizar_mesero(int id_mesero, string disponibilidad_mesero)
        {
            SqlCommand actualizar;
            actualizar = new SqlCommand("update mesero set disponibilidad_mesero=@disponibilidad_mesero  where id_mesero=@id_mesero", c.conectar());
            try
            {
                actualizar.Parameters.AddWithValue("@id_mesero", id_mesero);
                actualizar.Parameters.AddWithValue("@disponibilidad_mesero", disponibilidad_mesero);
                actualizar.ExecuteNonQuery();
                ds.Clear();
                
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
                

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void actualizar_mesa(int Codigo_mesa, string disponibilidad_mesa)
        {
            SqlCommand actualizar;
            actualizar = new SqlCommand("update mesa set disponibilidad_mesa=@disponibilidad_mesa  where Codigo_mesa=@Codigo_mesa", c.conectar());
            try
            {
                actualizar.Parameters.AddWithValue("@disponibilidad_mesa", disponibilidad_mesa);
                actualizar.Parameters.AddWithValue("@Codigo_mesa", @Codigo_mesa);


                actualizar.ExecuteNonQuery();
                ds.Clear();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Registro exitoso");
            }
            finally
            {
                c.cerrar();
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            menu_cajero gb = new menu_cajero();
            gb.Show();
            this.Hide();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            actualizar_mesa(int.Parse(textBox5.Text), textBox11.Text);

            actualizar_mesero(int.Parse(textBox4.Text), textBox10.Text);

            //Eliminar_pedido(int.Parse(textBox6.Text));

            Reporte gma = new Reporte();
            gma.Show();
            this.Hide();


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
