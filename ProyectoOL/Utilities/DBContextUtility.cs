using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoOL.Utilities
{

    public class DBContextUtility
    {
        static string SERVER = "DESKTOP-4Q1DT86\\OPENLIBRARYDB";
        static string DB_NAME = "OLDB";
        static string DB_USER = "MUGEN";
        static string DB_PASSWORD = "N4ru70243A";

        static string Conn = "server=" + SERVER + ";database=" + DB_NAME + ";user=" + DB_USER + ";password=" + DB_PASSWORD + ";MultipleActiveResultSets=true";
        SqlConnection Con = new SqlConnection(Conn);

        //Procesimiento que abre la conexion sqlserver
        public void Connect()
        {
            try 
            { 
                Con.Open(); } catch (Exception ex){ Console.WriteLine(ex.Message); 
            }
        }

        public void Disconnect() 
        {
            Con.Close();
        }

        public SqlConnection CONN()
        {
            return Con;
        }
    }

}
