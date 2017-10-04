using MySql.Data.MySqlClient;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProyectoNutrical.Models
{
    public class ModelPagos
    {
        public ModelPagos() { }

        public ModelPagos(int pidPagos, string pKilos, string pLitros, string pTemperatura, string pAcidez, string pPh,
            string pCrioscopia, string pGrasa, string pDensidad, string pSng, string pSt, string pAlcohol,
            string pNeutralizantes, string pEbullicion, string pInhibidores, string pSabor, string pTermofilicos,
            string pMicro, string pDisposicion, string pStArena, string pProteina, string pKilosSap, string pLitrosSap)
        {
            IdPagos = pidPagos;
            Kilos = pKilos;
            Litros = pLitros;
            Temperatura = pTemperatura;
            Acidez = pAcidez;
            Ph = pPh;
            Crioscopia = pCrioscopia;
            Grasa = pGrasa;
            Densidad = pDensidad;
            Sng = pSng;
            St = pSt;
            Alcohol = pAlcohol;
            Neutralizantes = pNeutralizantes;
            Ebullicion = pEbullicion;
            Inhibidores = pInhibidores;
            Sabor = pSabor;
            Termofilicos = pTermofilicos;
            Micro = pMicro;
            Disposicion = pDisposicion;
            StArena = pStArena;
            Proteina = pProteina;
            KilosSap = pKilosSap;
            LitrosSap = pLitrosSap;
        }

        public int IdPagos { get; set; }
        public string Kilos { get; set; }
        public string Litros { get; set; }
        public string Temperatura { get; set; }
        public string Acidez { get; set; }
        public string Ph { get; set; }
        public string Crioscopia { get; set; }
        public string Grasa { get; set; }
        public string Densidad { get; set; }
        public string Sng { get; set; }
        public string St { get; set; }
        public string Alcohol { get; set; }
        public string Neutralizantes { get; set; }
        public string Ebullicion { get; set; }
        public string Inhibidores { get; set; }
        public string Sabor { get; set; }
        public string Termofilicos { get; set; }
        public string Micro { get; set; }
        public string Disposicion { get; set; }
        public string StArena { get; set; }
        public string Proteina { get; set; }
        public string KilosSap { get; set; }
        public string LitrosSap { get; set; }

        //metodo para agregar
        public static int Agregar(ModelPagos pModelPago)
        {
            var comando =new MySqlCommand($" INSERT INTO pagos (Kilos, Litros, Temperatura, Acidez, pH, Crioscopia, Grasa, Densidad, SNG, ST, Alcohol, Neutralizantes, Ebullicion, Inhibidores, Sabor, Termofilicos, Micro, Disposicion, STArena, Proteina, KilosSAP, LitrosSAP ) VALUES ('{pModelPago.Kilos}','{pModelPago.Litros}','{pModelPago.Temperatura}','{pModelPago.Acidez}','{pModelPago.Ph}','{pModelPago.Crioscopia}','{pModelPago.Grasa}','{pModelPago.Densidad}','{pModelPago.Sng}','{pModelPago.St}','{pModelPago.Alcohol}','{pModelPago.Neutralizantes}','{pModelPago.Ebullicion}','{pModelPago.Inhibidores}','{pModelPago.Sabor}','{pModelPago.Termofilicos}','{pModelPago.Micro}','{pModelPago.Disposicion}','{pModelPago.StArena}','{pModelPago.Proteina}','{pModelPago.KilosSap}','{pModelPago.LitrosSap}')",ConexionMySql.ObtenerConexion());
            var retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        //metodo buscar
        public static List<ModelPagos> Buscar(string pidPagos)
        {
            var lista = new List<ModelPagos>();
            var comando = new MySqlCommand($"SELECT * FROM pagos WHERE IDPago='{pidPagos}'", ConexionMySql.ObtenerConexion());
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var pModelPago = new ModelPagos
                {
                    IdPagos = reader.GetInt32(0),
                    Kilos = reader.GetString(1),
                    Litros = reader.GetString(2),
                    Temperatura = reader.GetString(3),
                    Acidez = reader.GetString(4),
                    Ph = reader.GetString(5),
                    Crioscopia = reader.GetString(6),
                    Grasa = reader.GetString(7),
                    Densidad = reader.GetString(8),
                    Sng = reader.GetString(9),
                    St = reader.GetString(10),
                    Alcohol = reader.GetString(11),
                    Neutralizantes = reader.GetString(12),
                    Ebullicion = reader.GetString(13),
                    Inhibidores = reader.GetString(14),
                    Sabor = reader.GetString(15),
                    Termofilicos = reader.GetString(16),
                    Micro = reader.GetString(17),
                    Disposicion = reader.GetString(18),
                    StArena = reader.GetString(19),
                    Proteina = reader.GetString(20),
                    KilosSap = reader.GetString(21),
                    LitrosSap = reader.GetString(22)
                };
                lista.Add(pModelPago);
            }
            return lista;
        }
        public static List<ModelPagos> Llenargrid()
        {
            var lista = new List<ModelPagos>();
            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM pagos", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var pPagos = new ModelPagos
                {
                    IdPagos = reader.GetInt32(0),
                    Kilos = reader.GetString(1),
                    Litros = reader.GetString(2),
                    Temperatura = reader.GetString(3),
                    Acidez = reader.GetString(4),
                    Ph = reader.GetString(5),
                    Crioscopia = reader.GetString(6),
                    Grasa = reader.GetString(7),
                    Densidad = reader.GetString(8),
                    Sng = reader.GetString(9),
                    St = reader.GetString(10),
                    Alcohol = reader.GetString(11),
                    Neutralizantes = reader.GetString(12),
                    Ebullicion = reader.GetString(13),
                    Inhibidores = reader.GetString(14),
                    Sabor = reader.GetString(15),
                    Termofilicos = reader.GetString(16),
                    Micro = reader.GetString(17),
                    Disposicion = reader.GetString(18),
                    StArena = reader.GetString(19),
                    Proteina = reader.GetString(20),
                    KilosSap = reader.GetString(21),
                    LitrosSap = reader.GetString(22)
                };
                lista.Add(pPagos);
            }
            return lista;
        }
        public static ModelPagos ObtenerPago(int pidPagos)
        {
            var pModelPago = new ModelPagos();
            var connec = ConexionMySql.ObtenerConexion();

            var comando = new MySqlCommand($"SELECT * FROM pagos WHERE IDPago='{pidPagos}'", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                PagoSelec.IdPagos = reader.GetInt32(0);
                PagoSelec.Kilos = reader.GetString(1);
                PagoSelec.Litros = reader.GetString(2);
                PagoSelec.Temperatura = reader.GetString(3);
                PagoSelec.Acidez = reader.GetString(4);
                PagoSelec.Ph = reader.GetString(5);
                PagoSelec.Crioscopia = reader.GetString(6);
                PagoSelec.Grasa = reader.GetString(7);
                PagoSelec.Densidad = reader.GetString(8);
                PagoSelec.Sng = reader.GetString(9);
                PagoSelec.St = reader.GetString(10);
                PagoSelec.Alcohol = reader.GetString(11);
                PagoSelec.Neutralizantes = reader.GetString(12);
                PagoSelec.Ebullicion = reader.GetString(13);
                PagoSelec.Inhibidores = reader.GetString(14);
                PagoSelec.Sabor = reader.GetString(15);
                PagoSelec.Termofilicos = reader.GetString(16);
                PagoSelec.Micro = reader.GetString(17);
                PagoSelec.Disposicion = reader.GetString(18);
                PagoSelec.StArena = reader.GetString(19);
                PagoSelec.Proteina = reader.GetString(20);
                PagoSelec.KilosSap = reader.GetString(21);
                PagoSelec.LitrosSap = reader.GetString(22);
            }
            connec.Close();
            return pModelPago;
        }

        //metodo para actualizar 
        public static int Actualizar(ModelPagos pModelPago)
        {
            var conexion = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"UPDATE pagos SET Kilos = '{pModelPago.Kilos}', Litros= '{pModelPago.Litros}', Temperatura= '{pModelPago.Temperatura}', Acidez= '{pModelPago.Acidez}', pH= '{pModelPago.Ph}', Crioscopia= '{pModelPago.Crioscopia}', Grasa= '{pModelPago.Grasa}', Densidad= '{pModelPago.Densidad}', SNG = '{pModelPago.Sng}', ST = '{pModelPago.St}', Alcohol = '{pModelPago.Alcohol}', Neutralizantes = '{pModelPago.Neutralizantes}', Ebullicion = '{pModelPago.Ebullicion}', Inhibidores = '{pModelPago.Inhibidores}', Sabor = '{pModelPago.Sabor}', Termofilicos = '{pModelPago.Termofilicos}', Micro = '{pModelPago.Micro}', Disposicion = '{pModelPago.Disposicion}', STArena = '{pModelPago.StArena}', Proteina = '{pModelPago.Proteina}', KilosSAP = '{pModelPago.KilosSap}', LitrosSAP = '{pModelPago.Litros}' WHERE idPago='{pModelPago.IdPagos}'", conexion);
            var retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }

        //metodo para eliminar
        public static int Eliminar(int pidPagos)
        {
            var conexion = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"DELETE FROM pagos WHERE IDPago={pidPagos}", conexion);
            var retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }

        public static class PagoSelec
        {
            public static int IdPagos { get; set; }
            public static string Kilos { get; set; }
            public static string Litros { get; set; }
            public static string Temperatura { get; set; }
            public static string Acidez { get; set; }
            public static string Ph { get; set; }
            public static string Crioscopia { get; set; }
            public static string Grasa { get; set; }
            public static string Densidad { get; set; }
            public static string Sng { get; set; }
            public static string St { get; set; }
            public static string Alcohol { get; set; }
            public static string Neutralizantes { get; set; }
            public static string Ebullicion { get; set; }
            public static string Inhibidores { get; set; }
            public static string Sabor { get; set; }
            public static string Termofilicos { get; set; }
            public static string Micro { get; set; }
            public static string Disposicion { get; set; }
            public static string StArena { get; set; }
            public static string Proteina { get; set; }
            public static string KilosSap { get; set; }
            public static string LitrosSap { get; set; }
        }


        public static void DisplayInExcell()
        {
            var datename = "Pagos" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + ".xlsx";
            var path = @"C:\\ExcelCompra\\";

            if (!Directory.Exists(path)) //comprueba que exista la carpeta si no la crea
                Directory.CreateDirectory(path);

            path += datename; //se agrega el nombre del archivo para comprobar si existe y para crear el arhivo.

            if (File.Exists(path)) //comprueba si existe el archivo si exste lo elimina.
                File.Delete(path);

            var spreadsheetinfo = new FileInfo(path);
            var pck = new ExcelPackage(spreadsheetinfo);
            var spreadSheet = pck.Workbook.Worksheets.Add("pagos");

            spreadSheet.Cells["A1"].Value = "IDPago";
            spreadSheet.Cells["B1"].Value = "Kilos";
            spreadSheet.Cells["C1"].Value = "Litros";
            spreadSheet.Cells["D1"].Value = "Temperatura";
            spreadSheet.Cells["E1"].Value = "Acidez";
            spreadSheet.Cells["F1"].Value = "pH";
            spreadSheet.Cells["G1"].Value = "Crioscopia";
            spreadSheet.Cells["H1"].Value = "Grasa";
            spreadSheet.Cells["I1"].Value = "Densidad";
            spreadSheet.Cells["J1"].Value = "SNG";
            spreadSheet.Cells["K1"].Value = "ST";
            spreadSheet.Cells["L1"].Value = "Alcohol";
            spreadSheet.Cells["M1"].Value = "Neutralizantes";
            spreadSheet.Cells["N1"].Value = "Ebullicion";
            spreadSheet.Cells["O1"].Value = "Inhibidores";
            spreadSheet.Cells["P1"].Value = "Sabor";
            spreadSheet.Cells["Q1"].Value = "Termofilicos";
            spreadSheet.Cells["R1"].Value = "Micro";
            spreadSheet.Cells["S1"].Value = "Disposicion";
            spreadSheet.Cells["T1"].Value = "STArena";
            spreadSheet.Cells["U1"].Value = "Proteina";
            spreadSheet.Cells["V1"].Value = "KilosSAP";
            spreadSheet.Cells["W1"].Value = "LitrosSAP";
            spreadSheet.Cells["A1:W1"].Style.Font.Bold = true;

            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM pagos", connec);
            var reader = comando.ExecuteReader();
            var currentRow = 2;
            while (reader.Read())
            {
                spreadSheet.Cells["A" + currentRow].Value = reader.GetInt32(0);
                spreadSheet.Cells["B" + currentRow].Value = reader.GetString(1);
                spreadSheet.Cells["C" + currentRow].Value = reader.GetString(2);
                spreadSheet.Cells["D" + currentRow].Value = reader.GetString(3);
                spreadSheet.Cells["E" + currentRow].Value = reader.GetString(4);
                spreadSheet.Cells["F" + currentRow].Value = reader.GetString(5);
                spreadSheet.Cells["G" + currentRow].Value = reader.GetString(6);
                spreadSheet.Cells["H" + currentRow].Value = reader.GetString(7);
                spreadSheet.Cells["I" + currentRow].Value = reader.GetString(8);
                spreadSheet.Cells["J" + currentRow].Value = reader.GetString(9);
                spreadSheet.Cells["K" + currentRow].Value = reader.GetString(10);
                spreadSheet.Cells["L" + currentRow].Value = reader.GetString(11);
                spreadSheet.Cells["M" + currentRow].Value = reader.GetString(12);
                spreadSheet.Cells["N" + currentRow].Value = reader.GetString(13);
                spreadSheet.Cells["O" + currentRow].Value = reader.GetString(14);
                spreadSheet.Cells["P" + currentRow].Value = reader.GetString(15);
                spreadSheet.Cells["Q" + currentRow].Value = reader.GetString(16);
                spreadSheet.Cells["R" + currentRow].Value = reader.GetString(17);
                spreadSheet.Cells["S" + currentRow].Value = reader.GetString(18);
                spreadSheet.Cells["T" + currentRow].Value = reader.GetString(19);
                spreadSheet.Cells["U" + currentRow].Value = reader.GetString(20);
                spreadSheet.Cells["V" + currentRow].Value = reader.GetString(21);
                spreadSheet.Cells["W" + currentRow].Value = reader.GetString(22);
                currentRow++;
            }

            pck.SaveAs(spreadsheetinfo);
        }
    }
}