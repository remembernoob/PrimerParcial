using Entity;
using System;
using System.Collections.Generic;
using Datos;

namespace Logica
{
    public class ClienteService
    {
        private readonly ConnectionManager _conexion;
        private readonly ClienteRepository _repositorio;

        public ClienteService(string connectionString)
        {
            _conexion = new ConnectionManager(connectionString);
            _repositorio = new ClienteRepository(_conexion);
        }

        public GuardarResponse Guardar(Cliente cliente)
        {
            try
            {
                cliente.CalcularCapitalFinal();
                _conexion.Open();
                _repositorio.Guardar(cliente);
                _conexion.Close();
                return new GuardarResponse(cliente);
            }
            catch (Exception e)
            {
                return new GuardarResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
        }

        public List<Cliente> ConsultarTodos()
        {
            _conexion.Open();
            List<Cliente> clientes = _repositorio.ConsultarTodos();
            _conexion.Close();
            return clientes;
        }

    }

    public class GuardarResponse
    {
        public GuardarResponse(Cliente cliente)
        {
            Error = false;
            Cliente = cliente;
        }
        public GuardarResponse(string mensaje)
        {      
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Cliente Cliente { get; set; }
    }

    
}
