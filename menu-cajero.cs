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
    public partial class menu_cajero : Form
    {
        Conexion c = new Conexion();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();

        public menu_cajero()
        {
            InitializeComponent();
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
                dataGridView4.DataMember = ("bebida");
                dataGridView4.DataSource = ds;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

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
                dataGridView5.DataMember = ("mesa");
                dataGridView5.DataSource = ds;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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
                dataGridView3.DataMember = ("plato");
                dataGridView3.DataSource = ds;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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
                dataGridView2.DataMember = ("mesero");
                dataGridView2.DataSource = ds;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir de formulario del cajero?", "menu de cajero", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox2.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            dateTimePicker1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            consultar_plato();
            dataGridView3.Visible = true;
            dataGridView2.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;


        }

        private void menu_cajero_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            consultar_mesa();
            dataGridView5.Visible = true;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            consultar_bebida();
            dataGridView4.Visible = true;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView5.Visible = false;

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
                consultar_mesa();
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


        private void button8_Click(object sender, EventArgs e)
        {
            consultar_mesero();
            dataGridView2.Visible = true;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;

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
                dataGridView4.DataMember = ("pedido");
                dataGridView4.DataSource = ds;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {




        }
        public void guardar_pedido(int id_pedido, string fecha_pedido, int cantidad_plato, int cantidad_bebida, string nombre_plato, string nombre_bebida, int precio_plato, int precio_bebida, int codigo_mesa, int codigo_mesero)
        {
            SqlCommand insert;
            try
            {
                insert = new SqlCommand("insert into pedido(id_pedido,fecha_pedido,cantidad_plato,cantidad_bebida,nombre_plato,nombre_bebida,precio_plato,precio_bebida,codigo_mesa,codigo_mesero) values (@id_pedido,@fecha_pedido,@cantidad_plato,@cantidad_bebida,@nombre_plato,@nombre_bebida,@precio_plato,@precio_bebida,@codigo_mesa,@codigo_mesero )", c.conectar());
                insert.CommandType = CommandType.Text;
                insert.Parameters.AddWithValue("@id_pedido", SqlDbType.Int).Value = id_pedido;
                insert.Parameters.AddWithValue("@fecha_pedido", SqlDbType.NVarChar).Value = fecha_pedido;
                insert.Parameters.AddWithValue("@cantidad_plato", SqlDbType.Int).Value = cantidad_plato;
                insert.Parameters.AddWithValue("@cantidad_bebida", SqlDbType.Int).Value = cantidad_bebida;
                insert.Parameters.AddWithValue("@nombre_plato", SqlDbType.NVarChar).Value = nombre_plato;
                insert.Parameters.AddWithValue("@nombre_bebida", SqlDbType.NVarChar).Value = nombre_bebida;
                insert.Parameters.AddWithValue("@precio_plato", SqlDbType.Int).Value = precio_plato;
                insert.Parameters.AddWithValue("@precio_bebida", SqlDbType.Int).Value = precio_bebida;
                insert.Parameters.AddWithValue("@codigo_mesa", SqlDbType.Int).Value = codigo_mesa;
                insert.Parameters.AddWithValue("@codigo_mesero", SqlDbType.Int).Value = codigo_mesero;
                insert.ExecuteNonQuery();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                dateTimePicker1.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                


                MessageBox.Show(" Registro exitoso");

            }
            catch (Exception e)
            {
                MessageBox.Show("El pedido ya se encuentra registrado");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox8.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
            textBox7.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView5.CurrentRow.Cells[0].Value.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void button9_Click(object sender, EventArgs e)
        {


            actualizar_mesa(int.Parse(textBox5.Text), textBox6.Text);

            actualizar_mesero(int.Parse(textBox4.Text), textBox9.Text);

            guardar_pedido(int.Parse(textBox2.Text), (dateTimePicker1.Text), int.Parse(comboBox1.Text), int.Parse(comboBox2.Text), (textBox1.Text), (textBox8.Text), int.Parse(textBox3.Text), int.Parse(textBox7.Text), int.Parse(textBox5.Text), int.Parse(textBox4.Text));

            consultar();

            dataGridView4.Visible = true;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView5.Visible = false;




        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Gestion_reporte gb = new Gestion_reporte();
            gb.Show();
            this.Hide();
        }
    }
}
                     

      
    

