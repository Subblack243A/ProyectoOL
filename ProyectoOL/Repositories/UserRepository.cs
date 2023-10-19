using ProyectoOL.Models;
using ProyectoOL.Utilities;
using System.Data.SqlClient;


namespace ProyectoOL.Repositories
{
    public class UserRepository
    {
        public int CreateUser(UserDto user) 
        {
            int comando = 0;
            DBContextUtility Connection = new DBContextUtility();
            Connection.Connect();
            //consulta SQL
            string SQL = "INSERT INTO OLDB.dbo.[USUARIO] (FK_ESTADO,ID_USUARIO,NOMBRE_USUARIO,FK_TIPO_DOCUMENTO,FK_TIPO_USUARIO,NOMBRE,APELLIDO,CORREO_ELECTRONICO,CONTRASENA) "
                + "VALUES (" + 1 + "," + user.Id_Usuario + ",'" + user.Nombre_Usuario + "'," + user.Tipo_Documento + "," + user.Tipo_Usuario + ",'"
                + user.Nombre + "','" + user.Apellido + "','" + user.Correo_Electronico + "','" + user.Contrasena + "');";

            using (SqlCommand command = new SqlCommand(SQL, Connection.CONN()))
            {
                comando = command.ExecuteNonQuery();
            }
            Connection.Disconnect();
            return comando;
        }

        public UserDto Login(UserDto user)
        {
            UserDto userResult = new UserDto();

            //Consulta SQL
            string SQL = "SELECT NOMBRE_USUARIO, CONTRASENA FROM OLDB.dbo.[USUARIO] WHERE NOMBRE_USUARIO = '"+user.Nombre_Usuario+"' AND CONTRASENA = '" + user.Contrasena+"';";
            DBContextUtility Connection = new DBContextUtility();
            Connection.Connect();
            using(SqlCommand command = new SqlCommand(SQL,Connection.CONN()))
            {
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        userResult.Contrasena = reader.GetString(1);
                        userResult.Nombre_Usuario = reader.GetString(0);
                    }
                }
            }
            Connection.Disconnect();
            return userResult;
        }
    }
}