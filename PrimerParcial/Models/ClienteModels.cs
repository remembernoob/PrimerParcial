using Entity;

namespace PrimerParcial.Models
{
    public class ClienteInputModel
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public double CapitalInicialDeCredito { get; set; }
        public double TasaDeInteresCompuesto { get; set; }
        public double TiempoDeDuracionDelCredito { get; set; }
    }


    public class ClienteViewModel : ClienteInputModel
    {
        public ClienteViewModel()
        {  
        }
        public ClienteViewModel(Cliente cliente)
        {
            Identificacion = cliente.Identificacion;
            Nombre = cliente.Nombre;
            CapitalInicialDeCredito = cliente.CapitalInicialDeCredito;
            TasaDeInteresCompuesto = cliente.TasaDeInteresCompuesto;
            TiempoDeDuracionDelCredito = cliente.TiempoDeDuracionDelCredito;
            ValorTotalAPagar = cliente.ValorTotalAPagar;
        }
        public double ValorTotalAPagar { get; set; }
    }

}