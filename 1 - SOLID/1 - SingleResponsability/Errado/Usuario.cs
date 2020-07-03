using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsability.Errado
{
    public class Usuario
    {
        public int CodigoUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string ChaveAmericas { get; set; }
        public DateTime DataCadastro { get; set; }

        public string AdicionarUsuario()
        {
            if (Email.Contains("@"))
                return "Usuário com e-mail inválido!";

            if (string.IsNullOrWhiteSpace(ChaveAmericas) && ChaveAmericas.Length <= 10)
                return "Chave americas inválida";

            using (var conn = new SqlConnection("Conexao"))
            {
                var command = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText = "INSERT INTO Usuario (Nome, Email, ChaveAmericas, DataCadastro) Values (@nome, @email, @chaveAmericas, @dataCadastro)"
                };

                command.Parameters.AddWithValue("nome", Nome);
                command.Parameters.AddWithValue("email", Email);
                command.Parameters.AddWithValue("chaveAmericas", ChaveAmericas);
                command.Parameters.AddWithValue("dataCadastro", DataCadastro);

                conn.Open();
                command.ExecuteNonQuery();
            }

            var mail = new MailMessage("empresa@empresa.com", Email);
            var client = new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.google.com"
            };

            mail.Subject = "Bem Vindo.";
            mail.Body = "Parabéns! Você está cadastrado.";
            client.Send(mail);

            return "Usuário cadastrado com sucesso!";
        }
    }
}
