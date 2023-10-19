using System;
using System.Data.SqlClient;
using System.Linq;


namespace ProyectoOL.Utilities
{

    public class DBContextUtility
    {
        static string SERVER = "JUAN\\OPENLIBRARYDB";
        static string DB_NAME = "OLDB";
        static string DB_USER = "MUGEN";
        static string DB_PASSWORD = "patas";

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
