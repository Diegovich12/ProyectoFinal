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

        public ModelEvaporador(int pIdLinea, string pCircuito, string pFecha, string pMuestra, string pMInicial,
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
                    TipoLavado = reader.GetString(1),
                    Titulacion = reader.GetString(2)
                };
                lista.Add(pEvaporador);
            }
            return lista;
        }

        public static List<ModelEvaporador> Llenargrid()
        {
            var lista = new List<ModelEvaporador>();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM evaporador", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var pModelEvaporador = new ModelEvaporador
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
                    $"CALL spInsertEvaporador('{pMr.IdLinea}','{pMr.Circuito}','{pMr.Fecha}','{pMr.Muestra}','{pMr.MInicial}','{pMr.MFinal}','{pMr.MEnjuague}','{pMr.TAInicial}','{pMr.TAFinal}','{pMr.TAEnjuague}','{pMr.TTA}','{pMr.TipoLavado}','{pMr.TLInicial}','{pMr.TLFinal}','{pMr.TLEnjuague}','{pMr.TTLavado}','{pMr.Color1}','{pMr.Color2}','{pMr.Titulacion}','{pMr.RT1}','{pMr.RT2}','{pMr.Operador}','{pMr.Analista}')",
                    connec);
            var retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        /// <summary>
        ///     metodo buscar
        /// </summary>
        public static List<ModelEvaporador> Buscar(string pFecha, string pTipoLavado, string pTitulacion)
        {
            var lista = new List<ModelEvaporador>();
            var connec = ConexionMySql.ObtenerConexion();
            var comando =
                new MySqlCommand(
                    $"SELECT * FROM viewevaporador WHERE Fecha='{pFecha}' OR TipoLavado='{pTipoLavado}' OR Titulacion='{pTitulacion}'",
                    connec);
            var reader = comando.ExecuteReader();
            var pRecepcion = new ModelEvaporador
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
                lista.Add(pRecepcion);
            return lista;
        }

        internal static int Actualizar(ModelEvaporador pEvaporador)
        {
            throw new NotImplementedException();
        }

        public static ModelEvaporador ObtenerEvaporador(int pIdEvaporador)
        {
            var pMr = new ModelEvaporador();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"SELECT * FROM evaporador WHERE ID ='{pIdEvaporador}'", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                EvaporadorSelect.IdLinea = reader.GetInt32(0);
                EvaporadorSelect.Circuito = reader.GetString(1);
                EvaporadorSelect.Fecha = reader.GetString(2);
                EvaporadorSelect.Muestra = reader.GetString(3);
                EvaporadorSelect.MInicial = reader.GetString(4);
                EvaporadorSelect.MFinal = reader.GetString(5);
                EvaporadorSelect.MEnjuague = reader.GetString(6);
                EvaporadorSelect.TAInicial = reader.GetString(7);
                EvaporadorSelect.TAEnjuague = reader.GetString(9);
                EvaporadorSelect.TTA = reader.GetString(10);
                EvaporadorSelect.TipoLavado = reader.GetString(11);
                EvaporadorSelect.TLInicial = reader.GetString(12);
                EvaporadorSelect.TLEnjuague = reader.GetString(14);
                EvaporadorSelect.TTLavado = reader.GetString(15);
                EvaporadorSelect.Color1 = reader.GetString(16);
                EvaporadorSelect.Color2 = reader.GetString(17);
                EvaporadorSelect.Titulacion = reader.GetString(18);
                EvaporadorSelect.RT1 = reader.GetString(19);
                EvaporadorSelect.RT2 = reader.GetString(20);
                EvaporadorSelect.Operador = reader.GetString(21);
                EvaporadorSelect.Analista = reader.GetString(22);
            }
            connec.Close();
            return pMr;
        }


        /// <summary>
        ///     metodo para actualizar
        /// </summary>
        public static int Actualizar(ModelEvaporador pEvaporador, int pEva)
        {
            var retorno = 0;
            var conexion = ConexionMySql.ObtenerConexion();
            MySqlCommand comando;

            switch (pEva)
            {
                case 1: //actualizar los datos de Recepcion
                    comando = new MySqlCommand(
                        $"CALL ActualizarRecepcion('{pEva}','{pEvaporador.IdLinea}','{pEvaporador.Circuito}','{pEvaporador.Muestra}','{pEvaporador.MInicial}','{pEvaporador.MFinal}','{pEvaporador.MEnjuague}','{pEvaporador.TAInicial}','{pEvaporador.TAFinal}','{pEvaporador.TAEnjuague}','{pEvaporador.TTA}','{pEvaporador.TipoLavado}','{pEvaporador.TLInicial}','{pEvaporador.TLFinal}','{pEvaporador.TLEnjuague}','{pEvaporador.TTLavado}','{pEvaporador.Color1}','{pEvaporador.Color2}','{pEvaporador.Titulacion}','{pEvaporador.RT1}','{pEvaporador.RT2}','{pEvaporador.Operador}','{pEvaporador.Analista}','a','a')",
                        conexion);
                    retorno = comando.ExecuteNonQuery();
                    break;
            }
            return retorno;
        }

        /// <summary>
        ///     metodo para eliminar
        /// </summary>
        public static int Eliminar(int pIdMe)
        {
            var conexion = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"DELETE FROM evaporador WHERE ID = '{pIdMe}'", conexion);
            var retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }

        public static class EvaporadorSelect
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
            var comando = new MySqlCommand("SELECT * FROM evaporador", connec);
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
                spreadSheet.Cells["Q" + currentRow].Value = reader.GetDouble(18);
                spreadSheet.Cells["R" + currentRow].Value = reader.GetDouble(19);
                spreadSheet.Cells["S" + currentRow].Value = reader.GetDouble(20);
                spreadSheet.Cells["T" + currentRow].Value = reader.GetDouble(21);
                spreadSheet.Cells["U" + currentRow].Value = reader.GetDouble(22);
                currentRow++;
            }

            pck.SaveAs(spreadsheetinfo);
        }
    }
}