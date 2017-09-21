using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProyectoNutrical.Models
{
    class ModelComprasP
    {
        public ModelComprasP()
        {
        }

        public ModelComprasP(int pIdCompra, DateTime pFecha, double pNoPipa, double pProveedor, double pRancho,
            double pNoRemision, DateTime pFechaLlegada,
            double pPlacas, double pAnalista, double pSello1, double pSello2, double pTipoProducto, double pDensidad,
            double pGrasa, double pSNG,
            double pST, double pCrioscopia, double pProteina, double pKilos, double pLitros)
        {
            IdCompra = pIdCompra;
            Fecha = pFecha;
            NoPipa = pNoPipa;
            Proveedor = pProveedor;
            Rancho = pRancho;
            NoRemision = pNoRemision;
            FechaLlegada = pFechaLlegada;
            Placas = pPlacas;
            Analista = pAnalista;
            Sello1 = pSello1;
            Sello2 = pSello2;
            TipoProducto = pTipoProducto;
            Densidad = pDensidad;
            Grasa = pGrasa;
            SNG = pSNG;
            ST = pST;
            Crioscopia = pCrioscopia;
            Proteina = pProteina;
            Kilos = pKilos;
            Litros = pLitros;
        }

        public int IdCompra { get; set; }
        public DateTime Fecha { get; set; }
        public double NoPipa { get; set; }
        public double Proveedor { get; set; }
        public double Rancho { get; set; }
        public double NoRemision { get; set; }
        public DateTime FechaLlegada { get; set; }
        public double Placas { get; set; }
        public double Analista { get; set; }
        public double Sello1 { get; set; }
        public double Sello2 { get; set; }
        public double TipoProducto { get; set; }
        public double Densidad { get; set; }
        public double Grasa { get; set; }
        public double SNG { get; set; }
        public double ST { get; set; }
        public double Crioscopia { get; set; }
        public double Proteina { get; set; }
        public double Kilos { get; set; }
        public double Litros { get; set; }

        public static List<ModelComprasP> Llenargrid()
        {
            var lista = new List<ModelComprasP>();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM compras", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var pModelComprasP = new ModelComprasP
                {
                    IdCompra = reader.GetInt32(0),
                    Fecha = reader.GetDateTime(1),
                    NoPipa = reader.GetInt32(2),
                    Proveedor = reader.GetDouble(3),
                    Rancho = reader.GetDouble(4),
                    NoRemision = reader.GetDouble(5),
                    FechaLlegada = reader.GetDateTime(6),
                    Placas = reader.GetDouble(7),
                    Analista = reader.GetDouble(8),
                    Sello1 = reader.GetDouble(9),
                    Sello2 = reader.GetDouble(10),
                    TipoProducto = reader.GetDouble(11),
                    Densidad = reader.GetDouble(12),
                    Grasa = reader.GetDouble(13),
                    SNG = reader.GetDouble(14),
                    ST = reader.GetDouble(15),
                    Crioscopia = reader.GetDouble(16),
                    Proteina = reader.GetDouble(17),
                    Kilos = reader.GetDouble(18),
                    Litros = reader.GetDouble(19)
                };
                lista.Add(pModelComprasP);
            }
            return lista;
        }


        /// <summary>
        ///     metodo para agregar
        /// </summary>
        public static int Agregar(ModelComprasP pMcp)
        {
            var connec = ConexionMySql.ObtenerConexion();
            var comando =
                new MySqlCommand(
                    $"CALL spInsertCompras('{pMcp.IdCompra}','{pMcp.Fecha}','{pMcp.NoPipa}','{pMcp.Proveedor}','{pMcp.Rancho}','{pMcp.NoRemision}','{pMcp.FechaLlegada}','{pMcp.Placas}','{pMcp.Analista}','{pMcp.Sello1}','{pMcp.Sello2}','{pMcp.TipoProducto}','{pMcp.Densidad}','{pMcp.Grasa}','{pMcp.SNG}','{pMcp.ST}','{pMcp.Crioscopia}','{pMcp.Proteina}','{pMcp.Kilos}','{pMcp.Litros}')",
                    connec);
            var retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        /// <summary>
        ///     metodo para eliminar
        /// </summary>
        public static int Eliminar(int IDCompra)
        {
            var conexion = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"DELETE FROM compras WHERE ID = '{IDCompra}'", conexion);
            var retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }
        public static List<ModelComprasP> Buscar(string pId)
        {
            List<ModelComprasP> _lista = new List<ModelComprasP>();

            MySqlCommand _comando = new MySqlCommand(string.Format("SELECT * FROM compras WHERE NoRemision='{0}'", pId), ConexionMySql.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                ModelComprasP pComprasP = new ModelComprasP();
                pComprasP.IdCompra = _reader.GetInt32(0);
                pComprasP.Fecha = _reader.GetDateTime(1);
                pComprasP.NoPipa = _reader.GetDouble(2);
                pComprasP.Proveedor = _reader.GetDouble(3);
                pComprasP.Rancho = _reader.GetDouble(4);
                pComprasP.NoRemision = _reader.GetDouble(5);
                pComprasP.FechaLlegada = _reader.GetDateTime(6);
                pComprasP.Placas = _reader.GetDouble(7);
                pComprasP.Analista = _reader.GetDouble(8);
                pComprasP.Sello1 = _reader.GetDouble(9);
                pComprasP.Sello2 = _reader.GetDouble(10);
                pComprasP.TipoProducto = _reader.GetDouble(11);
                pComprasP.Densidad = _reader.GetDouble(12);
                pComprasP.Grasa = _reader.GetDouble(13);
                pComprasP.SNG = _reader.GetDouble(14);
                pComprasP.ST = _reader.GetDouble(15);
                pComprasP.Crioscopia = _reader.GetDouble(16);
                pComprasP.Proteina = _reader.GetDouble(17);
                pComprasP.Kilos = _reader.GetDouble(18);
                pComprasP.Litros = _reader.GetDouble(19);

                _lista.Add(pComprasP);
            }
            return _lista;
        }

        internal static int Eliminar(int idCompra1, int idCompra2)
        {
            throw new NotImplementedException();
        }

        public static ModelComprasP ObtenerCompras(int pIdCompraP)
        {
            var pMs = new ModelComprasP();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"SELECT * FROM compras WHERE ID ='{pIdCompraP}'", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                ComprasPSelect.IdCompra = reader.GetInt32(0);
                ComprasPSelect.Fecha = reader.GetDateTime(1);
                ComprasPSelect.NoPipa = reader.GetInt32(2);
                ComprasPSelect.Proveedor = reader.GetDouble(3);
                ComprasPSelect.Rancho = reader.GetDouble(4);
                ComprasPSelect.NoRemision = reader.GetDouble(5);
                ComprasPSelect.FechaLlegada = reader.GetDateTime(6);
                ComprasPSelect.Placas = reader.GetDouble(7);
                ComprasPSelect.Analista = reader.GetDouble(8);
                ComprasPSelect.Sello1 = reader.GetDouble(9);
                ComprasPSelect.Sello2 = reader.GetDouble(10);
                ComprasPSelect.TipoProducto = reader.GetDouble(11);
                ComprasPSelect.Densidad = reader.GetDouble(12);
                ComprasPSelect.Grasa = reader.GetDouble(13);
                ComprasPSelect.SNG = reader.GetDouble(14);
                ComprasPSelect.ST = reader.GetString(15);
                ComprasPSelect.Crioscopia = reader.GetDouble(16);
                ComprasPSelect.Proteina = reader.GetDouble(17);
                ComprasPSelect.Kilos = reader.GetDouble(18);
                ComprasPSelect.Litros = reader.GetDouble(19);
            }
            connec.Close();
            return pMs;
        }

        public static class ComprasPSelect
        {
            public static int IdCompra { get; set; }
            public static DateTime Fecha { get; set; }
            public static int NoPipa { get; set; }
            public static double Proveedor { get; set; }
            public static double Rancho { get; set; }
            public static double NoRemision { get; set; }
            public static DateTime FechaLlegada { get; set; }
            public static double Placas { get; set; }
            public static double Analista { get; set; }
            public static double Sello1 { get; set; }
            public static double Sello2 { get; set; }
            public static double TipoProducto { get; set; }
            public static double Densidad { get; set; }
            public static double Grasa { get; set; }
            public static double SNG { get; set; }
            public static string ST { get; set; }
            public static double Crioscopia { get; set; }
            public static double Proteina { get; set; }
            public static double Kilos { get; set; }
            public static double Litros { get; set; }
        }
    }
}
