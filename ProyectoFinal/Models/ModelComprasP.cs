using MySql.Data.MySqlClient;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProyectoNutrical.Models
{
    class ModelComprasP
    {
        public ModelComprasP() { }

        public ModelComprasP(int pIdCompra, string pFecha, string pNoPipa, string pProveedor, string pRancho, string pNoRemision, string pFechaLlegada, string pPlacas, string pAnalista, string pSello1, string pSello2, string pTipoProducto, double pDensidad, double pGrasa, double pSNG, double pST, double pCrioscopia, double pProteina, double pKilos, double pLitros)
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
        public string Fecha { get; set; }
        public string NoPipa { get; set; }
        public string Proveedor { get; set; }
        public string Rancho { get; set; }
        public string NoRemision { get; set; }
        public string FechaLlegada { get; set; }
        public string Placas { get; set; }
        public string Analista { get; set; }
        public string Sello1 { get; set; }
        public string Sello2 { get; set; }
        public string TipoProducto { get; set; }
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
                    Fecha = reader.GetString(1),
                    NoPipa = reader.GetString(2),
                    Proveedor = reader.GetString(3),
                    Rancho = reader.GetString(4),
                    NoRemision = reader.GetString(5),
                    FechaLlegada = reader.GetString(6),
                    Placas = reader.GetString(7),
                    Analista = reader.GetString(8),
                    Sello1 = reader.GetString(9),
                    Sello2 = reader.GetString(10),
                    TipoProducto = reader.GetString(11),
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
            var comando = new MySqlCommand($"INSERT INTO compras (Fecha, NoPipa, Proveedor, Rancho, NoRemision, FechaLlegada, Placas, Analista, Sello1, Sello2, TipoProducto, Densidad, Grasa, SNG, ST, Crioscopia, Proteina, Kilos, Litros) VALUES('{pMcp.Fecha}','{pMcp.NoPipa}','{pMcp.Proveedor}','{pMcp.Rancho}','{pMcp.NoRemision}','{pMcp.FechaLlegada}','{pMcp.Placas}','{pMcp.Analista}','{pMcp.Sello1}','{pMcp.Sello2}','{pMcp.TipoProducto}','{pMcp.Densidad}','{pMcp.Grasa}','{pMcp.SNG}','{pMcp.ST}','{pMcp.Crioscopia}','{pMcp.Proteina}','{pMcp.Kilos}','{pMcp.Litros}')", connec);
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

        public static List<ModelComprasP> Buscar(string pRancho, string pProducto, string pRemision)
        {
            List<ModelComprasP> _lista = new List<ModelComprasP>();
            MySqlCommand _comando = new MySqlCommand(string.Format($"SELECT * FROM compras WHERE  Rancho = '{pRancho}' OR TipoProducto = '{pProducto}'  OR NoRemision='{pRemision}'"), ConexionMySql.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                ModelComprasP pComprasP = new ModelComprasP
                {
                    IdCompra = _reader.GetInt32(0),
                    Fecha = _reader.GetString(1),
                    NoPipa = _reader.GetString(2),
                    Proveedor = _reader.GetString(3),
                    Rancho = _reader.GetString(4),
                    NoRemision = _reader.GetString(5),
                    FechaLlegada = _reader.GetString(6),
                    Placas = _reader.GetString(7),
                    Analista = _reader.GetString(8),
                    Sello1 = _reader.GetString(9),
                    Sello2 = _reader.GetString(10),
                    TipoProducto = _reader.GetString(11),
                    Densidad = _reader.GetDouble(12),
                    Grasa = _reader.GetDouble(13),
                    SNG = _reader.GetDouble(14),
                    ST = _reader.GetDouble(15),
                    Crioscopia = _reader.GetDouble(16),
                    Proteina = _reader.GetDouble(17),
                    Kilos = _reader.GetDouble(18),
                    Litros = _reader.GetDouble(19)
                };
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
            var comando = new MySqlCommand($"SELECT * FROM compras WHERE IDCompra ='{pIdCompraP}'", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                ComprasPSelect.IdCompra = reader.GetInt32(0);
                ComprasPSelect.Fecha = reader.GetString(1);
                ComprasPSelect.NoPipa = reader.GetString(2);
                ComprasPSelect.Proveedor = reader.GetString(3);
                ComprasPSelect.Rancho = reader.GetString(4);
                ComprasPSelect.NoRemision = reader.GetString(5);
                ComprasPSelect.FechaLlegada = reader.GetString(6);
                ComprasPSelect.Placas = reader.GetString(7);
                ComprasPSelect.Analista = reader.GetString(8);
                ComprasPSelect.Sello1 = reader.GetString(9);
                ComprasPSelect.Sello2 = reader.GetString(10);
                ComprasPSelect.TipoProducto = reader.GetString(11);
                ComprasPSelect.Densidad = reader.GetDouble(12);
                ComprasPSelect.Grasa = reader.GetDouble(13);
                ComprasPSelect.SNG = reader.GetDouble(14);
                ComprasPSelect.ST = reader.GetDouble(15);
                ComprasPSelect.Crioscopia = reader.GetDouble(16);
                ComprasPSelect.Proteina = reader.GetDouble(17);
                ComprasPSelect.Kilos = reader.GetDouble(18);
                ComprasPSelect.Litros = reader.GetDouble(19);
            }
            connec.Close();
            return pMs;
        }

        //metodo para actualizar
        public static int Actualizar(ModelComprasP pMcp)
        {
            var conexion = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"UPDATE compras SET Fecha = '{pMcp.Fecha}', NoPipa = '{pMcp.NoPipa}', Proveedor = '{pMcp.Proveedor}', Rancho = '{pMcp.Rancho}', NoRemision = '{pMcp.NoRemision}', FechaLlegada = '{pMcp.FechaLlegada}', Placas = '{pMcp.Placas}',  Analista = '{pMcp.Analista}', Sello1 = '{pMcp.Sello1}', Sello2 = '{pMcp.Sello2}',  TipoProducto = '{pMcp.TipoProducto}', Densidad = '{pMcp.Densidad}', Grasa = '{pMcp.Grasa}', SNG = '{pMcp.SNG}', ST = '{pMcp.ST}', Crioscopia = '{pMcp.Crioscopia}', Proteina = '{pMcp.Proteina}', Kilos = '{pMcp.Kilos}', Litros = '{pMcp.Litros}' WHERE IDCompra = '{pMcp.IdCompra}'", conexion);
            var retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }

        public static class ComprasPSelect
        {
            public static int IdCompra { get; set; }
            public static string Fecha { get; set; }
            public static string NoPipa { get; set; }
            public static string Proveedor { get; set; }
            public static string Rancho { get; set; }
            public static string NoRemision { get; set; }
            public static string FechaLlegada { get; set; }
            public static string Placas { get; set; }
            public static string Analista { get; set; }
            public static string Sello1 { get; set; }
            public static string Sello2 { get; set; }
            public static string TipoProducto { get; set; }
            public static double Densidad { get; set; }
            public static double Grasa { get; set; }
            public static double SNG { get; set; }
            public static double ST { get; set; }
            public static double Crioscopia { get; set; }
            public static double Proteina { get; set; }
            public static double Kilos { get; set; }
            public static double Litros { get; set; }
        }


        public static void DisplayInExcell()
        {
            var datename = "Compras" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + ".xlsx";
            var path = @"C:\\Users\\Diego Maciel Acevedo\\Desktop\\ExcelCompra\\";

            if (!Directory.Exists(path)) //comprueba que exista la carpeta si no la crea
                Directory.CreateDirectory(path);

            path += datename; //se agrega el nombre del archivo para comprobar si existe y para crear el arhivo.

            if (File.Exists(path)) //comprueba si existe el archivo si exste lo elimina.
                File.Delete(path);

            var spreadsheetinfo = new FileInfo(path);
            var pck = new ExcelPackage(spreadsheetinfo);
            var spreadSheet = pck.Workbook.Worksheets.Add("compras");

            spreadSheet.Cells["A1"].Value = "IDCompra";
            spreadSheet.Cells["B1"].Value = "Fecha";
            spreadSheet.Cells["C1"].Value = "NoPipa";
            spreadSheet.Cells["D1"].Value = "Proveedor";
            spreadSheet.Cells["E1"].Value = "Rancho";
            spreadSheet.Cells["F1"].Value = "NoRemision";
            spreadSheet.Cells["G1"].Value = "FechaLlegada";
            spreadSheet.Cells["H1"].Value = "Placas";
            spreadSheet.Cells["I1"].Value = "Analista";
            spreadSheet.Cells["J1"].Value = "Sello1";
            spreadSheet.Cells["K1"].Value = "Sello2";
            spreadSheet.Cells["L1"].Value = "TipoProducto";
            spreadSheet.Cells["M1"].Value = "Densidad";
            spreadSheet.Cells["N1"].Value = "Grasa";
            spreadSheet.Cells["O1"].Value = "SNG";
            spreadSheet.Cells["P1"].Value = "ST";
            spreadSheet.Cells["Q1"].Value = "Crioscopia";
            spreadSheet.Cells["R1"].Value = "Proteina";
            spreadSheet.Cells["S1"].Value = "Kilos";
            spreadSheet.Cells["T1"].Value = "Litros";
            spreadSheet.Cells["A1:T1"].Style.Font.Bold = true;

            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM compras", connec);
            var reader = comando.ExecuteReader();
            var currentRow = 2;
            while (reader.Read())
            {
                spreadSheet.Cells["A" + currentRow].Value = reader.GetInt32(0);
                spreadSheet.Cells["B" + currentRow].Value = reader.GetString(1);
                spreadSheet.Cells["C" + currentRow].Value = reader.GetString(2);
                spreadSheet.Cells["D" + currentRow].Value = reader.GetString(3);
                spreadSheet.Cells["E" + currentRow].Value = reader.GetString(4);
                spreadSheet.Cells["F" + currentRow].Value = reader.GetString(5);
                spreadSheet.Cells["G" + currentRow].Value = reader.GetString(6);
                spreadSheet.Cells["H" + currentRow].Value = reader.GetString(7);
                spreadSheet.Cells["I" + currentRow].Value = reader.GetString(8);
                spreadSheet.Cells["J" + currentRow].Value = reader.GetString(9);
                spreadSheet.Cells["K" + currentRow].Value = reader.GetString(10);
                spreadSheet.Cells["L" + currentRow].Value = reader.GetString(11);
                spreadSheet.Cells["M" + currentRow].Value = reader.GetDouble(12);
                spreadSheet.Cells["N" + currentRow].Value = reader.GetDouble(13);
                spreadSheet.Cells["O" + currentRow].Value = reader.GetDouble(14);
                spreadSheet.Cells["P" + currentRow].Value = reader.GetDouble(15);
                spreadSheet.Cells["Q" + currentRow].Value = reader.GetDouble(16);
                spreadSheet.Cells["R" + currentRow].Value = reader.GetDouble(17);
                spreadSheet.Cells["S" + currentRow].Value = reader.GetDouble(18);
                spreadSheet.Cells["T" + currentRow].Value = reader.GetDouble(19);
                currentRow++;
            }

            pck.SaveAs(spreadsheetinfo);
        }

    }
}
