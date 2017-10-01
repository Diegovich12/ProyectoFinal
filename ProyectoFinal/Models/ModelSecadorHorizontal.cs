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

        public ModelSecadorHorizontal(int pIdLinea, string pCircuito, string pFecha, string pMInicial,
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
                    $"CALL sp_SecadorHorizontal('{pMsh.IdLinea}','{pMsh.Circuito}','{pMsh.Fecha}','{pMsh.MInicial}','{pMsh.MFinal}','{pMsh.MEnjuague}','{pMsh.TAInicial}','{pMsh.TAFinal}','{pMsh.TAEnjuague}','{pMsh.TTA}','{pMsh.TipoLavado}','{pMsh.TLInicial}','{pMsh.TLFinal}','{pMsh.TLEnjuague}','{pMsh.TTLavado}','{pMsh.Color1}','{pMsh.Color2}','{pMsh.Titulacion}','{pMsh.RT1}','{pMsh.RT2}','{pMsh.Operador}','{pMsh.Analista}')",
                    connec);
            var retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        /// <summary>
        ///     metodo para buscar 
        /// </summary>
        public static List<ModelSecadorHorizontal> Buscar(string pCircuito)
        {
            var lista = new List<ModelSecadorHorizontal>();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"SELECT * FROM secadorhorizontal WHERE Circuito='{pCircuito}'", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var pSH = new ModelSecadorHorizontal
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
                lista.Add(pSH);
            }
            return lista;
        }

        public static ModelSecadorHorizontal ObtenerSH(int IdLinea)
        {
            var pMsh = new ModelSecadorHorizontal();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"SELECT * FROM secadorhorizontal WHERE IDLinea ='{IdLinea}'", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                SHorizontalSelect.IdLinea = reader.GetInt32(0);
                SHorizontalSelect.Circuito = reader.GetString(1);
                SHorizontalSelect.Fecha = reader.GetString(2);
                SHorizontalSelect.MInicial = reader.GetString(3);
                SHorizontalSelect.MFinal = reader.GetString(4);
                SHorizontalSelect.MEnjuague = reader.GetString(5);
                SHorizontalSelect.TAInicial = reader.GetString(6);
                SHorizontalSelect.TAFinal = reader.GetString(7);
                SHorizontalSelect.TAEnjuague = reader.GetString(8);
                SHorizontalSelect.TTA = reader.GetString(9);
                SHorizontalSelect.TipoLavado = reader.GetString(10);
                SHorizontalSelect.TLInicial = reader.GetString(11);
                SHorizontalSelect.TLFinal = reader.GetString(12);
                SHorizontalSelect.TLEnjuague = reader.GetString(13);
                SHorizontalSelect.TTLavado = reader.GetString(14);
                SHorizontalSelect.Color1 = reader.GetString(15);
                SHorizontalSelect.Color2 = reader.GetString(16);
                SHorizontalSelect.Titulacion = reader.GetString(17);
                SHorizontalSelect.RT1 = reader.GetString(18);
                SHorizontalSelect.RT2 = reader.GetString(19);
                SHorizontalSelect.Operador = reader.GetString(20);
                SHorizontalSelect.Analista = reader.GetString(21);
            }
            connec.Close();
            return pMsh;
        }
        /// <summary>
        /// metodo para exportar funciona todo
        /// </summary>
        public static int Exportar(ModelSecadorHorizontal pSH, int pOperacion)
        {
            var retorno = 0;
            var conexion = ConexionMySql.ObtenerConexion();
            MySqlCommand comando;

            switch (pOperacion)
            {
                case 1: //exportar todos los datos
                    comando = new MySqlCommand(
                        $"Select * from secadorhorizontal('{pOperacion}','{pSH.IdLinea}','{pSH.Circuito}','{pSH.Fecha}','{pSH.MInicial}','{pSH.MFinal}','{pSH.MEnjuague}','{pSH.TAInicial}','{pSH.TAFinal}','{pSH.TAEnjuague}','{pSH.TTA}','{pSH.TipoLavado}','{pSH.TLInicial}','{pSH.TLFinal}','{pSH.TLEnjuague}','{pSH.TTLavado}','{pSH.Color1}','{pSH.Color2}','{pSH.Titulacion}','{pSH.RT1}','{pSH.RT2}','{pSH.Operador}','{pSH.Analista}'),'a','a')",
                        conexion);
                    retorno = comando.ExecuteNonQuery();
                    break;
                case 2: //exportar los datos de muestras
                    comando = new MySqlCommand(
                        $"Select * from secadorhorizontal('{pOperacion}','{pSH.IdLinea}','{pSH.Fecha}','{pSH.MInicial}','{pSH.MFinal}','{pSH.MEnjuague}')",
                        conexion);
                    retorno = comando.ExecuteNonQuery();
                    break;
                case 3: //exportar los datos de titulacion
                    comando = new MySqlCommand(
                        $"Select * from secadorhorizontal('{pOperacion}','{pSH.IdLinea}','{pSH.Fecha}','{pSH.Titulacion}','{pSH.RT1}','{pSH.RT2}')",
                        conexion);
                    retorno = comando.ExecuteNonQuery();
                    break;
            }
            return retorno;
        }

        /// <summary>
        ///     metodo para actualizar
        /// </summary>
        public static int Actualizar(ModelSecadorHorizontal pSH)
        {
            var retorno = 0;
            var conexion = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"UPDATE secadorhorizontal SET Circuito='{pSH.Circuito}', Fecha='{pSH.Fecha}', MInicial='{pSH.MInicial}', MFinal='{pSH.MFinal}', MEnjuague='{pSH.MEnjuague}', TAInicial='{pSH.TAInicial}', TAFinal='{pSH.TAFinal}', TAEnjuague='{pSH.TAEnjuague}', TTAnalisis='{pSH.TTA}', TipoLavado='{pSH.TipoLavado}', TLInicial='{pSH.TLInicial}', TLFinal='{pSH.TLFinal}', TLEnjuague='{pSH.TLEnjuague}', TTLavado='{pSH.TTLavado}', Color1='{pSH.Color1}', Color2='{pSH.Color2}', Titulacion='{pSH.Titulacion}', RT1='{pSH.RT1}', RT2='{pSH.RT2}', Operador='{pSH.Operador}', Analista='{pSH.Analista}' WHERE IDLinea='{pSH.IdLinea}'", conexion);
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        /// <summary>
        ///     metodo para eliminar 
        /// </summary>
        public static int Eliminar(int IdLinea)
        {
            var conexion = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"DELETE FROM secadorhorizontal WHERE IDLinea = '{IdLinea}'", conexion);
            var retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }

        public static class SHorizontalSelect
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
