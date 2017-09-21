using MySql.Data.MySqlClient;

namespace ProyectoNutrical.Models
{
    public class ModelLogin
    {
        public ModelLogin()
        {
        }

        public ModelLogin(int pIdUcuario, string pUsuario, string pPassword)
        {
            IdUcuario = pIdUcuario;
            Usuario = pUsuario;
            Password = pPassword;
        }

        public int IdUcuario { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }

        public static int LogIn(ModelLogin pModelLogin)
        {
            var retorno = 0;
            var comando = new MySqlCommand($"CALL validacion('{pModelLogin.Password}','{pModelLogin.Usuario}')",
                ConexionMySql.ObtenerConexion());
            var reader = comando.ExecuteReader();
            while (reader.Read())
                retorno = reader.GetInt32(0);
            return retorno;
        }
    }
}