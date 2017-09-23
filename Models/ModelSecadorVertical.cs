using MySql.Data.MySqlClient;
using System;
using OfficeOpenXml;
using System.IO;
using System.Collections.Generic;


namespace ProyectoNutrical.Models
{
    class ModelSecadorVertical
    {
        public ModelSecadorVertical()
        {
        }

        public ModelSecadorVertical(int pIdLinea, string pCircuito, string pFecha, string pMInicial,
            string pMFinal, string pMEnjuague, string pTAInicial,
            string pTAFinal, string pTAEnjuague, string pTTA, string pTipoLavado, string pTLInicial, string pTLFinal,
            string pTLEnjuague, string pTTLavado, string pColor1, string pColor2,
            string pTitulacion, string pRT1, string pRT2, string pOperador, string pAnalista)
        {
            IdLinea = pIdLinea;
            Circuito = pCircuito;
            Fecha = pFecha;
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


        /// <summary>
        ///     metodo para mostrar los tipolavado y titulacion los combobox
        /// </summary>
        public static List<ModelSecadorVertical> Llenarcombo()
        {
            var lista = new List<ModelSecadorVertical>();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM secadorvertical", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var pSV = new ModelSecadorVertical
                {
                    IdLinea = reader.GetInt32(0),
                    TipoLavado = reader.GetString(1),
                    Titulacion = reader.GetString(2)
                };
                lista.Add(pSV);
            }
            return lista;
        }

