using System;

namespace Entity
{
    public class Cliente
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public double CapitalInicialDeCredito { get; set; }
        public double TasaDeInteresCompuesto { get; set; }
        public double TiempoDeDuracionDelCredito { get; set; }
        public double ValorTotalAPagar { get; set; }
        public double n { get; set; }
        public double i { get; set; }

        public void CalcularCapitalFinal()
        {
            n = (TiempoDeDuracionDelCredito/12);
            i = (TasaDeInteresCompuesto/100);

            ValorTotalAPagar = CapitalInicialDeCredito * Math.Pow((1+i),n); ;

        }

    }
}
