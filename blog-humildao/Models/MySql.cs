﻿/* Objetivo:
 *      Deixar mais simples o uso das query's MySQL
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace blog_humildao.Models{
    public class MySQL{
        private string connectionString = ConfigurationManager.ConnectionStrings["mysql-connection"].ConnectionString;
        MySqlConnection connection ;
        public MySQL(){
            this.connection = new MySqlConnection(connectionString);
        }
        public IList<IDictionary<string, string>> selectQuery(string query){
            using (var command = connection.CreateCommand()){
                IList<IDictionary<string, string>> rows = new List<IDictionary<string, string>>();
                connection.Open();
                command.CommandText = query;
                using (var reader = command.ExecuteReader()) { 
                    while (reader.Read()){
                        IDictionary<string, string> elementos = new Dictionary<string, string>();
                        for (int i = 0; i < reader.FieldCount; i++){
                            string key = reader.GetName(i);
                            string value = reader.GetString(i);
                            elementos.Add(key, value);
                        }
                        rows.Add(elementos);
                        
                    }
                    connection.Close();
                    return rows;
                }
            }
        }
        public Boolean checarExistenciaUsuario(string usuario)
        {
            string usuarioEscaped = MySqlHelper.EscapeString(usuario);
            IList<IDictionary<string, string>> selectUsuario = this.selectQuery("select login, email from usuarios where login = '"+usuarioEscaped+"'");
            if (selectUsuario.Count == 0) return false;
            else return true;
        }
        public Boolean checarExistenciaEmail(string email)
        {
            string emailEscaped = MySqlHelper.EscapeString(email);
            IList<IDictionary<string, string>> selectUsuario = this.selectQuery("select login, email from usuarios where email = '" + emailEscaped + "'");
            if (selectUsuario.Count == 0) return false;
            else return true;
        }
    }
}