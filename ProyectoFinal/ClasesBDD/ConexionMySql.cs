using MySql.Data.MySqlClient;

namespace ProyectoNutrical
{
    public class ConexionMySql
    {
        public static MySqlConnection ObtenerConexion()
        {     
            var StringConnection = "server=127.0.0.1; database=nutrical; Uid=root; pwd=123456;";     
            var conectar = new MySqlConnection(StringConnection);
            conectar.Open();
            return conectar;
        }
    }
}