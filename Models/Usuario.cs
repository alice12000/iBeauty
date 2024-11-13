using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBeauty.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Usuario(int id, string email, string senha) 
        {
            Id = id;
            Email = email;
            Senha = senha;
        }
    }
}
