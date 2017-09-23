using System;
using OfficeOpenXml;
using System.IO;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ProyectoNutrical.Models
{
    public class ModelEvaporador
    {
        public ModelEvaporador()
        {
        }

        public ModelEvaporador(int pIdLinea, string pCircuito, string pFecha, string pMInicial,
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
        ///     metodo para mostrar operador y analista
        /// </summary>
        public static List<ModelEvaporador> Llenarcombo()
        {
            var lista = new List<ModelEvaporador>();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM evaporador", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var pEvaporador = new ModelEvaporador
                {
                    IdLinea = reader.GetInt32(0),
                    Operador = reader.GetString(20),
                    Analista = reader.GetString(21)
                };
                lista.Add(pEvaporador);
            }
            return lista;
        }

        public static List<ModelEvaporador> LlenarGridView()
        {
            var lista = new List<ModelEvaporador>();
            var comando = new MySqlCommand("SELECT * FROM evaporador", ConexionMySql.ObtenerConexion());
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var pModelEvaporador = new ModelEvaporador
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
                lista.Add(pModelEvaporador);
            }
            return lista;
        }


        /// <summary>
        ///     metodo para agregar
        /// </summary>
        public static int Agregar(ModelEvaporador pMr)
        {
            var connec = ConexionMySql.ObtenerConexion();
            var comando =
                new MySqlCommand(
                    $"CALL sp_Evaporador('{pMr.IdLinea}','{pMr.Circuito}','{pMr.Fecha}','{pMr.MInicial}','{pMr.MFinal}','{pMr.MEnjuague}','{pMr.TAInicial}','{pMr.TAFinal}','{pMr.TAEnjuague}','{pMr.TTA}','{pMr.TipoLavado}','{pMr.TLInicial}','{pMr.TLFinal}','{pMr.TLEnjuague}','{pMr.TTLavado}','{pMr.Color1}','{pMr.Color2}','{pMr.Titulacion}','{pMr.RT1}','{pMr.RT2}','{pMr.Operador}','{pMr.Analista}')",
                    connec);
            var retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static List<ModelEvaporador> Buscar(string pFecha)
        {
            var lista = new List<ModelEvaporador>();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"SELECT * FROM evaporador WHERE Fecha>'{pFecha}'", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var pEvaporador = new ModelEvaporador
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
                lista.Add(pEvaporador);
            }
            return lista;
        }

        public static ModelEvaporador ObtenerEvaporador(int IdLinea)
        {
            var pMe = new ModelEvaporador();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"SELECT * FROM evaporador WHERE IDLinea ='{IdLinea}'", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                EvaporadorSelect.IdLinea = reader.GetInt32(0);
                EvaporadorSelect.Circuito = reader.GetString(1);
                EvaporadorSelect.Fecha = reader.GetString(2);
                EvaporadorSelect.MInicial = reader.GetString(3);
                EvaporadorSelect.MFinal = reader.GetString(4);
                EvaporadorSelect.MEnjuague = reader.GetString(5);
                EvaporadorSelect.TAInicial = reader.GetString(6);
                EvaporadorSelect.TAFinal = reader.GetString(7);
                EvaporadorSelect.TAEnjuague = reader.GetString(8);
                EvaporadorSelect.TTA = reader.GetString(9);
                EvaporadorSelect.TipoLavado = reader.GetString(10);
                EvaporadorSelect.TLInicial = reader.GetString(11);
                EvaporadorSelect.TLFinal = reader.GetString(12);
                EvaporadorSelect.TLEnjuague = reader.GetString(13);
                EvaporadorSelect.TTLavado = reader.GetString(14);
                EvaporadorSelect.Color1 = reader.GetString(15);
                EvaporadorSelect.Color2 = reader.GetString(16);
                EvaporadorSelect.Titulacion = reader.GetString(17);
                EvaporadorSelect.RT1 = reader.GetString(18);
                EvaporadorSelect.RT2 = reader.GetString(19);
                EvaporadorSelect.Operador = reader.GetString(20);
                EvaporadorSelect.Analista = reader.GetString(21);
            }
            connec.Close();
            return pMe;
        }
        public static int Exportar(ModelEvaporador pEvaporador, int pOperacion)
        {
            var retorno = 0;
            var conexion = ConexionMySql.ObtenerConexion();
            MySqlCommand comando;

            switch (pOperacion)
            {
                case 1: //exportar todos los datos
                    comando = new MySqlCommand(
                        $"Select * from evaporador('{pOperacion}','{pEvaporador.IdLinea}','{pEvaporador.Circuito}','{pEvaporador.Fecha}','{pEvaporador.MInicial}','{pEvaporador.MFinal}','{pEvaporador.MEnjuague}','{pEvaporador.TAInicial}','{pEvaporador.TAFinal}','{pEvaporador.TAEnjuague}','{pEvaporador.TTA}','{pEvaporador.TipoLavado}','{pEvaporador.TLInicial}','{pEvaporador.TLFinal}','{pEvaporador.TLEnjuague}','{pEvaporador.TTLavado}','{pEvaporador.Color1}','{pEvaporador.Color2}','{pEvaporador.Titulacion}','{pEvaporador.RT1}','{pEvaporador.RT2}','{pEvaporador.Operador}','{pEvaporador.Analista}'),'a','a')",
                        conexion);
                    retorno = comando.ExecuteNonQuery();
                    break;
                case 2: //exportar los datos de muestras
                    comando = new MySqlCommand(
                        $"Select * from evaporador('{pOperacion}','{pEvaporador.IdLinea}','{pEvaporador.Fecha}','{pEvaporador.MInicial}','a','a','{pEvaporador.MFinal}','{pEvaporador.MEnjuague}')",
                        conexion);
                    retorno = comando.ExecuteNonQuery();
                    break;
                case 3: //exportar los datos de titulacion
                    comando = new MySqlCommand(
                        $"Select * from evaporador('{pOperacion}','{pEvaporador.IdLinea}','{pEvaporador.Fecha}','{pEvaporador.Titulacion}','{pEvaporador.RT1}','{pEvaporador.RT2}')",
                        conexion);
                    retorno = comando.ExecuteNonQuery();
                    break;
            }
            return retorno;
        }
        /// <summary>
        ///     metodo para actualizar
        /// </summary>
        public static int Actualizar(ModelEvaporador pEvaporador)
        {
            var retorno = 0;
            var conexion = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"UPDATE evaporador SET Circuito='{pEvaporador.Circuito}', Fecha='{pEvaporador.Fecha}', MInicial='{pEvaporador.MInicial}', MFinal='{pEvaporador.MFinal}', MEnjuague='{pEvaporador.MEnjuague}', TAInicial='{pEvaporador.TAInicial}', TAFinal='{pEvaporador.TAFinal}', TAEnjuague='{pEvaporador.TAEnjuague}', TTAnalisis='{pEvaporador.TTA}', TipoLavado='{pEvaporador.TipoLavado}', TLInicial='{pEvaporador.TLInicial}', TLFinal='{pEvaporador.TLFinal}', TLEnjuague='{pEvaporador.TLEnjuague}', TTLavado='{pEvaporador.TTLavado}', Color1='{pEvaporador.Color1}', Color2='{pEvaporador.Color2}', Titulacion='{pEvaporador.Titulacion}', RT1='{pEvaporador.RT1}', RT2='{pEvaporador.RT2}', Operador='{pEvaporador.Operador}', Analista='{pEvaporador.Analista}' WHERE IDLinea='{pEvaporador.IdLinea}'", conexion);
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        /// <summary>
        ///     metodo para eliminar
        /// </summary>
        public static int Eliminar(int IdLinea)
        {
            var conexion = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"CALL eliminar_Evaporador('{IdLinea}'", conexion);
            var retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }

        public static class EvaporadorSelect
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
            var datename = "Evaporador" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + ".xlsx";
            var path = @"C:\\Users\\Diego Maciel Acevedo\\Desktop\\ExcelEvaporador\\";

            if (!Directory.Exists(path)) //comprueba que exista la carpeta si no la crea
                Directory.CreateDirectory(path);

            path += datename; //se agrega el nombre del archivo para comprobar si existe y para crear el arhivo.

            if (File.Exists(path)) //comprueba si existe el archivo si si lo elimina.
                File.Delete(path);

            var spreadsheetinfo = new FileInfo(path);
            var pck = new ExcelPackage(spreadsheetinfo);
            var spreadSheet = pck.Workbook.Worksheets.Add("EVAPORADOR");

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
            var comando = new MySqlCommand("SELECT * FROM evaporador", connec);
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
            var path = @"C:\\Users\\Diego Maciel Acevedo\\Desktop\\ExcelEvaporador\\";

            if (!Directory.Exists(path)) //comprueba que exista la carpeta si no la crea
                Directory.CreateDirectory(path);

            path += datename; //se agrega el nombre del archivo para comprobar si existe y para crear el arhivo.

            if (File.Exists(path)) //comprueba si existe el archivo si si lo elimina.
                File.Delete(path);

            var spreadsheetinfo = new FileInfo(path);
            var pck = new ExcelPackage(spreadsheetinfo);
            var spreadSheet = pck.Workbook.Worksheets.Add("EVAPORADOR");

            spreadSheet.Cells["A1"].Value = "Fecha";
            spreadSheet.Cells["B1"].Value = "MInicial";
            spreadSheet.Cells["C1"].Value = "MFinal";
            spreadSheet.Cells["D1"].Value = "MEnjuague";
            spreadSheet.Cells["A1:D1"].Style.Font.Bold = true;

            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM evaporador", connec);
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
            var path = @"C:\\Users\\Diego Maciel Acevedo\\Desktop\\ExcelEvaporador\\";

            if (!Directory.Exists(path)) //comprueba que exista la carpeta si no la crea
                Directory.CreateDirectory(path);

            path += datename; //se agrega el nombre del archivo para comprobar si existe y para crear el arhivo.

            if (File.Exists(path)) //comprueba si existe el archivo si si lo elimina.
                File.Delete(path);

            var spreadsheetinfo = new FileInfo(path);
            var pck = new ExcelPackage(spreadsheetinfo);
            var spreadSheet = pck.Workbook.Worksheets.Add("EVAPORADOR");

            spreadSheet.Cells["A1"].Value = "Fecha";
            spreadSheet.Cells["B1"].Value = "Titulacion";
            spreadSheet.Cells["C1"].Value = "RT1";
            spreadSheet.Cells["D1"].Value = "RT2";
            spreadSheet.Cells["A1:D1"].Style.Font.Bold = true;

            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM evaporador", connec);
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