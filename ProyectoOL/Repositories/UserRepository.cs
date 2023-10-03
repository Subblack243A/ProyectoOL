using ProyectoOL.Models;
using ProyectoOL.Utilities;
using System.Data.SqlClient;


namespace ProyectoOL.Repositories
{
    public class UserRepository
    {
        public bool CreateUser(UserModel user) 
        {
            bool result = false;
            DBContextUtility Connection = new DBContextUtility();
            Connection.Connect();
            //consulta SQL
            string SQL = "INSERT INTO OLDB.dbo.[USUARIO] (FK_ESTADO,ID_USUARIO,NOMBRE_USUARIO,FK_TIPO_DOCUMENTO,FK_TIPO_USUARIO,NOMBRE,APELLIDO,CORREO_ELECTRONICO,CONTRASENA) "
                + "VALUES (" + 1 + "," + user.Id_Usuario + ",'" + user.Nombre_Usuario + "'," + user.Tipo_Documento + "," + user.Tipo_Usuario + ",'"
                + user.Nombre + "','" + user.Apellido + "','" + user.Correo_Electronico + "','" + user.Contrasena + "');";

            using (SqlCommand command = new SqlCommand(SQL, Connection.CONN()))
            {
                int comando = command.ExecuteNonQuery();
                
                if (comando == 1) 
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            Connection.Disconnect();
            return result;
        }
    }
}