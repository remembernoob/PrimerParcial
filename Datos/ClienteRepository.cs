using System.Collections.Generic;  
using System.Data.SqlClient;
using Entity;

namespace Datos
{
    public class ClienteRepository
    {
        private readonly SqlConnection _connection;
        private readonly List<Cliente> _clientes = new List<Cliente>();

        public ClienteRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }

        public void Guardar(Cliente cliente)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into cliente (Identificacion,Nombre,CapitalInicialDeCredito, TasaDeInteresCompuesto, TiempoDeDuracionDelCredito,ValorTotalAPagar)
                                                    values (@Identificacion,@Nombre,@CapitalInicialDeCredito,@TasaDeInteresCompuesto,@TiempoDeDuracionDelCredito,@ValorTotalAPagar)";
                command.Parameters.AddWithValue("@Identificacion", cliente.Identificacion);
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@CapitalInicialDeCredito", cliente.CapitalInicialDeCredito);
                command.Parameters.AddWithValue("@TasaDeInteresCompuesto", cliente.TasaDeInteresCompuesto);
                command.Parameters.AddWithValue("@TiempoDeDuracionDelCredito", cliente.TiempoDeDuracionDelCredito);
                command.Parameters.AddWithValue("@ValorTotalAPagar", cliente.ValorTotalAPagar);
                var filas = command.ExecuteNonQuery();
            }

        }

        public List<Cliente> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Cliente> clientes = new List<Cliente>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from cliente";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Cliente cliente = DataReaderMapToPerson(dataReader);
                        clientes.Add(cliente);
                    }
                }
            }
            return clientes;
        }

        private Cliente DataReaderMapToPerson(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
                Cliente cliente = new Cliente();
                cliente.Identificacion = (string)dataReader["Identificacion"];
                cliente.Nombre = (string)dataReader["Nombre"];
                cliente.CapitalInicialDeCredito = (double)dataReader["CapitalInicialDeCredito"];
                cliente.TasaDeInteresCompuesto = (double)dataReader["TasaDeInteresCompuesto"];
                cliente.TiempoDeDuracionDelCredito = (double)dataReader["TiempoDeDuracionDelCredito"];
                cliente.ValorTotalAPagar = (double)dataReader["ValorTotalAPagar"];
                return cliente;
        }
    }
}




