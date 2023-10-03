using ProyectoOL.Models;
using ProyectoOL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ProyectoOL.Services
{
    public class UserService
    {
        public bool CreateUser(UserModel user)
        {
            UserRepository userRepository = new UserRepository();
            return userRepository.CreateUser(user);
        }
    }
}