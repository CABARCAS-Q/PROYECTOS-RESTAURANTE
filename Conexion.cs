using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace proyecto__gestion_de_pedido
{
    class Conexion
    {
        SqlConnection con;
        
        public SqlConnection conectar()
        {
            try
            {
               con = new SqlConnection("data source=DESKTOP-058521; Initial catalog = usuario; Integrated Security= true");
                con.Open();
        }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return con;
        }
        public void cerrar()
        {
            con.Close();
        }
        
    }
}
