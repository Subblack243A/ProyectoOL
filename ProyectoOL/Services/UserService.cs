using ProyectoOL.Dto;
using ProyectoOL.Repositories;


namespace ProyectoOL.Services
{
    public class UserService
    {
        public UserDto CreateUser(UserDto user)
        {
            EncryptUtility encryptUtility = new EncryptUtility();
            user.Contrasena = encryptUtility.Encrypt(user.Contrasena);
            user.KeySafe = encryptUtility.GetKeySafe();
            user.Iv = encryptUtility.GetIv();            
            UserRepository userRepository = new UserRepository();
            int result = userRepository.CreateUser(user);

            if(result == 1)
            {
                return user;
            }
            else
            {
                return CleanUser(user);
            }
        }

        public UserDto CleanUser(UserDto user)
        {
            user.Id_Usuario = -1;
            user.Nombre_Usuario = null;
            user.Tipo_Usuario = 0;
            user.Tipo_Documento = 0;
            user.Nombre = null;
            user.Apellido = null;
            user.Correo_Electronico = null;
            user.KeySafe = null;
            user.Iv = null;
            user.Contrasena = null;
            user.Estado = 0;
            return user;
        }

        public UserDto InicioSesion(UserDto userModel)
        {
            UserRepository userRepository = new UserRepository();
            UserDto userResponse = userRepository.Login(userModel);
            if (userResponse.Id_Usuario != 0)
            {
                userResponse.Message = "Successful Login";
            }
            else
            {
                userResponse.Message = "Error Inicio de Sesion, Usuario o Contraseña Incorrecctos";
            }
            return userResponse;
        }
    }
}