using ProyectoOL.Dto;
using ProyectoOL.Repositories.Models;
using System.Linq;
using System;
using System.Drawing;
using System.Web.UI.WebControls;

namespace ProyectoOL.Repositories
{
    public class UserRepository
    {
        public int CreateUser(UserDto user) 
        {
            try
            {
                using (OLDBEntities1 db = new OLDBEntities1())
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
                        PANTALLA tPantalla = new PANTALLA
                        {
                            FK_USUARIO = user.Id_Usuario,
                            PANTALLA1 = user.KeySafe,
                            MONITOR = user.Iv
                        };
                        db.USUARIOs.Add(tUser);
                        db.PANTALLAs.Add(tPantalla);
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
            user = Find(user);

            var TUsuario = new USUARIO();

            using(OLDBEntities1 db = new OLDBEntities1())
            {
                TUsuario = (from u in db.USUARIOs
                where u.NOMBRE_USUARIO == user.Nombre_Usuario && u.CONTRASENA == user.Contrasena
                select u).FirstOrDefault();
            } 
            
            if (TUsuario != null)
            {
                userResult.Id_Usuario = TUsuario.ID_USUARIO;
                userResult.Tipo_Usuario = TUsuario.FK_TIPO_USUARIO;
                userResult.Estado = TUsuario.FK_ESTADO;
                userResult.Nombre = TUsuario.NOMBRE;
                userResult.Apellido = TUsuario.APELLIDO;
                userResult.Nombre_Usuario = TUsuario.NOMBRE_USUARIO;
                userResult.Contrasena = TUsuario.CONTRASENA;
                userResult.Correo_Electronico = TUsuario.CORREO_ELECTRONICO;
                userResult.Tipo_Documento = TUsuario.FK_TIPO_DOCUMENTO;
            }
            return userResult;
        }

        public UserDto Find(UserDto user)
        {
            EncryptUtility encryptUtility = new EncryptUtility();
            UserDto usuario = new UserDto();
            var TUsuario = new USUARIO();
            var TPantalla = new PANTALLA();
            using (OLDBEntities1 db = new OLDBEntities1())
            {
                TUsuario = (from d in db.USUARIOs
                            where d.NOMBRE_USUARIO == user.Nombre_Usuario
                            select d).FirstOrDefault();
            }
            if (TUsuario != null)
            {
                usuario.Id_Usuario = TUsuario.ID_USUARIO;
            }
            using (OLDBEntities1 db = new OLDBEntities1())
            {
                TPantalla = (from p in db.PANTALLAs
                where p.FK_USUARIO == usuario.Id_Usuario
                select p).FirstOrDefault();
            }
            if (TPantalla != null)
            {
                user.KeySafe = TPantalla.PANTALLA1;
                user.Iv = TPantalla.MONITOR;
            }

            encryptUtility.SetKeySafe(user.KeySafe);
            encryptUtility.SetIv(user.Iv);
            user.Contrasena = encryptUtility.Decrypt(user.Contrasena);

            return user;
        }
    }
}