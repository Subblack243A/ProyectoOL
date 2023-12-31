﻿using ProyectoOL.Dto;
using ProyectoOL.Repositories.Models;
using System.Linq;
using System;
using System.Web.Mvc;
using System.Data.Entity;


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
                    var userVal = db.USUARIO.FirstOrDefault(f => f.NOMBRE_USUARIO == user.Nombre_Usuario);
                    if (user.Message.Equals("1") || user.Message.Equals("2"))
                    {


                        if (user.Tipo_Usuario == 0)
                        {
                            user.Tipo_Usuario = 2;
                        }
                        if (user.Message.Equals("1"))
                        {
                            var valUser = db.USUARIO.FirstOrDefault(f => f.ID_USUARIO == user.Id_Usuario);

                            valUser.FK_ESTADO = 2;
                            valUser.ID_USUARIO = user.Id_Usuario;
                            valUser.NOMBRE_USUARIO = user.Nombre_Usuario;
                            valUser.FK_TIPO_USUARIO = user.Tipo_Usuario;
                            valUser.NOMBRE = user.Nombre;
                            valUser.APELLIDO = user.Apellido;
                            valUser.CORREO_ELECTRONICO = user.Correo_Electronico;

                            db.Entry(valUser).State = EntityState.Modified;

                            db.SaveChanges();
                        }
                        else
                        {
                            var valUser = db.USUARIO.FirstOrDefault(f => f.ID_USUARIO == user.Id_Usuario);

                            valUser.FK_ESTADO = 2;
                            valUser.NOMBRE_USUARIO = user.Nombre_Usuario;
                            valUser.FK_TIPO_USUARIO = user.Tipo_Usuario;
                            valUser.NOMBRE = user.Nombre;
                            valUser.APELLIDO = user.Apellido;
                            valUser.CORREO_ELECTRONICO = user.Correo_Electronico;

                            var valPan = db.PANTALLA.FirstOrDefault(f => f.FK_USUARIO == user.Id_Usuario);

                            valPan.PANTALLA1 = user.KeySafe;
                            valPan.MONITOR = user.Iv;

                            db.Entry(valPan).State = EntityState.Modified;
                            db.Entry(valUser).State = EntityState.Modified;
                            db.SaveChanges();
                        }

                    }
                    else
                    {
                        if (userVal != null)
                        {
                            return 0;
                        }
                        else
                        {
                            if (user.Tipo_Usuario == 0)
                            {
                                user.Tipo_Usuario = 2;
                            }
                            if (user.Message.Equals("1"))
                            {
                                USUARIO tUser = new USUARIO
                                {
                                    FK_ESTADO = 2,
                                    ID_USUARIO = user.Id_Usuario,
                                    NOMBRE_USUARIO = user.Nombre_Usuario,
                                    FK_TIPO_DOCUMENTO = user.Tipo_Documento,
                                    FK_TIPO_USUARIO = user.Tipo_Usuario,
                                    NOMBRE = user.Nombre,
                                    APELLIDO = user.Apellido,
                                    CORREO_ELECTRONICO = user.Correo_Electronico
                                };
                                db.USUARIO.Add(tUser);
                                db.SaveChanges();
                            }
                            else
                            {
                                USUARIO tUser = new USUARIO
                                {
                                    FK_ESTADO = 2,
                                    ID_USUARIO = user.Id_Usuario,
                                    NOMBRE_USUARIO = user.Nombre_Usuario,
                                    FK_TIPO_DOCUMENTO = user.Tipo_Documento,
                                    FK_TIPO_USUARIO = user.Tipo_Usuario,
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
                                db.USUARIO.Add(tUser);
                                db.PANTALLA.Add(tPantalla);
                                db.SaveChanges();
                            }
                        }

                    }
                    return 1;
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

            using(OLDBEntities db = new OLDBEntities())
            {
                TUsuario = (from u in db.USUARIO
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
            using (OLDBEntities db = new OLDBEntities())
            {
                TUsuario = (from d in db.USUARIO
                            where d.NOMBRE_USUARIO == user.Nombre_Usuario
                            select d).FirstOrDefault();
            }
            if (TUsuario != null)
            {
                usuario.Id_Usuario = TUsuario.ID_USUARIO;
            }
            using (OLDBEntities db = new OLDBEntities())
            {
                TPantalla = (from p in db.PANTALLA
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