using MySql.Data.MySqlClient;
using System;
using OfficeOpenXml;
using System.IO;
using System.Collections.Generic;

namespace ProyectoNutrical.Models
{
    class ModelSecadorHorizontal
    {
        public ModelSecadorHorizontal()
        {
        }

        public ModelSecadorHorizontal(int pIdLinea, string pCircuito, string pFecha, string pMuestra, string pMInicial,
            string pMFinal, string pMEnjuague, string pTAInicial,
            string pTAFinal, string pTAEnjuague, string pTTA, string pTipoLavado, string pTLInicial, string pTLFinal,
            string pTLEnjuague, string pTTLavado, string pColor1, string pColor2,
            string pTitulacion, string pRT1, string pRT2, string pOperador, string pAnalista)
        {
            IdLinea = pIdLinea;
            Circuito = pCircuito;
            Fecha = pFecha;
            Muestra = pMuestra;
            MInicial = pMInicial;
            MFinal = pMFinal;
            MEnjuague = pMEnjuague;
            TAInicial = pTAInicial;
            TAFinal = pTAFinal;
            TAEnjuague = pTAEnjuague;
            TTA = pTTA;
            TipoLavado = pTipoLavado;
            TLInicial = pTLInicial;
            TLFinal = pTLFinal;
            TLEnjuague = pTLEnjuague;
            TTLavado = pTTLavado;
            Color1 = pColor1;
            Color2 = pColor2;
            Titulacion = pTitulacion;
            RT1 = pRT1;
            RT2 = pRT2;
            Operador = pOperador;
            Analista = pAnalista;
        }

        public int IdLinea { get; set; }
        public string Circuito { get; set; }
        public string Fecha { get; set; }
        public string Muestra { get; set; }
        public string MInicial { get; set; }
        public string MFinal { get; set; }
        public string MEnjuague { get; set; }
        public string TAInicial { get; set; }
        public string TAFinal { get; set; }
        public string TAEnjuague { get; set; }
        public string TTA { get; set; }
        public string TipoLavado { get; set; }
        public string TLInicial { get; set; }
        public string TLFinal { get; set; }
        public string TLEnjuague { get; set; }
        public string TTLavado { get; set; }
        public string Color1 { get; set; }
        public string Color2 { get; set; }
        public string Titulacion { get; set; }
        public string RT1 { get; set; }
        public string RT2 { get; set; }
        public string Operador { get; set; }
        public string Analista { get; set; }

        internal static int Eliminar(int idLinea1, int idLinea2)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     metodo para mostrar los tipolavado y titulacion los combobox
        /// </summary>
        public static List<ModelSecadorHorizontal> Llenarcombo()
        {
            var lista = new List<ModelSecadorHorizontal>();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM secadorhorizontal", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var pSH = new ModelSecadorHorizontal
                {
                    IdLinea = reader.GetInt32(0),
                    TipoLavado = reader.GetString(1),
                    Titulacion = reader.GetString(2)
                };
                lista.Add(pSH);
            }
            return lista;
        }

