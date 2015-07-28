using MySql.Data.MySqlClient;
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
        public static Post getPost(int id)
        {
            MySQL mysql = new MySQL();
            string selectPost = "select posts.id,usuarios.nome_exibicao,posts.data,posts.titulo,posts.conteudo from posts left join usuarios on posts.id_usuario = usuarios.id where posts.id=" + id;
            IList<IDictionary<string, string>> query = mysql.selectQuery(selectPost);
            List<string> categoriasDoPost = getCategoriasPost(int.Parse(query[0]["id"]));
            int idPost = int.Parse(query[0]["id"]);
            Post post = new Post
            {
                id = idPost,
                usuario = query[0]["nome_exibicao"],
                data = DateTime.Parse(query[0]["data"]),
                titulo = query[0]["titulo"],
                conteudo = query[0]["conteudo"],
                categorias = categoriasDoPost,
                comentarios = getAllCommentariosAprovados(idPost)
            };
            return post;
        }
        public static List<Comentario> getAllCommentariosAprovados(int idPost)
        {
            List<Comentario> comentarios = new List<Comentario>();
            MySQL mysql = new MySQL();
            string selectComments = "select comentarios.id, usuarios.nome_exibicao, comentarios.conteudo, comentarios.status from comentarios";
            selectComments += " left join usuarios on comentarios.id_usuario = usuarios.id";
            selectComments += " where comentarios.status='aprovado' AND comentarios.id_post = " + idPost;
            IList<IDictionary<string, string>> query = mysql.selectQuery(selectComments);
            foreach (Dictionary<string, string> row in query)
            {
                comentarios.Add(new Comentario{
                    id=int.Parse(row["id"]),
                    nomeExibicaoUsuario=row["nome_exibicao"],
                    conteudo=row["conteudo"],
                    status=row["status"]
                });
            }
            return comentarios;
        }
        public static List<string> getCategorias()
        {
            MySQL mysql = new MySQL();
            List<string> categorias = new List<string>();
            IList<IDictionary<string, string>> selectCategorias = mysql.selectQuery("select nome from categorias");
            foreach (Dictionary<string, string> categoria in selectCategorias)
            {
                categorias.Add(categoria["nome"]);
            }

            return categorias;
        }
        public static IList<Post> getPostsCategoria(string categoria)
        {
            IList<Post> posts = new List<Post>();
            string categoriaEscaped = categoria;
            string selectPosts =  " SELECT posts.id,usuarios.nome_exibicao,posts.data,posts.titulo,posts.conteudo";
            selectPosts +=        " FROM posts";
            selectPosts +=        " LEFT JOIN usuarios ON posts.id_usuario = usuarios.id";
            selectPosts +=        " LEFT JOIN posts_categorias ON posts.id = posts_categorias.id_post";
            selectPosts +=        " LEFT JOIN categorias ON posts_categorias.id_categoria = categorias.id";
            selectPosts +=        " WHERE categorias.nome = '"+categoriaEscaped+"'";
            IList<IDictionary<string, string>> query = mysql.selectQuery(selectPosts);
            for (int x = 0; x < query.Count; x++)
            {
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
    }
}