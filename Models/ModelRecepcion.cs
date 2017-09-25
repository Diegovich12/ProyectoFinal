using System;
using OfficeOpenXml;
using System.IO;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ProyectoNutrical.Models
{
    public class ModelRecepcion
    {
        public ModelRecepcion() {}

        public ModelRecepcion(int pIdLinea, string pCircuito, string pFecha, string pMInicial,
            string pMFinal, string pMEnjuague, string pTAInicial, string pTAFinal, string pTAEnjuague, string pTTA,
            string pTipoLavado, string pTLInicial, string pTLFinal, string pTLEnjuague, string pTTLavado,
            string pColor1, string pColor2, string pTitulacion, string pRT1, string pRT2, string pOperador,
            string pAnalista)
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

        ///<summary>
        /// falta agregar el metodo para el calculo de los tiempos en analisis y lavado
        

        public static List<ModelRecepcion> LlenarGridView()
        {
            var lista = new List<ModelRecepcion>();
            var comando = new MySqlCommand("SELECT * FROM recepcion", ConexionMySql.ObtenerConexion());
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var pModelRecepcion = new ModelRecepcion
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
                lista.Add(pModelRecepcion);
            }
            return lista;
        }

        /// <summary>
        ///     metodo para agregar 
        /// </summary>
        public static int Agregar(ModelRecepcion pMr)
        {
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"CALL sp_Recepcion('{pMr.IdLinea}','{pMr.Circuito}','{pMr.Fecha}','{pMr.MInicial}','{pMr.MFinal}','{pMr.MEnjuague}','{pMr.TAInicial}','{pMr.TAFinal}','{pMr.TAEnjuague}','{pMr.TTA}','{pMr.TipoLavado}','{pMr.TLInicial}','{pMr.TLFinal}','{pMr.TLEnjuague}','{pMr.TTLavado}','{pMr.Color1}','{pMr.Color2}','{pMr.Titulacion}','{pMr.RT1}','{pMr.RT2}','{pMr.Operador}','{pMr.Analista}')",connec);
            var retorno = comando.ExecuteNonQuery();
            return retorno;
        }
        /// <summary>
        ///     metodo para eliminar 
        /// </summary>
        public static int Eliminar(int IdLinea)
        {
            var conexion = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"DELETE FROM recepcion WHERE IDLinea = '{IdLinea}'", conexion);
            var retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }
        /// <summary>
        ///     metodo  para buscar aun no funciona
        /// </summary>
        public static List<ModelRecepcion> Buscar(string pCircuito)
        {
            var lista = new List<ModelRecepcion>();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"SELECT * FROM recepcion WHERE Circuito='{pCircuito}'", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var pRecepcion = new ModelRecepcion
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
                lista.Add(pRecepcion);
            }
            return lista;
        }
            /// <summary>
            /// metodo para exportar funciona todo
            /// </summary>
            public static int Exportar(ModelRecepcion pRecepcion, int pOperacion)
        {
            var retorno = 0;
            var conexion = ConexionMySql.ObtenerConexion();
            MySqlCommand comando;

            switch (pOperacion)
            {
                case 1: //exportar todos los datos
                    comando = new MySqlCommand(
                        $"Select * from recepcion('{pOperacion}','{pRecepcion.IdLinea}','{pRecepcion.Circuito}','{pRecepcion.Fecha}','{pRecepcion.MInicial}','{pRecepcion.MFinal}','{pRecepcion.MEnjuague}','{pRecepcion.TAInicial}','{pRecepcion.TAFinal}','{pRecepcion.TAEnjuague}','{pRecepcion.TTA}','{pRecepcion.TipoLavado}','{pRecepcion.TLInicial}','{pRecepcion.TLFinal}','{pRecepcion.TLEnjuague}','{pRecepcion.TTLavado}','{pRecepcion.Color1}','{pRecepcion.Color2}','{pRecepcion.Titulacion}','{pRecepcion.RT1}','{pRecepcion.RT2}','{pRecepcion.Operador}','{pRecepcion.Analista}'),'a','a')",
                        conexion);
                    retorno = comando.ExecuteNonQuery();
                    break;
                case 2: //exportar los datos de muestras
                    comando = new MySqlCommand(
                        $"Select * from recepcion('{pOperacion}','{pRecepcion.IdLinea}','{pRecepcion.Fecha}','{pRecepcion.MInicial}','{pRecepcion.MFinal}','{pRecepcion.MEnjuague}')",
                        conexion);
                    retorno = comando.ExecuteNonQuery();
                    break;
                case 3: //exportar los datos de titulacion
                    comando = new MySqlCommand(
                        $"Select * from recepcion('{pOperacion}','{pRecepcion.IdLinea}','{pRecepcion.Fecha}','{pRecepcion.Titulacion}','{pRecepcion.RT1}','{pRecepcion.RT2}')",
                        conexion);
                    retorno = comando.ExecuteNonQuery();
                    break;
            }
            return retorno;
        }
        public static ModelRecepcion ObtenerRecepcion(int IdLinea)
        {
            var pMr = new ModelRecepcion();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"SELECT * FROM recepcion WHERE IDLinea ='{IdLinea}'", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                RecepcionSelect.IdLinea = reader.GetInt32(0);
                RecepcionSelect.Circuito = reader.GetString(1);
                RecepcionSelect.Fecha = reader.GetString(2);
                RecepcionSelect.MInicial = reader.GetString(3);
                RecepcionSelect.MFinal = reader.GetString(4);
                RecepcionSelect.MEnjuague = reader.GetString(5);
                RecepcionSelect.TAInicial = reader.GetString(6);
                RecepcionSelect.TAFinal = reader.GetString(7);
                RecepcionSelect.TAEnjuague = reader.GetString(8);
                RecepcionSelect.TTA = reader.GetString(9);
                RecepcionSelect.TipoLavado = reader.GetString(10);
                RecepcionSelect.TLInicial = reader.GetString(11);
                RecepcionSelect.TLFinal = reader.GetString(12);
                RecepcionSelect.TLEnjuague = reader.GetString(13);
                RecepcionSelect.TTLavado = reader.GetString(14);
                RecepcionSelect.Color1 = reader.GetString(15);
                RecepcionSelect.Color2 = reader.GetString(16);
                RecepcionSelect.Titulacion = reader.GetString(17);
                RecepcionSelect.RT1 = reader.GetString(18);
                RecepcionSelect.RT2 = reader.GetString(19);
                RecepcionSelect.Operador = reader.GetString(20);
                RecepcionSelect.Analista = reader.GetString(21);
            }
            connec.Close();
            return pMr;
        }


        /// <summary>
        ///     metodo para actualizar
        /// </summary>
        public static int Actualizar(ModelRecepcion pRecepcion)
        {
            var retorno = 0;
            var conexion = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand(string.Format("UPDATE recepcion SET Circuito='{1}', Fecha='{2}', MInicial='{3}', MFinal='{4}', MEnjuague='{5}', TAInicial='{6}', TAFinal='{7}', TAEnjuague='{8}', TTA='{9}', TipoLavado='{10}', TLInicial='{11}', TLFinal='{12}', TLEnjuague='{13}', TTLavado='{14}', Color1='{15}', Color2='{16}', Titulacion='{17}', RT1='{18}', RT2='{19}', Operador='{20}', Analista='{21}'  WHERE IdLinea={0}",
              pRecepcion.Circuito, pRecepcion.Fecha, pRecepcion.MInicial, pRecepcion.MFinal, pRecepcion.MEnjuague, pRecepcion.TAInicial, pRecepcion.TAFinal, pRecepcion.TAEnjuague, pRecepcion.TTA, pRecepcion.TipoLavado, pRecepcion.TLInicial, pRecepcion.TLFinal, pRecepcion.TLEnjuague, pRecepcion.TTLavado, pRecepcion.Color1, pRecepcion.Color2, pRecepcion.Titulacion, pRecepcion.RT1, pRecepcion.RT2, pRecepcion.Operador, pRecepcion.Analista, pRecepcion.IdLinea), conexion);
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
        public static class RecepcionSelect
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
            var datename = "recepcion" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + ".xlsx";
            var path = @"C:\\Users\\Diego Maciel Acevedo\\Desktop\\ExcelRecepcion\\";

            if (!Directory.Exists(path)) //comprueba que exista la carpeta si no la crea
                Directory.CreateDirectory(path);

            path += datename; //se agrega el nombre del archivo para comprobar si existe y para crear el arhivo.

            if (File.Exists(path)) //comprueba si existe el archivo si si lo elimina.
                File.Delete(path);

            var spreadsheetinfo = new FileInfo(path);
            var pck = new ExcelPackage(spreadsheetinfo);
            var spreadSheet = pck.Workbook.Worksheets.Add("RECEPCION");

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
            var comando = new MySqlCommand("SELECT * FROM recepcion", connec);
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
            var path = @"C:\\Users\\Diego Maciel Acevedo\\Desktop\\ExcelRecepcion\\";

            if (!Directory.Exists(path)) //comprueba que exista la carpeta si no la crea
                Directory.CreateDirectory(path);

            path += datename; //se agrega el nombre del archivo para comprobar si existe y para crear el arhivo.

            if (File.Exists(path)) //comprueba si existe el archivo si si lo elimina.
                File.Delete(path);

            var spreadsheetinfo = new FileInfo(path);
            var pck = new ExcelPackage(spreadsheetinfo);
            var spreadSheet = pck.Workbook.Worksheets.Add("RECEPCION");

            spreadSheet.Cells["A1"].Value = "Fecha";
            spreadSheet.Cells["B1"].Value = "MInicial";
            spreadSheet.Cells["C1"].Value = "MFinal";
            spreadSheet.Cells["D1"].Value = "MEnjuague";
            spreadSheet.Cells["A1:D1"].Style.Font.Bold = true;

            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM recepcion", connec);
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
            var path = @"C:\\Users\\Diego Maciel Acevedo\\Desktop\\ExcelRecepcion\\";

            if (!Directory.Exists(path)) //comprueba que exista la carpeta si no la crea
                Directory.CreateDirectory(path);

            path += datename; //se agrega el nombre del archivo para comprobar si existe y para crear el arhivo.

            if (File.Exists(path)) //comprueba si existe el archivo si si lo elimina.
                File.Delete(path);

            var spreadsheetinfo = new FileInfo(path);
            var pck = new ExcelPackage(spreadsheetinfo);
            var spreadSheet = pck.Workbook.Worksheets.Add("RECEPCION");

            spreadSheet.Cells["A1"].Value = "Fecha";
            spreadSheet.Cells["B1"].Value = "Titulacion";
            spreadSheet.Cells["C1"].Value = "RT1";
            spreadSheet.Cells["D1"].Value = "RT2";
            spreadSheet.Cells["A1:D1"].Style.Font.Bold = true;

            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM recepcion", connec);
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