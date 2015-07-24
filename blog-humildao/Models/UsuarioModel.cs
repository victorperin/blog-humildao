using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blog_humildao.Models
{
    public class UsuarioModel
    {
        public string id { get; set; }
        public string login { get; set; }
        public string nomeExibicao { get; set; }
        public string email { get; set; }
        public string admin { get; set; }
        public string hashSenha { get; set; }
        public string saltSenha { get; set; }
    }
}