        public static List<ModelSecadorHorizontal> Llenargrid()
        {
            var lista = new List<ModelSecadorHorizontal>();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM secadorhorizontal", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var pModelSecadorHorizontal = new ModelSecadorHorizontal
                {
                    IdLinea = reader.GetInt32(0),
                    Circuito = reader.GetString(1),
                    Fecha = reader.GetString(2),
                    Muestra = reader.GetString(3),
                    MInicial = reader.GetString(4),
                    MFinal = reader.GetString(5),
                    MEnjuague = reader.GetString(6),
                    TAInicial = reader.GetString(7),
                    TAFinal = reader.GetString(8),
                    TAEnjuague = reader.GetString(9),
                    TTA = reader.GetString(10),
                    TipoLavado = reader.GetString(11),
                    TLInicial = reader.GetString(12),
                    TLFinal = reader.GetString(13),
                    TLEnjuague = reader.GetString(14),
                    TTLavado = reader.GetString(15),
                    Color1 = reader.GetString(16),
                    Color2 = reader.GetString(17),
                    Titulacion = reader.GetString(18),
                    RT1 = reader.GetString(19),
                    RT2 = reader.GetString(20),
                    Operador = reader.GetString(21),
                    Analista = reader.GetString(22)
                };
                lista.Add(pModelSecadorHorizontal);
            }
            return lista;
        }


        /// <summary>
        ///     metodo para agregar
        /// </summary>
        public static int Agregar(ModelSecadorHorizontal pMsh)
        {
            var connec = ConexionMySql.ObtenerConexion();
            var comando =
                new MySqlCommand(
                    $"CALL spInsertSecadorHorizontal('{pMsh.IdLinea}','{pMsh.Circuito}','{pMsh.Fecha}','{pMsh.Muestra}','{pMsh.MInicial}','{pMsh.MFinal}','{pMsh.MEnjuague}','{pMsh.TAInicial}','{pMsh.TAFinal}','{pMsh.TAEnjuague}','{pMsh.TTA}','{pMsh.TipoLavado}','{pMsh.TLInicial}','{pMsh.TLFinal}','{pMsh.TLEnjuague}','{pMsh.TTLavado}','{pMsh.Color1}','{pMsh.Color2}','{pMsh.Titulacion}','{pMsh.RT1}','{pMsh.RT2}','{pMsh.Operador}','{pMsh.Analista}')",
                    connec);
            var retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        /// <summary>
        ///     metodo buscar
        /// </summary>
        public static List<ModelSecadorHorizontal> Buscar(string pFecha, string pTipoLavado, string pTitulacion)
        {
            var lista = new List<ModelSecadorHorizontal>();
            var connec = ConexionMySql.ObtenerConexion();
            var comando =
                new MySqlCommand(
                    $"SELECT * FROM viewsecadorhorizontal WHERE Fecha='{pFecha}' OR TipoLavado='{pTipoLavado}' OR Titulacion='{pTitulacion}'",
                    connec);
            var reader = comando.ExecuteReader();
            var pSH = new ModelSecadorHorizontal
            {
                IdLinea = reader.GetInt32(0),
                Circuito = reader.GetString(1),
                Fecha = reader.GetString(2),
                Muestra = reader.GetString(3),
                MInicial = reader.GetString(4),
                MFinal = reader.GetString(5),
                MEnjuague = reader.GetString(6),
                TAInicial = reader.GetString(7),
                TAFinal = reader.GetString(8),
                TAEnjuague = reader.GetString(9),
                TTA = reader.GetString(10),
                TipoLavado = reader.GetString(11),
                TLInicial = reader.GetString(12),
                TLFinal = reader.GetString(13),
                TLEnjuague = reader.GetString(14),
                TTLavado = reader.GetString(15),
                Color1 = reader.GetString(16),
                Color2 = reader.GetString(17),
                Titulacion = reader.GetString(18),
                RT1 = reader.GetString(19),
                RT2 = reader.GetString(20),
                Operador = reader.GetString(21),
                Analista = reader.GetString(22)
            };
            while (reader.Read())
                lista.Add(pSH);
            return lista;
        }

        internal static int Actualizar(ModelSecadorHorizontal pSH)
        {
            throw new NotImplementedException();
        }

        public static ModelSecadorHorizontal ObtenerSH(int pIdSecadorHorizontal)
        {
            var pMsh = new ModelSecadorHorizontal();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"SELECT * FROM secadorhorizontal WHERE ID ='{pIdSecadorHorizontal}'", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                SHorizontalSelect.IdLinea = reader.GetInt32(0);
                SHorizontalSelect.Circuito = reader.GetString(1);
                SHorizontalSelect.Fecha = reader.GetString(2);
                SHorizontalSelect.Muestra = reader.GetString(3);
                SHorizontalSelect.MInicial = reader.GetString(4);
                SHorizontalSelect.MFinal = reader.GetString(5);
                SHorizontalSelect.MEnjuague = reader.GetString(6);
                SHorizontalSelect.TAInicial = reader.GetString(7);
                SHorizontalSelect.TAEnjuague = reader.GetString(9);
                SHorizontalSelect.TTA = reader.GetString(10);
                SHorizontalSelect.TipoLavado = reader.GetString(11);
                SHorizontalSelect.TLInicial = reader.GetString(12);
                SHorizontalSelect.TLEnjuague = reader.GetString(14);
                SHorizontalSelect.TTLavado = reader.GetString(15);
                SHorizontalSelect.Color1 = reader.GetString(16);
                SHorizontalSelect.Color2 = reader.GetString(17);
                SHorizontalSelect.Titulacion = reader.GetString(18);
                SHorizontalSelect.RT1 = reader.GetString(19);
                SHorizontalSelect.RT2 = reader.GetString(20);
                SHorizontalSelect.Operador = reader.GetString(21);
                SHorizontalSelect.Analista = reader.GetString(22);
            }
            connec.Close();
            return pMsh;
        }


        /// <summary>
        ///     metodo para actualizar
        /// </summary>
        public static int Actualizar(ModelSecadorHorizontal pSHorizontal, int pSH)
        {
            var retorno = 0;
            var conexion = ConexionMySql.ObtenerConexion();
            MySqlCommand comando;

            switch (pSH)
            {
                case 1: //actualizar los datos de Recepcion
                    comando = new MySqlCommand(
                        $"CALL ActualizarSecadorHorizontal('{pSH}','{pSHorizontal.IdLinea}','{pSHorizontal.Circuito}','{pSHorizontal.Muestra}','{pSHorizontal.MInicial}','{pSHorizontal.MFinal}','{pSHorizontal.MEnjuague}','{pSHorizontal.TAInicial}','{pSHorizontal.TAFinal}','{pSHorizontal.TAEnjuague}','{pSHorizontal.TTA}','{pSHorizontal.TipoLavado}','{pSHorizontal.TLInicial}','{pSHorizontal.TLFinal}','{pSHorizontal.TLEnjuague}','{pSHorizontal.TTLavado}','{pSHorizontal.Color1}','{pSHorizontal.Color2}','{pSHorizontal.Titulacion}','{pSHorizontal.RT1}','{pSHorizontal.RT2}','{pSHorizontal.Operador}','{pSHorizontal.Analista}','a','a')",
                        conexion);
                    retorno = comando.ExecuteNonQuery();
                    break;
            }
            return retorno;
        }

        /// <summary>
        ///     metodo para eliminar
        /// </summary>
        public static int Eliminar(int pIdMsh)
        {
            var conexion = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"DELETE FROM secadorhorizontal WHERE ID = '{pIdMsh}'", conexion);
            var retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }

        public static class SHorizontalSelect
        {
            public static int IdLinea { get; set; }
            public static string Circuito { get; set; }
            public static string Fecha { get; set; }
            public static string Muestra { get; set; }
            public static string MInicial { get; set; }
            public static string MFinal { get; set; }
            public static string MEnjuague { get; set; }
            public static string TAInicial { get; set; }
            public static string TAFinal { get; set; }
            public static string TAEnjuague { get; set; }
            public static string TTA { get; set; }
            public static string TipoLavado { get; set; }
            public static string TLInicial { get; set; }
            public static string TLFinal { get; set; }
            public static string TLEnjuague { get; set; }
            public static string TTLavado { get; set; }
            public static string Color1 { get; set; }
            public static string Color2 { get; set; }
            public static string Titulacion { get; set; }
            public static string RT1 { get; set; }
            public static string RT2 { get; set; }
            public static string Operador { get; set; }
            public static string Analista { get; set; }
        }
        public static void DisplayInExcel()
        {
            var datename = "SecadorHorizontal" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + ".xlsx";
            var path = @"C:\\Users\\Diego Maciel Acevedo\\Desktop\\ExcelSecadorHorizontal\\";

            if (!Directory.Exists(path)) //comprueba que exista la carpeta si no la crea
                Directory.CreateDirectory(path);

            path += datename; //se agrega el nombre del archivo para comprobar si existe y para crear el arhivo.

            if (File.Exists(path)) //comprueba si existe el archivo si si lo elimina.
                File.Delete(path);

            var spreadsheetinfo = new FileInfo(path);
            var pck = new ExcelPackage(spreadsheetinfo);
            var spreadSheet = pck.Workbook.Worksheets.Add("SECADORHORIZONTAL");

            spreadSheet.Cells["A1"].Value = "Circuito";
            spreadSheet.Cells["B1"].Value = "Fecha";
            spreadSheet.Cells["C1"].Value = "Muestra";
            spreadSheet.Cells["D1"].Value = "MInicial";
            spreadSheet.Cells["E1"].Value = "MFinal";
            spreadSheet.Cells["F1"].Value = "MEnjuague";
            spreadSheet.Cells["G1"].Value = "TAInicial";
            spreadSheet.Cells["H1"].Value = "TAFinal";
            spreadSheet.Cells["I1"].Value = "TAEnjuague";
            spreadSheet.Cells["J1"].Value = "TTAnalisis";
            spreadSheet.Cells["K1"].Value = "TipoLavado";
            spreadSheet.Cells["L1"].Value = "TInicial";
            spreadSheet.Cells["M1"].Value = "TFinal";
            spreadSheet.Cells["N1"].Value = "TEnjuague";
            spreadSheet.Cells["O1"].Value = "TTLavado";
            spreadSheet.Cells["P1"].Value = "Color";
            spreadSheet.Cells["Q1"].Value = "Color2";
            spreadSheet.Cells["R1"].Value = "Titulacion";
            spreadSheet.Cells["S1"].Value = "RT1";
            spreadSheet.Cells["T1"].Value = "RT2";
            spreadSheet.Cells["U1"].Value = "Operador";
            spreadSheet.Cells["V1"].Value = "Analista";
            spreadSheet.Cells["A1:V1"].Style.Font.Bold = true;


            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM secadorhorizontal", connec);
            var reader = comando.ExecuteReader();
            var currentRow = 2;
            while (reader.Read())
            {
                spreadSheet.Cells["A" + currentRow].Value = reader.GetString(1);
                spreadSheet.Cells["B" + currentRow].Value = reader.GetInt32(2);
                spreadSheet.Cells["C" + currentRow].Value = reader.GetDouble(3);
                spreadSheet.Cells["D" + currentRow].Value = reader.GetDouble(4);
                spreadSheet.Cells["E" + currentRow].Value = reader.GetDouble(5);
                spreadSheet.Cells["F" + currentRow].Value = reader.GetDouble(6);
                spreadSheet.Cells["G" + currentRow].Value = reader.GetDouble(7);
                spreadSheet.Cells["H" + currentRow].Value = reader.GetDouble(8);
                spreadSheet.Cells["I" + currentRow].Value = reader.GetDouble(9);
                spreadSheet.Cells["J" + currentRow].Value = reader.GetDouble(10);
                spreadSheet.Cells["K" + currentRow].Value = reader.GetDouble(11);
                spreadSheet.Cells["L" + currentRow].Value = reader.GetDouble(12);
                spreadSheet.Cells["M" + currentRow].Value = reader.GetDouble(13);
                spreadSheet.Cells["N" + currentRow].Value = reader.GetDouble(14);
                spreadSheet.Cells["O" + currentRow].Value = reader.GetString(15);
                spreadSheet.Cells["P" + currentRow].Value = reader.GetDouble(16);
                spreadSheet.Cells["Q" + currentRow].Value = reader.GetDouble(17);
                spreadSheet.Cells["R" + currentRow].Value = reader.GetDouble(18);
                spreadSheet.Cells["S" + currentRow].Value = reader.GetDouble(19);
                spreadSheet.Cells["T" + currentRow].Value = reader.GetDouble(20);
                spreadSheet.Cells["U" + currentRow].Value = reader.GetDouble(21);
                spreadSheet.Cells["V" + currentRow].Value = reader.GetDouble(22);
                currentRow++;
            }

            pck.SaveAs(spreadsheetinfo);
        }
    }
}
