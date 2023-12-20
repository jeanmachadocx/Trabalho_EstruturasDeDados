using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {   
            Vestibular v = new Vestibular(null, null, 0, 0);
            
            v.LerEntrada(@"C:\\AED\\TrabalhoAED\\entrada.txt");

            v.CalcularClassificacao();

            v.EscreverSaida(@"C:\\AED\\TrabalhoAED\\saida.txt");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("Arquivo não encontrado: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro: " + ex.Message);
        }
        Console.WriteLine("Funcionou");
        Console.ReadLine();
    }
}
