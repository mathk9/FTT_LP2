using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            string cpf;
            string novoCpf;
            bool resposta = false;
            int soma = 0;
            int digito1, digito2;
            int resultado;
            int multiplicador;

            Console.WriteLine("Digite um CPF:");
            cpf = Console.ReadLine();
            cpf = cpf.Replace(".", "");
            cpf = cpf.Replace("-", "");

            if (cpf.Length != 11)
            {
                Console.WriteLine("Erro no cpf.");
                return;
            }

            #region cálculo do primeiro dígito

            multiplicador = 10;
            for (int i = 0; i < 9; i++)
            {
                soma = soma + (Convert.ToInt32(cpf[i].ToString()) * multiplicador);
                multiplicador--;
            }

            resultado = soma % 11;

            if (resultado == 0 || resultado == 1)
                digito1 = 0;
            else
            {
                digito1 = 11 - resultado;
            }

            Console.WriteLine("Primeiro dígito: {0}", digito1);

            #endregion


            #region cálculo do segundo dígito
            soma = 0;
            multiplicador = 11;
            for (int i = 0; i < 9; i++)
            {
                soma = soma + (Convert.ToInt32(cpf[i].ToString()) * multiplicador);
                multiplicador--;
            }

            soma += digito1 * 2;

            resultado = soma % 11;

            if (resultado == 0 || resultado == 1)
                digito2 = 0;
            else
            {
                digito2 = 11 - resultado;
            }

            Console.WriteLine($"Segundo dígito: {digito2}");


            #endregion


            if (cpf[9].ToString() == digito1.ToString() &&
                cpf[10].ToString() == digito2.ToString())
                resposta = true;
            else
                resposta = false;

            Console.WriteLine("O CPF é " + resposta);
            Console.ReadKey();
        }
    }
}
