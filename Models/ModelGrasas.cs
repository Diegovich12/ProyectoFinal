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

        public ModelGrasas(int pIdLinea, string pCircuito, string pFecha, string pMInicial,
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
                    Operador = reader.GetString(20),
                    Analista = reader.GetString(21)
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
                lista.Add(pGrasas);
            }
            return lista;
        }


        /// <summary>
        ///     metodo para agregar
        /// </summary>
        public static int Agregar(ModelGrasas pMgr)
        {
            var connec = ConexionMySql.ObtenerConexion();
            var comando =
                new MySqlCommand(
                    $"CALL sp_Grasas('{pMgr.IdLinea}','{pMgr.Circuito}','{pMgr.Fecha}','{pMgr.MInicial}','{pMgr.MFinal}','{pMgr.MEnjuague}','{pMgr.TAInicial}','{pMgr.TAFinal}','{pMgr.TAEnjuague}','{pMgr.TTA}','{pMgr.TipoLavado}','{pMgr.TLInicial}','{pMgr.TLFinal}','{pMgr.TLEnjuague}','{pMgr.TTLavado}','{pMgr.Color1}','{pMgr.Color2}','{pMgr.Titulacion}','{pMgr.RT1}','{pMgr.RT2}','{pMgr.Operador}','{pMgr.Analista}')",
                    connec);
            var retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        /// <summary>
        ///     metodo  para buscar aun no funciona
        /// </summary>
        public static List<ModelGrasas> Buscar(string pCircuito)
        {
            var lista = new List<ModelGrasas>();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"SELECT * FROM grasas WHERE Circuito='{pCircuito}'", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var pGrasas = new ModelGrasas
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
                lista.Add(pGrasas);
            }
            return lista;
        }

        public static ModelGrasas ObtenerGR(int IdLinea)
        {
            var pMsv = new ModelGrasas();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"SELECT * FROM grasas WHERE IDLinea ='{IdLinea}'", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                GrasasSelect.IdLinea = reader.GetInt32(0);
                GrasasSelect.Circuito = reader.GetString(1);
                GrasasSelect.Fecha = reader.GetString(2);
                GrasasSelect.MInicial = reader.GetString(3);
                GrasasSelect.MFinal = reader.GetString(4);
                GrasasSelect.MEnjuague = reader.GetString(5);
                GrasasSelect.TAInicial = reader.GetString(6);
                GrasasSelect.TAFinal = reader.GetString(7);
                GrasasSelect.TAEnjuague = reader.GetString(8);
                GrasasSelect.TTA = reader.GetString(9);
                GrasasSelect.TipoLavado = reader.GetString(10);
                GrasasSelect.TLInicial = reader.GetString(11);
                GrasasSelect.TLFinal = reader.GetString(12);
                GrasasSelect.TLEnjuague = reader.GetString(13);
                GrasasSelect.TTLavado = reader.GetString(14);
                GrasasSelect.Color1 = reader.GetString(15);
                GrasasSelect.Color2 = reader.GetString(16);
                GrasasSelect.Titulacion = reader.GetString(17);
                GrasasSelect.RT1 = reader.GetString(18);
                GrasasSelect.RT2 = reader.GetString(19);
                GrasasSelect.Operador = reader.GetString(20);
                GrasasSelect.Analista = reader.GetString(21);
            }
            connec.Close();
            return pMsv;
        }

        /// <summary>
        /// metodo para exportar funciona todo
        /// </summary>
        public static int Exportar(ModelGrasas pGrasas, int pOperacion)
        {
            var retorno = 0;
            var conexion = ConexionMySql.ObtenerConexion();
            MySqlCommand comando;

            switch (pOperacion)
            {
                case 1: //exportar todos los datos
                    comando = new MySqlCommand(
                        $"Select * from grasas('{pOperacion}','{pGrasas.IdLinea}','{pGrasas.Circuito}','{pGrasas.Fecha}','{pGrasas.MInicial}','{pGrasas.MFinal}','{pGrasas.MEnjuague}','{pGrasas.TAInicial}','{pGrasas.TAFinal}','{pGrasas.TAEnjuague}','{pGrasas.TTA}','{pGrasas.TipoLavado}','{pGrasas.TLInicial}','{pGrasas.TLFinal}','{pGrasas.TLEnjuague}','{pGrasas.TTLavado}','{pGrasas.Color1}','{pGrasas.Color2}','{pGrasas.Titulacion}','{pGrasas.RT1}','{pGrasas.RT2}','{pGrasas.Operador}','{pGrasas.Analista}'),'a','a')",
                        conexion);
                    retorno = comando.ExecuteNonQuery();
                    break;
                case 2: //exportar los datos de muestras
                    comando = new MySqlCommand(
                        $"Select * from grasas('{pOperacion}','{pGrasas.IdLinea}','{pGrasas.Fecha}','{pGrasas.MInicial}','a','a','{pGrasas.MFinal}','{pGrasas.MEnjuague}')",
                        conexion);
                    retorno = comando.ExecuteNonQuery();
                    break;
                case 3: //exportar los datos de titulacion
                    comando = new MySqlCommand(
                        $"Select * from grasas('{pOperacion}','{pGrasas.IdLinea}','{pGrasas.Fecha}','{pGrasas.Titulacion}','{pGrasas.RT1}','{pGrasas.RT2}')",
                        conexion);
                    retorno = comando.ExecuteNonQuery();
                    break;
            }
            return retorno;
        }

        /// <summary>
        ///     metodo para actualizar
        /// </summary>
        public static int Actualizar(ModelGrasas pGrasas)
        {
            var retorno = 0;
            var conexion = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"UPDATE grasas SET Circuito='{pGrasas.Circuito}', Fecha='{pGrasas.Fecha}', MInicial='{pGrasas.MInicial}', MFinal='{pGrasas.MFinal}', MEnjuague='{pGrasas.MEnjuague}', TAInicial='{pGrasas.TAInicial}', TAFinal='{pGrasas.TAFinal}', TAEnjuague='{pGrasas.TAEnjuague}', TTAnalisis='{pGrasas.TTA}', TipoLavado='{pGrasas.TipoLavado}', TLInicial='{pGrasas.TLInicial}', TLFinal='{pGrasas.TLFinal}', TLEnjuague='{pGrasas.TLEnjuague}', TTLavado='{pGrasas.TTLavado}', Color1='{pGrasas.Color1}', Color2='{pGrasas.Color2}', Titulacion='{pGrasas.Titulacion}', RT1='{pGrasas.RT1}', RT2='{pGrasas.RT2}', Operador='{pGrasas.Operador}', Analista='{pGrasas.Analista}' WHERE IDLinea='{pGrasas.IdLinea}'", conexion);
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        /// <summary>
        ///     metodo para eliminar 
        /// </summary>
        public static int Eliminar(int IdLinea)
        {
            var conexion = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"DELETE FROM grasas WHERE IDLinea = '{IdLinea}'", conexion);
            var retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }

        public static class GrasasSelect
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
            var comando = new MySqlCommand("SELECT * FROM grasas", connec);
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
            var path = @"C:\\Users\\Diego Maciel Acevedo\\Desktop\\ExcelGrasas\\";

            if (!Directory.Exists(path)) //comprueba que exista la carpeta si no la crea
                Directory.CreateDirectory(path);

            path += datename; //se agrega el nombre del archivo para comprobar si existe y para crear el arhivo.

            if (File.Exists(path)) //comprueba si existe el archivo si si lo elimina.
                File.Delete(path);

            var spreadsheetinfo = new FileInfo(path);
            var pck = new ExcelPackage(spreadsheetinfo);
            var spreadSheet = pck.Workbook.Worksheets.Add("GRASAS");

            spreadSheet.Cells["A1"].Value = "Fecha";
            spreadSheet.Cells["B1"].Value = "MInicial";
            spreadSheet.Cells["C1"].Value = "MFinal";
            spreadSheet.Cells["D1"].Value = "MEnjuague";
            spreadSheet.Cells["A1:D1"].Style.Font.Bold = true;

            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM grasas", connec);
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
            var path = @"C:\\Users\\Diego Maciel Acevedo\\Desktop\\ExcelGrasas\\";

            if (!Directory.Exists(path)) //comprueba que exista la carpeta si no la crea
                Directory.CreateDirectory(path);

            path += datename; //se agrega el nombre del archivo para comprobar si existe y para crear el arhivo.

            if (File.Exists(path)) //comprueba si existe el archivo si si lo elimina.
                File.Delete(path);

            var spreadsheetinfo = new FileInfo(path);
            var pck = new ExcelPackage(spreadsheetinfo);
            var spreadSheet = pck.Workbook.Worksheets.Add("GRASAS");

            spreadSheet.Cells["A1"].Value = "Fecha";
            spreadSheet.Cells["B1"].Value = "Titulacion";
            spreadSheet.Cells["C1"].Value = "RT1";
            spreadSheet.Cells["D1"].Value = "RT2";
            spreadSheet.Cells["A1:D1"].Style.Font.Bold = true;

            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM grasas", connec);
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
