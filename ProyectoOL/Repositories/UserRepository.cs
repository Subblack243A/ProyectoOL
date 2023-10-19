using ProyectoOL.Dto;
using ProyectoOL.Utilities;
using System.Data.SqlClient;
using ProyectoOL.Repositories.Models;
using System.Linq;


namespace ProyectoOL.Repositories
{
    public class UserRepository
    {
        public int CreateUser(UserDto user) 
        {
            Encrypt enc = new Encrypt();
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
            /*string SQL = "SELECT NOMBRE_USUARIO, CONTRASENA FROM OLDB.dbo.[USUARIO] WHERE NOMBRE_USUARIO = '"+user.Nombre_Usuario+"' AND CONTRASENA = '" + user.Contrasena+"';";
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
            Connection.Disconnect();*/

            var TUser = new USUARIO();
            using (OLDBEntities1 db = new OLDBEntities1())
            {
                TUser = (from d in db.USUARIOs 
                where d.NOMBRE_USUARIO == user.Nombre_Usuario && d.CONTRASENA == user.Contrasena
                select d).FirstOrDefault();
            }
            if(TUser != null)
            {
                userResult.Id_Usuario = TUser.ID_USUARIO;
                userResult.Tipo_Usuario = TUser.FK_TIPO_USUARIO;
                userResult.Estado = TUser.FK_ESTADO;
                userResult.Nombre = TUser.NOMBRE;
                userResult.Apellido = TUser.APELLIDO;
                userResult.Nombre_Usuario = TUser.NOMBRE_USUARIO;
                userResult.Contrasena = TUser.CONTRASENA;
                userResult.Correo_Electronico = TUser.CORREO_ELECTRONICO;
                userResult.Tipo_Documento = TUser.FK_TIPO_DOCUMENTO;
            }
            

            return userResult;
        }
    }
}