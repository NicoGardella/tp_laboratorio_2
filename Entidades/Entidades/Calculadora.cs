using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        private string ValidarOperador(string operador)
        {
            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
                operador = "+";
            return operador;
        }
        public double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado=0;
            switch (ValidarOperador(operador))
            {
                 case "+": resultado = num1 + num2; break;
                case "-": resultado = num1 - num2; break;
                case "*": resultado = num1 * num2; break;
                case "/": resultado = num1 / num2; break;
            }
            return resultado;
        }
    }
}
