using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace proyecto__gestion_de_pedido
{
    class Query
    {
        Conexion c = new Conexion();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        Boolean Estado_conexion = false;

        public static string tipousuario;



        public Boolean iniciarsesion(int Id_usuario, string Contraseña_usuario)
        {
            SqlCommand consulta;
            consulta = new SqlCommand("Select Id_usuario ,Tipo_usuario, Contraseña_usuario From Usuario where Id_usuario=@Id_usuario and Contraseña_usuario=@Contraseña_usuario", c.conectar());
            consulta.CommandType = CommandType.Text;
            consulta.Parameters.AddWithValue("@Id_usuario", Id_usuario);
            consulta.Parameters.AddWithValue("@Contraseña_usuario", Contraseña_usuario);
            consulta.ExecuteNonQuery();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(consulta);
                da.Fill(ds, "Usuario");

                DataRow dr;
                dr = ds.Tables["Usuario"].Rows[0];

                if (Convert.ToString(Id_usuario) == dr["Id_usuario"].ToString() & Contraseña_usuario == dr["Contraseña_usuario"].ToString() & (dr["Tipo_usuario"].ToString() == "administrador"))
                {
                    menu_administrador ma = new menu_administrador();
                    ma.Show();
                    Estado_conexion = true;
                    tipousuario = "administrador";
                }
                DataRow dd;
                if (Convert.ToString(Id_usuario) == dr["Id_usuario"].ToString() & Contraseña_usuario == dr["Contraseña_usuario"].ToString() & (dr["Tipo_usuario"].ToString() == "cajero"))
                {
                    menu_cajero infc = new menu_cajero();
                    infc.Show();
                    Estado_conexion = true;
                    tipousuario = "cajero";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("usuario o contraseña invalida");
            }


            finally
            {
                c.cerrar();
            }
            return Estado_conexion;
        }

        
       
    }

}
