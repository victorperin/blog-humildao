using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blog_humildao.Models{
    public static class IndexModel{
        private static MySQL mysql = new MySQL();
        public static IList<Post> getAllPosts(){
            IList<Post> posts = new List<Post>();
            string selectPosts = "select posts.id,usuarios.nome_exibicao,posts.data,posts.titulo,posts.conteudo from posts left join usuarios on posts.id_usuario = usuarios.id";
            IList<IDictionary<string, string>> query = mysql.selectQuery(selectPosts);
            for (int x = 0; x < query.Count; x++){
                List<string> categoriasDoPost = getCategoriasPost(int.Parse(query[x]["id"]));
                posts.Add(new Post
                {
                    id = int.Parse(query[x]["id"]),
                    usuario = query[x]["nome_exibicao"],
                    data = DateTime.Parse(query[x]["data"]),
                    titulo = query[x]["titulo"],
                    conteudo = query[x]["conteudo"],
                    categorias = categoriasDoPost
                });
            
            }
            return posts;
        }
        public static List<string> getCategoriasPost(int idPost){
            List<string> categoriasDoPost = new List<string>();
            string selectCategorias = "select categorias.nome from posts_categorias left join categorias on posts_categorias.id_categoria = categorias.id where posts_categorias.id_post =" + idPost;
            IList<IDictionary<string, string>> queryCategorias = mysql.selectQuery(selectCategorias);
            for (int y = 0; y < queryCategorias.Count; y++){
                categoriasDoPost.Add(queryCategorias[y]["nome"]);
            }
            return categoriasDoPost;
                        
        }
    }
}