using MySql.Data.MySqlClient;

namespace ProyectoNutrical
{
    public class ConexionMySql
    {
        public static MySqlConnection ObtenerConexion()
        {     
            var StringConnection = "server=127.0.0.1; database=nutrical; Uid=root; pwd=123456;";

            // se utiliza el using para que cuando lo deje de usar desocupe la memoria y se puede utilizar en otro proceso      
            var conectar = new MySqlConnection(StringConnection);

            conectar.Open();
            return conectar;
            /* a esto aun le hace falta un meto de desconexion para que
             *  la base de datos termine las conexiones lo anterior solo
             *   afecta a la aplicacion de escitorio */
        }
    }
}