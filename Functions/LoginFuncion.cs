using DS_System.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DS_System.Functions
{
    public class LoginFuncion
    {
        public static bool ValidarLogin(Usuarios usuario)
        {
            bool respuesta = false;
            if (usuario.Email.Equals("onlydan") && usuario.Password.Equals("150921"))
            {
                respuesta = true;
            }
            return respuesta;
        }
    }
}