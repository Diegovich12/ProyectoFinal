using MySql.Data.MySqlClient;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProyectoNutrical.Models
{
    public class ModelMilkoScan
    {
        public ModelMilkoScan()
        {
        }

        public ModelMilkoScan(int pId, string pIdentificacion, int pRep, double pGrasa, double pProteina, double pSng,
            double pSt, double pLactosa,
            double pCaseina, double pUrea, double pDensidad, double pPh, double pAcidez, double pCrioscopia,
            double pFfa, string pFecha,
            double pProtCaseina, double pProtSuero)
        {
            Id = pId;
            Identificacion = pIdentificacion;
            Rep = pRep;
            Grasa = pGrasa;
            Proteina = pProteina;
            Sng = pSng;
            St = pSt;
            Lactosa = pLactosa;
            Caseina = pCaseina;
            Urea = pUrea;
            Densidad = pDensidad;
            Ph = pPh;
            Acidez = pAcidez;
            Crioscopia = pCrioscopia;
            Ffa = pFfa;
            Fecha = pFecha;
            ProtCaseina = pProtCaseina;
            ProtSuero = pProtSuero;
        }

        public int Id { get; set; }
        public string Identificacion { get; set; }
        public int Rep { get; set; }
        public double Grasa { get; set; }
        public double Proteina { get; set; }
        public double Sng { get; set; }
        public double St { get; set; }
        public double Lactosa { get; set; }
        public double Caseina { get; set; }
        public double Urea { get; set; }
        public double Densidad { get; set; }
        public double Ph { get; set; }
        public double Acidez { get; set; }
        public double Crioscopia { get; set; }
        public double Ffa { get; set; }
        public string Fecha { get; set; }
        public double ProtCaseina { get; set; }
        public double ProtSuero { get; set; }

        public static List<ModelMilkoScan> Llenargrid()
        {
            var lista = new List<ModelMilkoScan>();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM milkoscan", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var pModelMilkoScan = new ModelMilkoScan
                {
                    Id = reader.GetInt32(0),
                    Identificacion = reader.GetString(1),
                    Rep = reader.GetInt32(2),
                    Grasa = reader.GetDouble(3),
                    Proteina = reader.GetDouble(17),
                    Sng = reader.GetDouble(4),
                    St = reader.GetDouble(5),
                    Lactosa = reader.GetDouble(6),
                    Caseina = reader.GetDouble(7),
                    Urea = reader.GetDouble(8),
                    Densidad = reader.GetDouble(9),
                    Ph = reader.GetDouble(10),
                    Acidez = reader.GetDouble(11),
                    Crioscopia = reader.GetDouble(12),
                    Ffa = reader.GetDouble(13),
                    Fecha = reader.GetString(14),
                    ProtCaseina = reader.GetDouble(15),
                    ProtSuero = reader.GetDouble(16)
                };
                lista.Add(pModelMilkoScan);
            }
            return lista;
        }


        /// <summary>
        ///     metodo para agregar
        /// </summary>
        public static int Agregar(ModelMilkoScan pMs)
        {
            var connec = ConexionMySql.ObtenerConexion();
            var comando =
                new MySqlCommand(
                    $"CALL SPMilkoScan('{pMs.Identificacion}','{pMs.Rep}','{pMs.Grasa}','{pMs.Sng}','{pMs.St}','{pMs.Lactosa}','{pMs.Caseina}','{pMs.Urea}','{pMs.Densidad}','{pMs.Ph}','{pMs.Acidez}','{pMs.Crioscopia}','{pMs.Ffa}','{pMs.Fecha}','{pMs.ProtCaseina}','{pMs.ProtSuero}','{pMs.Proteina}')",
                    connec);
            var retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        /// <summary>
        ///     metodo para eliminar
        /// </summary>
        public static int Eliminar(int Identificacion)
        {
            var conexion = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"DELETE FROM milkoscan WHERE Id = '{Identificacion}'", conexion);
            var retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }

        public static int Actualizar(ModelMilkoScan pModelMilko, int pAcMilko)
        {
            var retorno = 0;
            var conexion = ConexionMySql.ObtenerConexion();
            MySqlCommand comando;
            {
                //actualizar los datos del milko
                comando = new MySqlCommand(
                    $"CALL ActualizarMilko('{pAcMilko}','{pModelMilko.Identificacion}','{pModelMilko.Rep}','{pModelMilko.Grasa}','{pModelMilko.Proteina}','{pModelMilko.Sng}','{pModelMilko.St}'','{pModelMilko.Lactosa}','{pModelMilko.Caseina}','{pModelMilko.Urea}','{pModelMilko.Densidad}','{pModelMilko.Ph}','{pModelMilko.Acidez}','{pModelMilko.Crioscopia}','{pModelMilko.Ffa}','{pModelMilko.Fecha}','{pModelMilko.ProtCaseina}','{pModelMilko.ProtSuero}','a','a')",
                    conexion);
                retorno = comando.ExecuteNonQuery();
            }
            return retorno;
        }


        public static List<ModelMilkoScan> Buscar(string pIdentificacion)
        {
            var lista = new List<ModelMilkoScan>();

            //aca tendrias que cambiar la query para que te busque por cualquiera de los 4 parametros

            var comando = new MySqlCommand($"SELECT * FROM milkoscan WHERE Identificacion='{pIdentificacion}'");
            ConexionMySql.ObtenerConexion();
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var pModelMilko = new ModelMilkoScan
                {
                    Identificacion = reader.GetString(0),
                };

                lista.Add(pModelMilko);
            }
            return lista;
        }

        public static ModelMilkoScan ObtenerMilko(int pIdMilko)
        {
            var pMs = new ModelMilkoScan();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"SELECT * FROM milkoscan WHERE ID ='{pIdMilko}'", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                MilkoScanSelect.Id = reader.GetInt32(0);
                MilkoScanSelect.Identificacion = reader.GetString(1);
                MilkoScanSelect.Rep = reader.GetInt32(2);
                MilkoScanSelect.Grasa = reader.GetDouble(3);
                MilkoScanSelect.Proteina = reader.GetDouble(17);
                MilkoScanSelect.Sng = reader.GetDouble(4);
                MilkoScanSelect.St = reader.GetDouble(5);
                MilkoScanSelect.Lactosa = reader.GetDouble(6);
                MilkoScanSelect.Caseina = reader.GetDouble(7);
                MilkoScanSelect.Urea = reader.GetDouble(8);
                MilkoScanSelect.Densidad = reader.GetDouble(9);
                MilkoScanSelect.Ph = reader.GetDouble(10);
                MilkoScanSelect.Acidez = reader.GetDouble(11);
                MilkoScanSelect.Crioscopia = reader.GetDouble(12);
                MilkoScanSelect.Ffa = reader.GetDouble(13);
                MilkoScanSelect.Fecha = reader.GetString(14);
                MilkoScanSelect.ProtCaseina = reader.GetDouble(15);
                MilkoScanSelect.ProtSuero = reader.GetDouble(16);
            }
            connec.Close();
            return pMs;
        }

        public static class MilkoScanSelect
        {
            public static int Id { get; set; }
            public static string Identificacion { get; set; }
            public static int Rep { get; set; }
            public static double Grasa { get; set; }
            public static double Proteina { get; set; }
            public static double Sng { get; set; }
            public static double St { get; set; }
            public static double Lactosa { get; set; }
            public static double Caseina { get; set; }
            public static double Urea { get; set; }
            public static double Densidad { get; set; }
            public static double Ph { get; set; }
            public static double Acidez { get; set; }
            public static double Crioscopia { get; set; }
            public static double Ffa { get; set; }
            public static string Fecha { get; set; }
            public static double ProtCaseina { get; set; }
            public static double ProtSuero { get; set; }
        }

        public static void DisplayInExcell()
        {
            var datename = "Milkoscan" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + ".xlsx";
            var path = @"C:\\Users\\Diego Maciel Acevedo\\Desktop\\ExcelMilko\\";

            if (!Directory.Exists(path)) //comprueba que exista la carpeta si no la crea
                Directory.CreateDirectory(path);

            path += datename; //se agrega el nombre del archivo para comprobar si existe y para crear el arhivo.

            if (File.Exists(path)) //comprueba si existe el archivo si exste lo elimina.
                File.Delete(path);

            var spreadsheetinfo = new FileInfo(path);
            var pck = new ExcelPackage(spreadsheetinfo);
            var spreadSheet = pck.Workbook.Worksheets.Add("MilkoScan");

            spreadSheet.Cells["A1"].Value = "Identificacion";
            spreadSheet.Cells["B1"].Value = "Rep";
            spreadSheet.Cells["C1"].Value = "Grasa";
            spreadSheet.Cells["D1"].Value = "Proteina";
            spreadSheet.Cells["E1"].Value = "Sng";
            spreadSheet.Cells["F1"].Value = "St";
            spreadSheet.Cells["G1"].Value = "Lactosa";
            spreadSheet.Cells["H1"].Value = "Caseina";
            spreadSheet.Cells["I1"].Value = "Urea";
            spreadSheet.Cells["J1"].Value = "Densidad";
            spreadSheet.Cells["K1"].Value = "Ph";
            spreadSheet.Cells["L1"].Value = "Acidez";
            spreadSheet.Cells["M1"].Value = "Crioscopia";
            spreadSheet.Cells["N1"].Value = "Ffa";
            spreadSheet.Cells["O1"].Value = "Fecha";
            spreadSheet.Cells["P1"].Value = "ProtCaseina";
            spreadSheet.Cells["Q1"].Value = "ProtSuero";
            spreadSheet.Cells["A1:Q1"].Style.Font.Bold = true;

            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM milkoscan", connec);
            var reader = comando.ExecuteReader();
            var currentRow = 2;
            while (reader.Read())
            {
                spreadSheet.Cells["A" + currentRow].Value = reader.GetString(1);
                spreadSheet.Cells["B" + currentRow].Value = reader.GetInt32(2);
                spreadSheet.Cells["C" + currentRow].Value = reader.GetDouble(3);
                spreadSheet.Cells["D" + currentRow].Value = reader.GetDouble(17);
                spreadSheet.Cells["E" + currentRow].Value = reader.GetDouble(4);
                spreadSheet.Cells["F" + currentRow].Value = reader.GetDouble(5);
                spreadSheet.Cells["G" + currentRow].Value = reader.GetDouble(6);
                spreadSheet.Cells["H" + currentRow].Value = reader.GetDouble(7);
                spreadSheet.Cells["I" + currentRow].Value = reader.GetDouble(8);
                spreadSheet.Cells["J" + currentRow].Value = reader.GetDouble(9);
                spreadSheet.Cells["K" + currentRow].Value = reader.GetDouble(10);
                spreadSheet.Cells["L" + currentRow].Value = reader.GetDouble(11);
                spreadSheet.Cells["M" + currentRow].Value = reader.GetDouble(12);
                spreadSheet.Cells["N" + currentRow].Value = reader.GetDouble(13);
                spreadSheet.Cells["O" + currentRow].Value = reader.GetString(14);
                spreadSheet.Cells["P" + currentRow].Value = reader.GetDouble(15);
                spreadSheet.Cells["Q" + currentRow].Value = reader.GetDouble(16);
                currentRow++;
            }

            pck.SaveAs(spreadsheetinfo);
        }

        public static void DisplayInExcel()
        {
            //SelectDisplayInExcel cambiar por este nombre al metodo cuando se cree el nuevo boton
            var datename = "MilkoscanSelectColum" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + ".xlsx";
            var path = @"C:\\exceles\\";

            if (!Directory.Exists(path)) //comprueba que exista la carpeta si no la crea
                Directory.CreateDirectory(path);

            path += datename; //se agrega el nombre del archivo para comprobar si existe y para crear el arhivo.

            if (File.Exists(path)) //comprueba si existe el archivo si exste lo elimina.
                File.Delete(path);

            var spreadsheetinfo = new FileInfo(path);
            var pck = new ExcelPackage(spreadsheetinfo);
            var spreadSheet = pck.Workbook.Worksheets.Add("MilkoScan");

            string[] cualesColumnas = { "uno", "dos", "tres" };

            var abecedarioList = new List<string>
            {
                "A1","B1","C1","D1","E1","F1","G1","H1","I1","J1","K1","L1","M1","N1","O1","P1","Q1"
            };

            for (var i = 0; i < cualesColumnas.Length; i++)
            {
                spreadSheet.Cells[abecedarioList[i]].Value = cualesColumnas[i];
            }

            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM milkoscan", connec);
            var reader = comando.ExecuteReader();
            var currentRow = 2;
            while (reader.Read())
            {
                spreadSheet.Cells["A" + currentRow].Value = reader.GetString(1);
                spreadSheet.Cells["B" + currentRow].Value = reader.GetInt32(2);
                spreadSheet.Cells["C" + currentRow].Value = reader.GetDouble(3);
                spreadSheet.Cells["D" + currentRow].Value = reader.GetDouble(17);
                spreadSheet.Cells["E" + currentRow].Value = reader.GetDouble(4);
                spreadSheet.Cells["F" + currentRow].Value = reader.GetDouble(5);
                spreadSheet.Cells["G" + currentRow].Value = reader.GetDouble(6);
                spreadSheet.Cells["H" + currentRow].Value = reader.GetDouble(7);
                spreadSheet.Cells["I" + currentRow].Value = reader.GetDouble(8);
                spreadSheet.Cells["J" + currentRow].Value = reader.GetDouble(9);
                spreadSheet.Cells["K" + currentRow].Value = reader.GetDouble(10);
                spreadSheet.Cells["L" + currentRow].Value = reader.GetDouble(11);
                spreadSheet.Cells["M" + currentRow].Value = reader.GetDouble(12);
                spreadSheet.Cells["N" + currentRow].Value = reader.GetDouble(13);
                spreadSheet.Cells["O" + currentRow].Value = reader.GetString(14);
                spreadSheet.Cells["P" + currentRow].Value = reader.GetDouble(15);
                spreadSheet.Cells["Q" + currentRow].Value = reader.GetDouble(16);
                currentRow++;
            }

            pck.SaveAs(spreadsheetinfo);
        }

    }
}