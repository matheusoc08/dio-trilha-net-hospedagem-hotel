using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioProjetoHospedagem.Models
{
    public class Menus
    {

        List<Pessoa> hospedes = new List<Pessoa>();
        Suite suite = new Suite(tipoSuite: "Premium", capacidade: 3, valorDiaria: 30);
        Reserva reserva = new Reserva();
        int quantidadePessoas = 0;

        public void cadastroHospede()
        {
            reserva.CadastrarSuite(suite);

            Console.WriteLine("==============================");
            Console.WriteLine("Bem-vindo ao nosso hotel!");
            Console.WriteLine($"Temos disponível a suíte {suite.TipoSuite} com capacidade para {suite.Capacidade} hospéde(s).");

            Console.WriteLine("\nGostaria de reservar quantos dias?");
            reserva.DiasReservados = Convert.ToInt32(Console.ReadLine());

            do
            {
                Console.WriteLine($"\nGostaria de fazer uma reserva para quantas pessoas? (Máximo {suite.Capacidade})");
                quantidadePessoas = Convert.ToInt32(Console.ReadLine());
            } while (quantidadePessoas > suite.Capacidade);

            while (hospedes.Count < quantidadePessoas)
            {
                Console.WriteLine("\nPor favor, informe o nome e sobrenome do hospéde:");
                Pessoa pessoa = new Pessoa();
                Console.Write("Primeiro nome: ");
                pessoa.Nome = Console.ReadLine();

                Console.Write("Sobrenome: ");
                pessoa.Sobrenome = Console.ReadLine();

                hospedes.Add(pessoa);
            }

            reserva.CadastrarHospedes(hospedes);

            Console.WriteLine("==============================");
        }

        public void recibo()
        {
            Console.Clear();

            Console.WriteLine("========== RECIBO ============");

            Console.WriteLine($"Suite: {suite.TipoSuite}");
            Console.WriteLine($"Hospedes: {reserva.ObterQuantidadeHospedes()}");

            foreach (Pessoa p in hospedes)
            {
                Console.WriteLine(p.NomeCompleto);
            }

            Console.WriteLine($"\nDias: {reserva.DiasReservados}");
            Console.WriteLine($"Valor diária: {suite.ValorDiaria}");
            Console.WriteLine("------------------------------");
            Console.Write($"{(reserva.DiasReservados >= 10 ? $"Desconto: {suite.ValorDiaria * reserva.DiasReservados * 0.10M}\n" : "")}");
            Console.WriteLine($"Total a pagar: {reserva.CalcularValorDiaria()}");
            Console.WriteLine("==============================");
        }
    }
}