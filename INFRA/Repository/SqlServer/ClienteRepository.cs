using BaseApiAdoUow.CORE.Models;
using BaseApiAdoUow.INFRA.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApiAdoUow.INFRA.Repository.SqlServer
{
    public class ClienteRepository : Repository, IClienteRepository
    {
        public ClienteRepository(SqlConnection context, SqlTransaction transaction)
        {
            this.sqlConnection = context;
            this.sqlTransaction = transaction;
        }
        public bool Create(Cliente model)
        {
            var query = "insert into Cliente(Nome, Endereco, Telefone, Email) output INSERTED.ID values (@Nome, @Endereco, @Telefone, @Email)";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@Id", model.Id);
            command.Parameters.AddWithValue("@Nome", model.Nome);
            command.Parameters.AddWithValue("@Endereco", model.Endereco);
            command.Parameters.AddWithValue("@Telefone", model.Telefone);
            command.Parameters.AddWithValue("@Email", model.Email);

            model.Id = Convert.ToInt32(command.ExecuteScalar());

            return model.Id > 0;
        }

        public bool Remove(int Id)
        {
            var command = CreateCommand("DELETE FROM Cliente WHERE Id = @Id");
            command.Parameters.AddWithValue("@Id", Id);

            int result = command.ExecuteNonQuery();

            return result > 0;
        }

        public Cliente Get(int Id)
        {
            var command = CreateCommand("SELECT * FROM Cliente WITH(NOLOCK) WHERE Id = @Id");
            command.Parameters.AddWithValue("@Id", Id);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                return new Cliente
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nome = Convert.ToString(reader["Nome"]),
                    Endereco = Convert.ToString(reader["Endereco"]),
                    Telefone = Convert.ToString(reader["Telefone"]),
                    Email = Convert.ToString(reader["Email"])
                };
            };
        }

        public IEnumerable<Cliente> GetAll()
        {
            var result = new List<Cliente>();

            var command = CreateCommand("SELECT * FROM Cliente WITH(NOLOCK)");

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Cliente
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nome = Convert.ToString(reader["Nome"]),
                        Endereco = Convert.ToString(reader["Endereco"]),
                        Telefone = Convert.ToString(reader["Telefone"]),
                        Email = Convert.ToString(reader["Email"])
                    });
                }
            }

            return result;
        }

        public bool Update(Cliente model)
        {
            var query = "update Cliente set Nome = @Nome, Nome = @Nome, Endereco = @Endereco, Telefone = @Telefone, Email = @Email WHERE Id = @Id";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@Id", model.Id);
            command.Parameters.AddWithValue("@Nome", model.Nome);
            command.Parameters.AddWithValue("@Endereco", model.Endereco);
            command.Parameters.AddWithValue("@Telefone", model.Telefone);
            command.Parameters.AddWithValue("@Email", model.Email);

            int result = command.ExecuteNonQuery();

            return result > 0;
        }
    }
}