        public static List<ModelSecadorVertical> Llenargrid()
        {
            var lista = new List<ModelSecadorVertical>();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM secadorvertical", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var pModelSecadorVertical = new ModelSecadorVertical
                {
                    IdLinea = reader.GetInt32(0),
                    Circuito = reader.GetString(1),
                    Fecha = reader.GetString(2),
                    MInicial = reader.GetString(3),
                    MFinal = reader.GetString(4),
                    MEnjuague = reader.GetString(5),
                    TAInicial = reader.GetString(6),
                    TAFinal = reader.GetString(7),
                    TAEnjuague = reader.GetString(8),
                    TTA = reader.GetString(9),
                    TipoLavado = reader.GetString(10),
                    TLInicial = reader.GetString(11),
                    TLFinal = reader.GetString(12),
                    TLEnjuague = reader.GetString(13),
                    TTLavado = reader.GetString(14),
                    Color1 = reader.GetString(15),
                    Color2 = reader.GetString(16),
                    Titulacion = reader.GetString(17),
                    RT1 = reader.GetString(18),
                    RT2 = reader.GetString(19),
                    Operador = reader.GetString(20),
                    Analista = reader.GetString(21)
                };
                lista.Add(pModelSecadorVertical);
            }
            return lista;
        }
        public static ModelSecadorHorizontal ObtenerSV(int IdLinea)
        {
            var pMsh = new ModelSecadorHorizontal();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"SELECT * FROM secadorvertical WHERE IDLinea ='{IdLinea}'", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                SVerticalSelect.IdLinea = reader.GetInt32(0);
                SVerticalSelect.Circuito = reader.GetString(1);
                SVerticalSelect.Fecha = reader.GetString(2);
                SVerticalSelect.MInicial = reader.GetString(3);
                SVerticalSelect.MFinal = reader.GetString(4);
                SVerticalSelect.MEnjuague = reader.GetString(5);
                SVerticalSelect.TAInicial = reader.GetString(6);
                SVerticalSelect.TAFinal = reader.GetString(7);
                SVerticalSelect.TAEnjuague = reader.GetString(8);
                SVerticalSelect.TTA = reader.GetString(9);
                SVerticalSelect.TipoLavado = reader.GetString(10);
                SVerticalSelect.TLInicial = reader.GetString(11);
                SVerticalSelect.TLFinal = reader.GetString(12);
                SVerticalSelect.TLEnjuague = reader.GetString(13);
                SVerticalSelect.TTLavado = reader.GetString(14);
                SVerticalSelect.Color1 = reader.GetString(15);
                SVerticalSelect.Color2 = reader.GetString(16);
                SVerticalSelect.Titulacion = reader.GetString(17);
                SVerticalSelect.RT1 = reader.GetString(18);
                SVerticalSelect.RT2 = reader.GetString(19);
                SVerticalSelect.Operador = reader.GetString(20);
                SVerticalSelect.Analista = reader.GetString(21);
            }
            connec.Close();
            return pMsh;
        }

        /// <summary>
        ///     metodo para agregar
        /// </summary>
        public static int Agregar(ModelSecadorVertical pMsv)
        {
            var connec = ConexionMySql.ObtenerConexion();
            var comando =
                new MySqlCommand(
                    $"CALL sp_SecadorVertical('{pMsv.IdLinea}','{pMsv.Circuito}','{pMsv.Fecha}','{pMsv.MInicial}','{pMsv.MFinal}','{pMsv.MEnjuague}','{pMsv.TAInicial}','{pMsv.TAFinal}','{pMsv.TAEnjuague}','{pMsv.TTA}','{pMsv.TipoLavado}','{pMsv.TLInicial}','{pMsv.TLFinal}','{pMsv.TLEnjuague}','{pMsv.TTLavado}','{pMsv.Color1}','{pMsv.Color2}','{pMsv.Titulacion}','{pMsv.RT1}','{pMsv.RT2}','{pMsv.Operador}','{pMsv.Analista}')",
                    connec);
            var retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static List<ModelSecadorVertical> Buscar(string pFecha)
        {
            var lista = new List<ModelSecadorVertical>();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"SELECT * FROM secadorvertical WHERE Fecha>'{pFecha}'", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var pSV = new ModelSecadorVertical
                {
                    IdLinea = reader.GetInt32(0),
                    Circuito = reader.GetString(1),
                    Fecha = reader.GetString(2),
                    MInicial = reader.GetString(3),
                    MFinal = reader.GetString(4),
                    MEnjuague = reader.GetString(5),
                    TAInicial = reader.GetString(6),
                    TAFinal = reader.GetString(7),
                    TAEnjuague = reader.GetString(8),
                    TTA = reader.GetString(9),
                    TipoLavado = reader.GetString(10),
                    TLInicial = reader.GetString(11),
                    TLFinal = reader.GetString(12),
                    TLEnjuague = reader.GetString(13),
                    TTLavado = reader.GetString(14),
                    Color1 = reader.GetString(15),
                    Color2 = reader.GetString(16),
                    Titulacion = reader.GetString(17),
                    RT1 = reader.GetString(18),
                    RT2 = reader.GetString(19),
                    Operador = reader.GetString(20),
                    Analista = reader.GetString(21)
                };
                lista.Add(pSV);
            }
            return lista;
        }

        /// <summary>
        ///     metodo para actualizar
        /// </summary>
        public static int Actualizar(ModelSecadorVertical pSV)
        {
            var retorno = 0;
            var conexion = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"UPDATE secadorvertical SET Circuito='{pSV.Circuito}', Fecha='{pSV.Fecha}', MInicial='{pSV.MInicial}', MFinal='{pSV.MFinal}', MEnjuague='{pSV.MEnjuague}', TAInicial='{pSV.TAInicial}', TAFinal='{pSV.TAFinal}', TAEnjuague='{pSV.TAEnjuague}', TTAnalisis='{pSV.TTA}', TipoLavado='{pSV.TipoLavado}', TLInicial='{pSV.TLInicial}', TLFinal='{pSV.TLFinal}', TLEnjuague='{pSV.TLEnjuague}', TTLavado='{pSV.TTLavado}', Color1='{pSV.Color1}', Color2='{pSV.Color2}', Titulacion='{pSV.Titulacion}', RT1='{pSV.RT1}', RT2='{pSV.RT2}', Operador='{pSV.Operador}', Analista='{pSV.Analista}' WHERE IDLinea='{pSV.IdLinea}'", conexion);
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        /// <summary>
        ///     metodo para eliminar
        /// </summary>
        public static int Eliminar(int IdLinea)
        {
            var conexion = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"CALL eliminar_SecadorV('{IdLinea}'", conexion);
            var retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }

        public static class SVerticalSelect
        {
            public static int IdLinea { get; set; }
            public static string Circuito { get; set; }
            public static string Fecha { get; set; }
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
            var datename = "SecadorVertical" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + ".xlsx";
            var path = @"C:\\Users\\Diego Maciel Acevedo\\Desktop\\ExcelSecadorVertical\\";

            if (!Directory.Exists(path)) //comprueba que exista la carpeta si no la crea
                Directory.CreateDirectory(path);

            path += datename; //se agrega el nombre del archivo para comprobar si existe y para crear el arhivo.

            if (File.Exists(path)) //comprueba si existe el archivo si si lo elimina.
                File.Delete(path);

            var spreadsheetinfo = new FileInfo(path);
            var pck = new ExcelPackage(spreadsheetinfo);
            var spreadSheet = pck.Workbook.Worksheets.Add("SECADORVERTICAL");

            spreadSheet.Cells["A1"].Value = "Circuito";
            spreadSheet.Cells["B1"].Value = "Fecha";
            spreadSheet.Cells["C1"].Value = "MInicial";
            spreadSheet.Cells["D1"].Value = "MFinal";
            spreadSheet.Cells["E1"].Value = "MEnjuague";
            spreadSheet.Cells["F1"].Value = "TAInicial";
            spreadSheet.Cells["G1"].Value = "TAFinal";
            spreadSheet.Cells["H1"].Value = "TAEnjuague";
            spreadSheet.Cells["I1"].Value = "TTAnalisis";
            spreadSheet.Cells["J1"].Value = "TipoLavado";
            spreadSheet.Cells["K1"].Value = "TInicial";
            spreadSheet.Cells["L1"].Value = "TFinal";
            spreadSheet.Cells["M1"].Value = "TEnjuague";
            spreadSheet.Cells["N1"].Value = "TTLavado";
            spreadSheet.Cells["O1"].Value = "Color";
            spreadSheet.Cells["P1"].Value = "Color2";
            spreadSheet.Cells["Q1"].Value = "Titulacion";
            spreadSheet.Cells["R1"].Value = "RT1";
            spreadSheet.Cells["S1"].Value = "RT2";
            spreadSheet.Cells["T1"].Value = "Operador";
            spreadSheet.Cells["U1"].Value = "Analista";
            spreadSheet.Cells["A1:U1"].Style.Font.Bold = true;


            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM secadorvertical", connec);
            var reader = comando.ExecuteReader();
            var currentRow = 2;
            while (reader.Read())
            {
                spreadSheet.Cells["A" + currentRow].Value = reader.GetString(1);
                spreadSheet.Cells["B" + currentRow].Value = reader.GetString(2);
                spreadSheet.Cells["C" + currentRow].Value = reader.GetString(3);
                spreadSheet.Cells["D" + currentRow].Value = reader.GetString(4);
                spreadSheet.Cells["E" + currentRow].Value = reader.GetString(5);
                spreadSheet.Cells["F" + currentRow].Value = reader.GetString(6);
                spreadSheet.Cells["G" + currentRow].Value = reader.GetString(7);
                spreadSheet.Cells["H" + currentRow].Value = reader.GetString(8);
                spreadSheet.Cells["I" + currentRow].Value = reader.GetString(9);
                spreadSheet.Cells["J" + currentRow].Value = reader.GetString(10);
                spreadSheet.Cells["K" + currentRow].Value = reader.GetString(11);
                spreadSheet.Cells["L" + currentRow].Value = reader.GetString(12);
                spreadSheet.Cells["M" + currentRow].Value = reader.GetString(13);
                spreadSheet.Cells["N" + currentRow].Value = reader.GetString(14);
                spreadSheet.Cells["O" + currentRow].Value = reader.GetString(15);
                spreadSheet.Cells["P" + currentRow].Value = reader.GetString(16);
                spreadSheet.Cells["Q" + currentRow].Value = reader.GetString(17);
                spreadSheet.Cells["R" + currentRow].Value = reader.GetString(18);
                spreadSheet.Cells["S" + currentRow].Value = reader.GetString(19);
                spreadSheet.Cells["T" + currentRow].Value = reader.GetString(20);
                spreadSheet.Cells["U" + currentRow].Value = reader.GetString(21);
                currentRow++;
            }

            pck.SaveAs(spreadsheetinfo);
        }
        public static void DisplayInExcelMuestras()
        {
            var datename = "Muestras" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + ".xlsx";
            var path = @"C:\\Users\\Diego Maciel Acevedo\\Desktop\\ExcelSecadorVertical\\";

            if (!Directory.Exists(path)) //comprueba que exista la carpeta si no la crea
                Directory.CreateDirectory(path);

            path += datename; //se agrega el nombre del archivo para comprobar si existe y para crear el arhivo.

            if (File.Exists(path)) //comprueba si existe el archivo si si lo elimina.
                File.Delete(path);

            var spreadsheetinfo = new FileInfo(path);
            var pck = new ExcelPackage(spreadsheetinfo);
            var spreadSheet = pck.Workbook.Worksheets.Add("SECADORVERTICAL");

            spreadSheet.Cells["A1"].Value = "Fecha";
            spreadSheet.Cells["B1"].Value = "MInicial";
            spreadSheet.Cells["C1"].Value = "MFinal";
            spreadSheet.Cells["D1"].Value = "MEnjuague";
            spreadSheet.Cells["A1:D1"].Style.Font.Bold = true;

            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM secadorvertical", connec);
            var reader = comando.ExecuteReader();
            var currentRow = 2;
            while (reader.Read())
            {
                spreadSheet.Cells["A" + currentRow].Value = reader.GetString(2);
                spreadSheet.Cells["C" + currentRow].Value = reader.GetDouble(3);
                spreadSheet.Cells["D" + currentRow].Value = reader.GetDouble(4);
                spreadSheet.Cells["E" + currentRow].Value = reader.GetDouble(5);
                currentRow++;
            }

            pck.SaveAs(spreadsheetinfo);
        }
        public static void DisplayInExcelTitulaciones()
        {
            var datename = "Titulaciones" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + ".xlsx";
            var path = @"C:\\Users\\Diego Maciel Acevedo\\Desktop\\ExcelSecadorVertical\\";

            if (!Directory.Exists(path)) //comprueba que exista la carpeta si no la crea
                Directory.CreateDirectory(path);

            path += datename; //se agrega el nombre del archivo para comprobar si existe y para crear el arhivo.

            if (File.Exists(path)) //comprueba si existe el archivo si si lo elimina.
                File.Delete(path);

            var spreadsheetinfo = new FileInfo(path);
            var pck = new ExcelPackage(spreadsheetinfo);
            var spreadSheet = pck.Workbook.Worksheets.Add("SECADORVERTICAL");

            spreadSheet.Cells["A1"].Value = "Fecha";
            spreadSheet.Cells["B1"].Value = "Titulacion";
            spreadSheet.Cells["C1"].Value = "RT1";
            spreadSheet.Cells["D1"].Value = "RT2";
            spreadSheet.Cells["A1:D1"].Style.Font.Bold = true;

            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM secadorvertical", connec);
            var reader = comando.ExecuteReader();
            var currentRow = 2;
            while (reader.Read())
            {
                spreadSheet.Cells["A" + currentRow].Value = reader.GetString(2);
                spreadSheet.Cells["B" + currentRow].Value = reader.GetString(17);
                spreadSheet.Cells["C" + currentRow].Value = reader.GetString(18);
                spreadSheet.Cells["D" + currentRow].Value = reader.GetString(19);
                currentRow++;
            }

            pck.SaveAs(spreadsheetinfo);
        }
    }
}
