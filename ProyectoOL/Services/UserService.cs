using ProyectoOL.Dto;
using ProyectoOL.Repositories;


namespace ProyectoOL.Services
{
    public class UserService
    {
        public bool CreateUser(UserDto user)
        {
            EncryptUtility encryptUtility = new EncryptUtility();
            user.Contrasena = encryptUtility.Encrypt(user.Contrasena);
            user.KeySafe = encryptUtility.GetKeySafe();
            user.Iv = encryptUtility.GetIv();            
            UserRepository userRepository = new UserRepository();
            int result = userRepository.CreateUser(user);

            if(result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
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