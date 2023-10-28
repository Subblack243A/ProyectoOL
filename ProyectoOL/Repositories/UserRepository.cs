using ProyectoOL.Dto;
using ProyectoOL.Utilities;
using System.Data.SqlClient;
using ProyectoOL.Repositories.Models;
using System.Linq;
using System;

namespace ProyectoOL.Repositories
{
    public class UserRepository
    {
        public int CreateUser(UserDto user) 
        {
            try
            {
                using (OLDBEntities db = new OLDBEntities())
                {
                    var userVal = db.USUARIOs.FirstOrDefault(f => f.NOMBRE_USUARIO == user.Nombre_Usuario);
                    if (userVal != null)
                    {
                        return 0;
                    }
                    else
                    {
                        USUARIO tUser = new USUARIO
                        {
                            FK_ESTADO = 2,
                            ID_USUARIO = user.Id_Usuario,
                            NOMBRE_USUARIO = user.Nombre_Usuario,
                            FK_TIPO_DOCUMENTO = user.Tipo_Documento,
                            FK_TIPO_USUARIO = 3,
                            NOMBRE = user.Nombre,
                            APELLIDO = user.Apellido,
                            CORREO_ELECTRONICO = user.Correo_Electronico,
                            CONTRASENA = user.Contrasena
                        };
                        db.USUARIOs.Add(tUser);
                        db.SaveChanges();
                        return 1;
                    }
                }
            }
            catch (Exception e)
            {
                var mensaje = e.InnerException;
                return 0;
            }
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
            using (OLDBEntities db = new OLDBEntities())
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