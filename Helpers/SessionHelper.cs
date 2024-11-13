using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;
using IBeauty.Helpers;
using IBeauty.Models;


//Nsssa classe, tem que usar as criadas em models
//Os models precisam ter get e set
namespace IBeauty.Helpers
{
    public class SessionHelper
    {
        private static SessionHelper _instance;
        private static Usuario _usuario = null;

        private SessionHelper() { }

        public static SessionHelper GetInstance()
        {
            if (_instance == null)
                _instance = new SessionHelper();

            return _instance;
        }

        public static bool Login(string usuario, string senha)
        {
            _ = GetInstance();

            if (_usuario != null)
                return true;

            var user = new UsuarioDAO().GetByUsuario(usuario);

            _usuario = user;

            return HashHelper.Compare(senha, user.Senha);
        }

        public static void Logout()
        {
            _usuario = null;
        }

        public static Usuario GetUsuario()
        {
            _ = GetInstance();

            return _usuario;
        }
    }
}
