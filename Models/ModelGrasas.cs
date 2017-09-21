using MySql.Data.MySqlClient;
using System;
using OfficeOpenXml;
using System.IO;
using System.Collections.Generic;


namespace ProyectoNutrical.Models
{
    class ModelGrasas
    {
        public ModelGrasas()
        {
        }

        public ModelGrasas(int pIdLinea, string pCircuito, string pFecha, string pMuestra, string pMInicial,
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
        public static List<ModelGrasas> Llenarcombo()
        {
            var lista = new List<ModelGrasas>();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM grasas", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var pGR = new ModelGrasas
                {
                    IdLinea = reader.GetInt32(0),
                    TipoLavado = reader.GetString(1),
                    Titulacion = reader.GetString(2)
                };
                lista.Add(pGR);
            }
            return lista;
        }

        public static List<ModelGrasas> Llenargrid()
        {
            var lista = new List<ModelGrasas>();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM grasas", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var pGrasas = new ModelGrasas
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
                lista.Add(pGrasas);
            }
            return lista;
        }

        internal static int Actualizar(ModelGrasas pGR)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        ///     metodo para agregar
        /// </summary>
        public static int Agregar(ModelGrasas pMgr)
        {
            var connec = ConexionMySql.ObtenerConexion();
            var comando =
                new MySqlCommand(
                    $"CALL spInsertSecadorVertical('{pMgr.IdLinea}','{pMgr.Circuito}','{pMgr.Fecha}','{pMgr.Muestra}','{pMgr.MInicial}','{pMgr.MFinal}','{pMgr.MEnjuague}','{pMgr.TAInicial}','{pMgr.TAFinal}','{pMgr.TAEnjuague}','{pMgr.TTA}','{pMgr.TipoLavado}','{pMgr.TLInicial}','{pMgr.TLFinal}','{pMgr.TLEnjuague}','{pMgr.TTLavado}','{pMgr.Color1}','{pMgr.Color2}','{pMgr.Titulacion}','{pMgr.RT1}','{pMgr.RT2}','{pMgr.Operador}','{pMgr.Analista}')",
                    connec);
            var retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        /// <summary>
        ///     metodo buscar
        /// </summary>
        public static List<ModelGrasas> Buscar(string pFecha, string pTipoLavado, string pTitulacion)
        {
            var lista = new List<ModelGrasas>();
            var connec = ConexionMySql.ObtenerConexion();
            var comando =
                new MySqlCommand(
                    $"SELECT * FROM viewgrasas WHERE Fecha='{pFecha}' OR TipoLavado='{pTipoLavado}' OR Titulacion='{pTitulacion}'",
                    connec);
            var reader = comando.ExecuteReader();
            var pGR = new ModelGrasas
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
                lista.Add(pGR);
            return lista;
        }

        public static ModelGrasas ObtenerGR(int pIdGrasas)
        {
            var pMsv = new ModelGrasas();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"SELECT * FROM grasas WHERE ID ='{pIdGrasas}'", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                GrasasSelect.IdLinea = reader.GetInt32(0);
                GrasasSelect.Circuito = reader.GetString(1);
                GrasasSelect.Fecha = reader.GetString(2);
                GrasasSelect.Muestra = reader.GetString(3);
                GrasasSelect.MInicial = reader.GetString(4);
                GrasasSelect.MFinal = reader.GetString(5);
                GrasasSelect.MEnjuague = reader.GetString(6);
                GrasasSelect.TAInicial = reader.GetString(7);
                GrasasSelect.TAEnjuague = reader.GetString(9);
                GrasasSelect.TTA = reader.GetString(10);
                GrasasSelect.TipoLavado = reader.GetString(11);
                GrasasSelect.TLInicial = reader.GetString(12);
                GrasasSelect.TLEnjuague = reader.GetString(14);
                GrasasSelect.TTLavado = reader.GetString(15);
                GrasasSelect.Color1 = reader.GetString(16);
                GrasasSelect.Color2 = reader.GetString(17);
                GrasasSelect.Titulacion = reader.GetString(18);
                GrasasSelect.RT1 = reader.GetString(19);
                GrasasSelect.RT2 = reader.GetString(20);
                GrasasSelect.Operador = reader.GetString(21);
                GrasasSelect.Analista = reader.GetString(22);
            }
            connec.Close();
            return pMsv;
        }


        /// <summary>
        ///     metodo para actualizar
        /// </summary>
        public static int Actualizar(ModelGrasas pGrasas, int pGR)
        {
            var retorno = 0;
            var conexion = ConexionMySql.ObtenerConexion();
            MySqlCommand comando;

            switch (pGR)
            {
                case 1: //actualizar los datos de Recepcion
                    comando = new MySqlCommand(
                        $"CALL ActualizarGrasas('{pGR}','{pGrasas.IdLinea}','{pGrasas.Circuito}','{pGrasas.Muestra}','{pGrasas.MInicial}','{pGrasas.MFinal}','{pGrasas.MEnjuague}','{pGrasas.TAInicial}','{pGrasas.TAFinal}','{pGrasas.TAEnjuague}','{pGrasas.TTA}','{pGrasas.TipoLavado}','{pGrasas.TLInicial}','{pGrasas.TLFinal}','{pGrasas.TLEnjuague}','{pGrasas.TTLavado}','{pGrasas.Color1}','{pGrasas.Color2}','{pGrasas.Titulacion}','{pGrasas.RT1}','{pGrasas.RT2}','{pGrasas.Operador}','{pGrasas.Analista}','a','a')",
                        conexion);
                    retorno = comando.ExecuteNonQuery();
                    break;
            }
            return retorno;
        }

        /// <summary>
        ///     metodo para eliminar
        /// </summary>
        public static int Eliminar(int pIdMgr)
        {
            var conexion = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"DELETE FROM grasas WHERE ID = '{pIdMgr}'", conexion);
            var retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }

        public static class GrasasSelect
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
            var datename = "Grasas" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + ".xlsx";
            var path = @"C:\\Users\\Diego Maciel Acevedo\\Desktop\\ExcelGrasas\\";

            if (!Directory.Exists(path)) //comprueba que exista la carpeta si no la crea
                Directory.CreateDirectory(path);

            path += datename; //se agrega el nombre del archivo para comprobar si existe y para crear el arhivo.

            if (File.Exists(path)) //comprueba si existe el archivo si si lo elimina.
                File.Delete(path);

            var spreadsheetinfo = new FileInfo(path);
            var pck = new ExcelPackage(spreadsheetinfo);
            var spreadSheet = pck.Workbook.Worksheets.Add("GRASAS");

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
            var comando = new MySqlCommand("SELECT * FROM grasas", connec);
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
