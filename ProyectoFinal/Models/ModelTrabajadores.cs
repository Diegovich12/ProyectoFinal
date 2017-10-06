using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ProyectoNutrical.Models
{
    public class ModelTrabajadores
    {
        public ModelTrabajadores() {}

        public ModelTrabajadores(int pidTrabajador, string pNombre, string pApellidoPaterno, string pApellidoMaterno,
            int pidPuesto, string pPuesto, int pidUsuario, string pUsuario, string pContrasena)
        {
            IdTrabajador = pidTrabajador;
            Nombre = pNombre;
            ApellidoPaterno = pApellidoPaterno;
            ApellidoMaterno = pApellidoMaterno;
            IdPuesto = pidPuesto;
            Puesto = pPuesto;
            IdUsuario = pidUsuario;
            Usuario = pUsuario;
            Contrasena = pContrasena;
        }

        public int IdTrabajador { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int IdPuesto { get; set; }
        public string Puesto { get; set; }
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }

        /// <summary>
        ///     metodo para mostrar los puestos en el combobox puestos
        /// </summary>
        public static List<ModelTrabajadores> Llenarcombo()
        {
            var lista = new List<ModelTrabajadores>();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM puestos", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var pTrabajadores = new ModelTrabajadores
                {
                    IdPuesto = reader.GetInt32(0),
                    Puesto = reader.GetString(1)
                };
                lista.Add(pTrabajadores);
            }
            return lista;
        }

        /// <summary>
        /// este Metodo Obtiene los nombres de los Trabajadores dependiendo de su puesto
        /// </summary>
        public static List<ModelTrabajadores> LlenarcomboTrabajadores(int trabajador)
        {
            var lista = new List<ModelTrabajadores>();
            var connec = ConexionMySql.ObtenerConexion();

            var comando = new MySqlCommand($"SELECT IDTrabajador, CONCAT(Nombre, ' ', ApellidoPaterno, ' ', ApellidoMaterno ) AS Nombre FROM nutrical.trabajadores WHERE Puesto = '{trabajador}';", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var pRecepcion = new ModelTrabajadores
                {
                    IdTrabajador = reader.GetInt32(0),
                    Nombre = reader.GetString(1)
                };
                lista.Add(pRecepcion);
            }
            return lista;
        }

        /// <summary>
        ///     este metodo se utiliza para rellenar el gridview altaprovedores
        /// </summary>
        public static List<ModelTrabajadores> Llenargrid()
        {
            var lista = new List<ModelTrabajadores>();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM viewtrabajadores", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var pTrabajadores = new ModelTrabajadores
                {
                    IdTrabajador = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    ApellidoPaterno = reader.GetString(2),
                    ApellidoMaterno = reader.GetString(3),
                    IdPuesto = reader.GetInt32(4),
                    Puesto = reader.GetString(5),
                    IdUsuario = reader.GetInt32(6),
                    Usuario = reader.GetString(7)
                };
                lista.Add(pTrabajadores);
            }
            return lista;
        }

        /// <summary>
        ///     metodo para agregar
        /// </summary>
        public static int Agregar(ModelTrabajadores pTrabajador)
        {
            var connec = ConexionMySql.ObtenerConexion();
            var comando =
                new MySqlCommand(
                    $"CALL InToUser('{pTrabajador.Nombre}','{pTrabajador.ApellidoPaterno}','{pTrabajador.ApellidoMaterno}','{pTrabajador.Contrasena}','{pTrabajador.Usuario}','{pTrabajador.Puesto}')",
                    connec);
            var retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        /// <summary>
        ///     metodo buscar
        /// </summary>
        public static List<ModelTrabajadores> Buscar(string pNombre, string pApellidoP, string pApellidoM)
        {
            var lista = new List<ModelTrabajadores>();
            var connec = ConexionMySql.ObtenerConexion();
            var comando =
                new MySqlCommand(
                    $"SELECT * FROM viewtrabajadores WHERE Nombre='{pNombre}' OR ApellidoPaterno='{pApellidoP}' OR ApellidoMaterno='{pApellidoM}'",
                    connec);
            var reader = comando.ExecuteReader();
            var pTrabajador = new ModelTrabajadores
            {
                IdTrabajador = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                ApellidoPaterno = reader.GetString(2),
                ApellidoMaterno = reader.GetString(3),
                IdPuesto = reader.GetInt32(4),
                Puesto = reader.GetString(5),
                IdUsuario = reader.GetInt32(6),
                Usuario = reader.GetString(7)
            };
            while (reader.Read())
                lista.Add(pTrabajador);
            return lista;
        }

        public static ModelTrabajadores ObtenerTrabajador(int pidTrabajador)
        {
            var pTrabajador = new ModelTrabajadores();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"SELECT * FROM viewtrabajadores WHERE IDTrabajador='{pidTrabajador}'",
                connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                TrabajadorSelec.IdTrabajador = reader.GetInt32(0);
                TrabajadorSelec.Nombre = reader.GetString(1);
                TrabajadorSelec.ApellidoPaterno = reader.GetString(2);
                TrabajadorSelec.ApellidoMaterno = reader.GetString(3);
                TrabajadorSelec.IdPuesto = reader.GetInt32(4);
                TrabajadorSelec.Puesto = reader.GetString(5);
                TrabajadorSelec.IdUsuario = reader.GetInt32(6);
                TrabajadorSelec.Usuario = reader.GetString(7);
            }
            connec.Close();
            return pTrabajador;
        }

        /// <summary>
        ///     metodo para actualizar
        /// </summary>
        public static int Actualizar(ModelTrabajadores pTrabajador, int pOperacion)
        {
            var retorno = 0;
            var conexion = ConexionMySql.ObtenerConexion();
            MySqlCommand comando;

            switch (pOperacion)
            {
                case 1: //actualizar los datos del trabajador
                    comando = new MySqlCommand(
                        $"CALL ActualizarTrabajadores('{pOperacion}','{pTrabajador.IdTrabajador}','{pTrabajador.IdUsuario}','{pTrabajador.IdPuesto}','{pTrabajador.Nombre}','{pTrabajador.ApellidoPaterno}','{pTrabajador.ApellidoMaterno}','a','a')",
                        conexion);
                    retorno = comando.ExecuteNonQuery();
                    break;
                case 2: //actualizar los datos del Usuarios
                    comando = new MySqlCommand(
                        $"CALL ActualizarTrabajadores('{pOperacion}','{pTrabajador.IdTrabajador}','{pTrabajador.IdUsuario}','{pTrabajador.IdPuesto}','a','a','a','{pTrabajador.Usuario}','{pTrabajador.Contrasena}')",
                        conexion);
                    retorno = comando.ExecuteNonQuery();
                    break;
                case 3: //actualizar los datos de trabajador y Usuarios
                    comando = new MySqlCommand(
                        $"CALL ActualizarTrabajadores('{pOperacion}','{pTrabajador.IdTrabajador}','{pTrabajador.IdUsuario}','{pTrabajador.IdPuesto}','{pTrabajador.Nombre}','{pTrabajador.ApellidoPaterno}','{pTrabajador.ApellidoMaterno}','{pTrabajador.Usuario}','{pTrabajador.Contrasena}')",
                        conexion);
                    retorno = comando.ExecuteNonQuery();
                    break;
            }
            return retorno;
        }

        /// <summary>
        ///     metodo para eliminar
        /// </summary>
        public static int Eliminar(int pidTrabajador, int pidUsuario)
        {
            var conexion = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"CALL deteteTrabajador ('{pidTrabajador}','{pidUsuario}')", conexion);
            var retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }

        public static class TrabajadorSelec
        {
            public static int IdTrabajador { get; set; }
            public static string Nombre { get; set; }
            public static string ApellidoPaterno { get; set; }
            public static string ApellidoMaterno { get; set; }
            public static int IdPuesto { get; set; }
            public static string Puesto { get; set; }
            public static int IdUsuario { get; set; }
            public static string Usuario { get; set; }
        }
    }
}