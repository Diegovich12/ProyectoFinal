using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ProyectoNutrical.Models
{
    public class ModelProveedores
    {
        //las llaves foraneas no las agrege por que pienso utilizar las propiedades id como los campos fk para no utilizar mas memoria
        public ModelProveedores()
        {
        }

        public ModelProveedores(int pidProveedor, string pNombre, string pProveedor, int pidCamiones, string pMatricula, string pNoPipa,
            int pidRancho, string pRancho)
        {
            IdProveedor = pidProveedor;
            Nombre = pNombre;
            Proveedor = pProveedor;
            IdCamiones = pidCamiones;
            Matricula = pMatricula;
            NoPipa = pNoPipa;
            IdRancho = pidRancho;
            Rancho = pRancho;
        }

        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string Proveedor { get; set; }
        public int IdCamiones { get; set; }
        public string Matricula { get; set; }
        public string NoPipa { get; set; }
        public int IdRancho { get; set; }
        public string Rancho { get; set; }

        //metodo para agregar a este metodo agregar le hace falta hacer un procedimiento almacenada para que cuando inserte provedores inserte tambien ranchos y camiones
        public static int Agregar(ModelProveedores pModelProveedores)
        {
            var comando =
                new MySqlCommand($"INSERT INTO proveedores (NombreProveedor, Proveedor, Matricula, Rancho, NoPipa) VALUES ('{pModelProveedores.Nombre}','{pModelProveedores.Proveedor}','{pModelProveedores.Matricula}','{pModelProveedores.Rancho}','{pModelProveedores.NoPipa}')",

                    ConexionMySql.ObtenerConexion());

           var retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        /// <summary>
        ///     este metodo se utiliza para rellenar el gridview altaprovedores
        /// </summary>
        public static List<ModelProveedores> Llenargrid()
        {
            var lista = new List<ModelProveedores>();

            var comando = new MySqlCommand("SELECT * FROM proveedores", ConexionMySql.ObtenerConexion());
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var pModelProveedores = new ModelProveedores
                {
                    IdProveedor = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Proveedor = reader.GetString(2),
                    Matricula = reader.GetString(3),
                    Rancho = reader.GetString(4),
                    NoPipa = reader.GetString(5)
                };
                lista.Add(pModelProveedores);
            }
            return lista;
        }

     public static List<ModelProveedores> Llenarcombo(string nombre)
        {
            var lista = new List<ModelProveedores>();
            MySqlCommand comando;

            // este if es para que con este mismo metodo rellene a los combo box 
            if (nombre == "Proveedor")
            {
                comando = new MySqlCommand("SELECT * FROM proveedores", ConexionMySql.ObtenerConexion());
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var pModelProveedores = new ModelProveedores
                    {
                        IdProveedor = reader.GetInt32(0),
                        Proveedor = reader.GetString(2)
                    };
                    lista.Add(pModelProveedores);
                }
            }
            else
            {
                comando = new MySqlCommand("SELECT * FROM ranchos", ConexionMySql.ObtenerConexion());
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var pModelProveedores = new ModelProveedores
                    {
                        IdRancho = reader.GetInt32(0),
                        Rancho = reader.GetString(4)
                    };
                    lista.Add(pModelProveedores);
                }
            }

            return lista;
        }

        //metodo para buscar
        public static List<ModelProveedores> Buscar(string pNombre)
        {            
            var lista = new List<ModelProveedores>();

            //aca tendrias que cambiar la queri para que te busque por cualquiera de los 4 parametros

            var comando = new MySqlCommand($"SELECT * FROM proveedores WHERE NombreProveedor='{pNombre}'",
                ConexionMySql.ObtenerConexion());
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var pModelProveedores = new ModelProveedores
                {
                    IdProveedor = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Proveedor = reader.GetString(2),
                    Matricula = reader.GetString(3),
                    Rancho = reader.GetString(4),
                    NoPipa = reader.GetString(5)
                };

                lista.Add(pModelProveedores);
            }
            return lista;
        }

        public static ModelProveedores ObtenerProveedor(int pidProveedor)
        {
            var pModelProveedores = new ModelProveedores();
            var connec = ConexionMySql.ObtenerConexion();

            var comando = new MySqlCommand($"SELECT * FROM proveedores WHERE idproveedores ='{pidProveedor}'", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                ProveedorSelec.IdProveedor = reader.GetInt32(0);
                ProveedorSelec.Nombre = reader.GetString(1);
                ProveedorSelec.Proveedor = reader.GetString(2);
                ProveedorSelec.Matricula = reader.GetString(3);
                ProveedorSelec.NoPipa = reader.GetString(4);
                ProveedorSelec.Rancho = reader.GetString(5);
            }
            connec.Close();
            return pModelProveedores;
        }

        //metodo para actualizar
        public static int Actualizar(ModelProveedores pModelProveedores)
        {
            var conexion = ConexionMySql.ObtenerConexion();
            var comando =
                new MySqlCommand(
                    $"UPDATE proveedores SET Nombre='{pModelProveedores.Nombre}', Proveedor='{pModelProveedores.Proveedor}', Matricula='{pModelProveedores.Matricula}', NoPipa='{pModelProveedores.NoPipa}', Rancho='{pModelProveedores.Rancho}' WHERE idproveedor='{pModelProveedores.IdProveedor}'",
                    conexion);
            var retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }

        //metodo para eliminar
        public static int Eliminar(int pidProveedor)
        {
            var conexion = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"DELETE FROM proveedores WHERE idproveedor='{pidProveedor}'", conexion);
            var retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }

        public static class ProveedorSelec
        {
            public static int IdProveedor { get; set; }
            public static string Nombre { get; set; }
            public static string Matricula { get; set; }
            public static string NoPipa { get; set; }
            public static string Proveedor { get; set; }
            public static string Rancho { get; set; }
        }
    }
}