using ProyectoOL.Dto;
using ProyectoOL.Repositories;


namespace ProyectoOL.Services
{
    public class UserService
    {
        public bool CreateUser(UserDto user)
        {
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