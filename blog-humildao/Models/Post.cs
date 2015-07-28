using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blog_humildao.Models
{
    public class Post
    {
        public int id;
        public string usuario;
        public List<string> categorias;
        public string titulo;
        public DateTime data;
        public string conteudo;
        public List<Comentario> comentarios;
    }
}