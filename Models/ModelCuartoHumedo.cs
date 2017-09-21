using MySql.Data.MySqlClient;
using System;
using OfficeOpenXml;
using System.IO;
using System.Collections.Generic;


namespace ProyectoNutrical.Models
{
    class ModelCuartoHumedo
    {
        public ModelCuartoHumedo()
        {
        }

        public ModelCuartoHumedo(int pIdLinea, string pCircuito, string pFecha, string pMuestra, string pMInicial,
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
        public static List<ModelCuartoHumedo> Llenarcombo()
        {
            var lista = new List<ModelCuartoHumedo>();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM cuartohumedo", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var pCH = new ModelCuartoHumedo
                {
                    IdLinea = reader.GetInt32(0),
                    TipoLavado = reader.GetString(1),
                    Titulacion = reader.GetString(2)
                };
                lista.Add(pCH);
            }
            return lista;
        }

        public static List<ModelCuartoHumedo> Llenargrid()
        {
            var lista = new List<ModelCuartoHumedo>();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM cuartohumedo", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var pModelCuartoHumedo = new ModelCuartoHumedo
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
                lista.Add(pModelCuartoHumedo);
            }
            return lista;
        }


        /// <summary>
        ///     metodo para agregar
        /// </summary>
        public static int Agregar(ModelCuartoHumedo pMch)
        {
            var connec = ConexionMySql.ObtenerConexion();
            var comando =
                new MySqlCommand(
                    $"CALL spInsertCuartoHumedo('{pMch.IdLinea}','{pMch.Circuito}','{pMch.Fecha}','{pMch.Muestra}','{pMch.MInicial}','{pMch.MFinal}','{pMch.MEnjuague}','{pMch.TAInicial}','{pMch.TAFinal}','{pMch.TAEnjuague}','{pMch.TTA}','{pMch.TipoLavado}','{pMch.TLInicial}','{pMch.TLFinal}','{pMch.TLEnjuague}','{pMch.TTLavado}','{pMch.Color1}','{pMch.Color2}','{pMch.Titulacion}','{pMch.RT1}','{pMch.RT2}','{pMch.Operador}','{pMch.Analista}','nuevo')",
                    connec);
            var retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        internal static int Actualizar(ModelCuartoHumedo pCH)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     metodo buscar
        /// </summary>
        public static List<ModelCuartoHumedo> Buscar(string pFecha, string pTipoLavado, string pTitulacion)
        {
            var lista = new List<ModelCuartoHumedo>();
            var connec = ConexionMySql.ObtenerConexion();
            var comando =
                new MySqlCommand(
                    $"SELECT * FROM viewcuartohumedo WHERE Fecha='{pFecha}' OR TipoLavado='{pTipoLavado}' OR Titulacion='{pTitulacion}'",
                    connec);
            var reader = comando.ExecuteReader();
            var pCH = new ModelCuartoHumedo
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
                lista.Add(pCH);
            return lista;
        }

        public static ModelCuartoHumedo ObtenerCH(int pIdCuartoHumedo)
        {
            var pMch = new ModelCuartoHumedo();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"SELECT * FROM evaporador WHERE ID ='{pIdCuartoHumedo}'", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                CuartoHumedoSelect.IdLinea = reader.GetInt32(0);
                CuartoHumedoSelect.Circuito = reader.GetString(1);
                CuartoHumedoSelect.Fecha = reader.GetString(2);
                CuartoHumedoSelect.Muestra = reader.GetString(3);
                CuartoHumedoSelect.MInicial = reader.GetString(4);
                CuartoHumedoSelect.MFinal = reader.GetString(5);
                CuartoHumedoSelect.MEnjuague = reader.GetString(6);
                CuartoHumedoSelect.TAInicial = reader.GetString(7);
                CuartoHumedoSelect.TAEnjuague = reader.GetString(9);
                CuartoHumedoSelect.TTA = reader.GetString(10);
                CuartoHumedoSelect.TipoLavado = reader.GetString(11);
                CuartoHumedoSelect.TLInicial = reader.GetString(12);
                CuartoHumedoSelect.TLEnjuague = reader.GetString(14);
                CuartoHumedoSelect.TTLavado = reader.GetString(15);
                CuartoHumedoSelect.Color1 = reader.GetString(16);
                CuartoHumedoSelect.Color2 = reader.GetString(17);
                CuartoHumedoSelect.Titulacion = reader.GetString(18);
                CuartoHumedoSelect.RT1 = reader.GetString(19);
                CuartoHumedoSelect.RT2 = reader.GetString(20);
                CuartoHumedoSelect.Operador = reader.GetString(21);
                CuartoHumedoSelect.Analista = reader.GetString(22);
            }
            connec.Close();
            return pMch;
        }


        /// <summary>
        ///     metodo para actualizar
        /// </summary>
        public static int Actualizar(ModelCuartoHumedo pCH, int pCuartoHumedo)
        {
            var retorno = 0;
            var conexion = ConexionMySql.ObtenerConexion();
            MySqlCommand comando;

            switch (pCuartoHumedo)
            {
                case 1: //actualizar los datos de Recepcion
                    comando = new MySqlCommand(
                        $"CALL ActualizarCuartoHumedo('{pCuartoHumedo}','{pCH.IdLinea}','{pCH.Circuito}','{pCH.Muestra}','{pCH.MInicial}','{pCH.MFinal}','{pCH.MEnjuague}','{pCH.TAInicial}','{pCH.TAFinal}','{pCH.TAEnjuague}','{pCH.TTA}','{pCH.TipoLavado}','{pCH.TLInicial}','{pCH.TLFinal}','{pCH.TLEnjuague}','{pCH.TTLavado}','{pCH.Color1}','{pCH.Color2}','{pCH.Titulacion}','{pCH.RT1}','{pCH.RT2}','{pCH.Operador}','{pCH.Analista}','a','a')",
                        conexion);
                    retorno = comando.ExecuteNonQuery();
                    break;
            }
            return retorno;
        }

        /// <summary>
        ///     metodo para eliminar
        /// </summary>
        public static int Eliminar(int pIdMch)
        {
            var conexion = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"DELETE FROM cuartohumedo WHERE ID = '{pIdMch}'", conexion);
            var retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }

        public static class CuartoHumedoSelect
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
            var datename = "CuartoHumedo" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + ".xlsx";
            var path = @"C:\\Users\\Diego Maciel Acevedo\\Desktop\\ExcelCuartoHumedo\\";

            if (!Directory.Exists(path)) //comprueba que exista la carpeta si no la crea
                Directory.CreateDirectory(path);

            path += datename; //se agrega el nombre del archivo para comprobar si existe y para crear el arhivo.

            if (File.Exists(path)) //comprueba si existe el archivo si si lo elimina.
                File.Delete(path);

            var spreadsheetinfo = new FileInfo(path);
            var pck = new ExcelPackage(spreadsheetinfo);
            var spreadSheet = pck.Workbook.Worksheets.Add("CUARTOHUMEDO");

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
            spreadSheet.Cells["P1"].Value = "Color1";
            spreadSheet.Cells["Q1"].Value = "Color2";
            spreadSheet.Cells["R1"].Value = "Titulacion";
            spreadSheet.Cells["S1"].Value = "RT1";
            spreadSheet.Cells["T1"].Value = "RT2";
            spreadSheet.Cells["U1"].Value = "Operador";
            spreadSheet.Cells["V1"].Value = "Analista";
            spreadSheet.Cells["A1:V1"].Style.Font.Bold = true;


            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM cuartohumedo", connec);
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
