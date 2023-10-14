using ProyectoOL.Models;
using ProyectoOL.Repositories;


namespace ProyectoOL.Services
{
    public class UserService
    {
        public bool CreateUser(UserModel user)
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

        public UserModel InicioSesion(UserModel userModel)
        {
            UserRepository userRepository = new UserRepository();
            UserModel userResponse = userRepository.Login(userModel);
            if(userResponse.Id_Usuario != 0) 
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