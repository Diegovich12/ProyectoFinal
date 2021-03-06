﻿using MySql.Data.MySqlClient;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProyectoNutrical.Models
{
    public class ModelProveedores
    {
        //las llaves foraneas no las agrege por que pienso utilizar las propiedades id como los campos fk para no utilizar mas memoria
        public ModelProveedores() { }

        public ModelProveedores(int pidProveedor, string pNombre, string pProveedor, int pidCamiones, string pMatricula, string pNoPipa,
            int pidRancho, string pRancho)
        {
            IdProveedor = pidProveedor;
            Nombre = pNombre;
            Proveedor = pProveedor;
            IdCamiones = pidCamiones;
            Matricula = pMatricula;
            NoPipa = pNoPipa;
            IdRancho = pidRancho;
            Rancho = pRancho;
        }

        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string Proveedor { get; set; }
        public int IdCamiones { get; set; }
        public string Matricula { get; set; }
        public string NoPipa { get; set; }
        public int IdRancho { get; set; }
        public string Rancho { get; set; }

        //metodo para agregar a este metodo agregar le hace falta hacer un procedimiento almacenada para que cuando inserte provedores inserte tambien ranchos y camiones
        public static int Agregar(ModelProveedores pModelProveedores)
        {
            var comando =
                new MySqlCommand($"INSERT INTO proveedores (NombreProveedor, Proveedor, Matricula, Rancho, NoPipa) VALUES ('{pModelProveedores.Nombre}','{pModelProveedores.Proveedor}','{pModelProveedores.Matricula}','{pModelProveedores.Rancho}','{pModelProveedores.NoPipa}')",

                    ConexionMySql.ObtenerConexion());

            var retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        //este metodo se utiliza para rellenar el gridview altaprovedores
        public static List<ModelProveedores> Llenargrid()
        {
            var lista = new List<ModelProveedores>();

            var comando = new MySqlCommand("SELECT * FROM proveedores", ConexionMySql.ObtenerConexion());
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var pModelProveedores = new ModelProveedores
                {
                    IdProveedor = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Proveedor = reader.GetString(2),
                    Matricula = reader.GetString(3),
                    Rancho = reader.GetString(4),
                    NoPipa = reader.GetString(5)
                };
                lista.Add(pModelProveedores);
            }
            return lista;
        }

        public static List<ModelProveedores> Llenarcombo(string nombre)
        {
            var lista = new List<ModelProveedores>();
            MySqlCommand comando;

            // este if es para que con este mismo metodo rellene a los combo box 
            if (nombre == "Proveedor")
            {
                comando = new MySqlCommand("SELECT * FROM proveedores", ConexionMySql.ObtenerConexion());
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var pModelProveedores = new ModelProveedores
                    {
                        IdProveedor = reader.GetInt32(0),
                        Proveedor = reader.GetString(2)
                    };
                    lista.Add(pModelProveedores);
                }
            }
            else
            {
                comando = new MySqlCommand("SELECT * FROM ranchos", ConexionMySql.ObtenerConexion());
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var pModelProveedores = new ModelProveedores
                    {
                        IdRancho = reader.GetInt32(0),
                        Rancho = reader.GetString(1)
                    };
                    lista.Add(pModelProveedores);
                }
            }

            return lista;
        }

        //metodo para buscar
        public static List<ModelProveedores> Buscar(string pNombre)
        {
            var lista = new List<ModelProveedores>();

            //aca tendrias que cambiar la queri para que te busque por cualquiera de los 4 parametros

            var comando = new MySqlCommand($"SELECT * FROM proveedores WHERE NombreProveedor='{pNombre}'",
                ConexionMySql.ObtenerConexion());
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                var pModelProveedores = new ModelProveedores
                {
                    IdProveedor = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Proveedor = reader.GetString(2),
                    Matricula = reader.GetString(3),
                    Rancho = reader.GetString(4),
                    NoPipa = reader.GetString(5)
                };

                lista.Add(pModelProveedores);
            }
            return lista;
        }

        public static ModelProveedores ObtenerProveedor(int pidProveedor)
        {
            var pModelProveedores = new ModelProveedores();
            var connec = ConexionMySql.ObtenerConexion();

            var comando = new MySqlCommand($"SELECT * FROM proveedores WHERE idproveedores ='{pidProveedor}'", connec);
            var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                ProveedorSelec.IdProveedor = reader.GetInt32(0);
                ProveedorSelec.Nombre = reader.GetString(1);
                ProveedorSelec.Proveedor = reader.GetString(2);
                ProveedorSelec.Matricula = reader.GetString(3);
                ProveedorSelec.Rancho = reader.GetString(4);
                ProveedorSelec.NoPipa = reader.GetString(5);

            }
            connec.Close();
            return pModelProveedores;
        }

        //metodo para actualizar
        public static int Actualizar(ModelProveedores pModelProveedores)
        {
            var conexion = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand( $"UPDATE proveedores SET  NombreProveedor = '{pModelProveedores.Nombre}', Proveedor = '{pModelProveedores.Proveedor}', Matricula = '{pModelProveedores.Matricula}', NoPipa='{pModelProveedores.NoPipa}', Rancho='{pModelProveedores.Rancho}' WHERE idproveedores='{pModelProveedores.IdProveedor}'",conexion);
            var retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }

        //metodo para eliminar
        public static int Eliminar(int pidProveedor)
        {
            var conexion = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand($"DELETE FROM proveedores WHERE idproveedores='{pidProveedor}'", conexion);
            var retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }

        public static class ProveedorSelec
        {
            public static int IdProveedor { get; set; }
            public static string Nombre { get; set; }
            public static string Matricula { get; set; }
            public static string NoPipa { get; set; }
            public static string Proveedor { get; set; }
            public static string Rancho { get; set; }
        }


        public static void DisplayInExcell()
        {
            var datename = "Proveedores" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + ".xlsx";
            var path = @"C:\\Users\\Diego Maciel Acevedo\\Desktop\\ExcelCompra\\";

            if (!Directory.Exists(path)) //comprueba que exista la carpeta si no la crea
                Directory.CreateDirectory(path);

            path += datename; //se agrega el nombre del archivo para comprobar si existe y para crear el arhivo.

            if (File.Exists(path)) //comprueba si existe el archivo si exste lo elimina.
                File.Delete(path);

            var spreadsheetinfo = new FileInfo(path);
            var pck = new ExcelPackage(spreadsheetinfo);
            var spreadSheet = pck.Workbook.Worksheets.Add("proveedores");

            spreadSheet.Cells["A1"].Value = "idproveedores";
            spreadSheet.Cells["B1"].Value = "NombreProveedor";
            spreadSheet.Cells["C1"].Value = "Proveedor";
            spreadSheet.Cells["D1"].Value = "Matricula";
            spreadSheet.Cells["E1"].Value = "Rancho";
            spreadSheet.Cells["F1"].Value = "NoPipa";
            spreadSheet.Cells["A1:F1"].Style.Font.Bold = true;

            var connec = ConexionMySql.ObtenerConexion();
            var comando = new MySqlCommand("SELECT * FROM proveedores", connec);
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

                currentRow++;
            }

            pck.SaveAs(spreadsheetinfo);
        }
    }
}