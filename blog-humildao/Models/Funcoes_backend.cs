using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace blog_humildao.Models
{
    public static class Funcoes_backend
    {
        private static MySQL mysql = new MySQL();
        public static Boolean checar_login(string nome, string hash_senha)
        {
            string nomeScaped = MySqlHelper.EscapeString(nome);
            string selectUsuario = "select hash_senha,salt_senha from usuarios where login = '" + nomeScaped + "' limit 1";
            IList<IDictionary<string, string>> query = mysql.selectQuery(selectUsuario);
            string hashSenha = query[0]["hash_senha"];
            string saltSenha = query[0]["salt_senha"];
            if (Hash(nome + saltSenha) == hash_senha) return true;
            else return false;
        }
        public static string Hash(string str) //método para criar Hashs SHA1 de forma mais simples.
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}