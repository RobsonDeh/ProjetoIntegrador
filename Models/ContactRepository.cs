using System;
using MySqlConnector;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ProjetoInt03_Robson.Models;

namespace ProjetoInt03_Robson.Models
{
    public class ContactRepository
    {
        private const string DadosConexao = "Database=Afrika ;Data Source=localhost;User Id=root;";

        public void TestarConexao()
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            Console.WriteLine("Banco de dados funcionando");
            Conexao.Close();
        }

        
        public void inserir(Contact novoUser)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query ="INSERT INTO Contato(Nome,Telefone,Cidade,Pergunta) VALUES (@Nome,@Telefone,@Cidade,@Pergunta)";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            
        
            Comando.Parameters.AddWithValue("@Nome", novoUser.Nome);
            Comando.Parameters.AddWithValue("@Telefone", novoUser.Telefone);
            Comando.Parameters.AddWithValue("@Cidade", novoUser.Cidade);
            Comando.Parameters.AddWithValue("@Pergunta", novoUser.Pergunta);

            Comando.ExecuteNonQuery();

            Conexao.Close();
        }
         
    
        

        
    }
}
