using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;
        public Numero()
        {
            this.numero = 0;
        }
        public Numero(double num)
        {
            this.numero = num;
        }
        public Numero(string strNum)
        {
            this.SetNumero = strNum;
        }
        private string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }
        }
        private double ValidarNumero(string strNumero)
        {
            double ret;
            return (double.TryParse(strNumero, out ret) ? ret : 0);
        }
        public string BinarioDecimal(string binario)
        {
            foreach (var c in binario)
            {
                if (c != '0' && c != '1')
                {
                    return "Valor invalido";
                }
            }
            return Convert.ToInt64(binario, 2).ToString();
        }
        public string DecimalBinario(double numero)
        {
            return DecimalBinario(numero.ToString());
        }

        public string DecimalBinario(string numero)
        {
            if (ValidarNumero(numero) > 0)
            {
                double numeroD = double.Parse(numero);
                string binario = "";
                if (numeroD > 0)
                {
                    while (numeroD > 0)
                    {
                        if (numeroD % 2 == 0)
                        {
                            binario = "0" + binario;
                        }
                        else
                        {
                            binario = "1" + binario;
                        }
                        numeroD = (int)(numeroD / 2);
                    }
                }
                else
                {
                    if (numeroD == 0)
                    {
                        binario = "0";
                    }
                }
                return binario;
            }
            else
            {
                return "Valor Invalido";
            }
        }
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            return (n2.numero!=0?n1.numero / n2.numero:double.MinValue);
        }
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

    }
}
