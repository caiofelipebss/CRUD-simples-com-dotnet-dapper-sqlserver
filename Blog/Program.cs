using System;
using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    public class Program
    {
        private const string CONNECTION_STRING = @"Server=CAIO-PC\SQLEXPRESS;Database=Blog;user id=sa;password=123456;Encrypt=False;";
        static void Main(string[] args)
        {
            //CRUD

            //CreateUser();
            //ReadUser();
            //UpdateUser();
            DeleteUser();
        }


        public static void ReadUsers()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var users = connection.GetAll<User>(); //Escreve a sintaxe SQL automaticamente, aqui listamos todos os usuários

                foreach (var user in users)
                {
                    Console.WriteLine(user.Name);
                    Console.WriteLine(user.Email);
                }
            }
        }

        public static void ReadUser()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(1); //Escreve a sintaxe SQL automaticamente, aqui listamos UM usuário

                Console.WriteLine(user.Name);
                Console.WriteLine(user.Email);
            }
        }

        public static void CreateUser()
        {
            var user = new User()
            {
                Bio = "Equipe Só Lobby",
                Email = "slb@slb.com",
                Image = "https://....",
                Name = "Equipe Só Lobby",
                PasswordHash = "HASH",
                Slug = "equipe-slb"
            };

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Insert<User>(user); // insere no banco de dados
                Console.WriteLine("Cadastro realizado com sucesso");                
            }
        }

        public static void UpdateUser()
        {
            var user = new User()
            {
                Id = 2,
                Bio = "Equipe Só Lobby - SLB",
                Email = "slb@slb.com.br",
                Image = "https://....",
                Name = "Equipe Só Lobby",
                PasswordHash = "HASH",
                Slug = "equipe-slb"
            };

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Update<User>(user); 
                Console.WriteLine("Cadastro atualizado com sucesso");
            }
        }

        public static void DeleteUser()
        {
            
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(2);
                connection.Delete<User>(user);
                Console.WriteLine("Exclusão realizada com sucesso");
            }
        }
    }
}
