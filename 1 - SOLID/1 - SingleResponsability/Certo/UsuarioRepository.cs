using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsability.Certo
{
    public class UsuarioRepository
    {
        public void Adicionar(Usuario usuario)
        {
            using (var conn = new SqlConnection("Conexao"))
            {
                var command = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.Text,
                    CommandText = "INSERT INTO Usuario (Nome, Email, ChaveAmericas, DataCadastro) Values (@nome, @email, @chaveAmericas, @dataCadastro)"
                };

                command.Parameters.AddWithValue("nome", usuario.Nome);
                command.Parameters.AddWithValue("email", usuario.Email);
                command.Parameters.AddWithValue("chaveAmericas", usuario.ChaveAmericas);
                command.Parameters.AddWithValue("dataCadastro", usuario.DataCadastro);

                conn.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
