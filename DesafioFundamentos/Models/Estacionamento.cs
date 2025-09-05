using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(placa))
            {
                // Converte a placa para maiúsculas e remove espaços em branco antes de adicionar
                string placaFormatada = placa.Trim().ToUpper();

                // Verifica se o veículo já está na lista
                if (veiculos.Contains(placaFormatada))
                {
                    Console.WriteLine("Este veículo já está estacionado. Verifique a placa.");
                }
                else
                {
                    veiculos.Add(placaFormatada);
                    Console.WriteLine($"Veículo {placaFormatada} estacionado com sucesso.");
                }
            }
            else
            {
                Console.WriteLine("Placa inválida. Tente novamente.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            // Converte a placa para maiúsculas para a busca
            string placaFormatada = placa.Trim().ToUpper();

            if (veiculos.Contains(placaFormatada))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                string inputHoras = Console.ReadLine();
                int horas;
                
                // Melhoria no TryParse para garantir um número inteiro e positivo
                if (int.TryParse(inputHoras, out horas) && horas > 0)
                {
                    decimal valorTotal = precoInicial + (precoPorHora * horas);
                    
                    veiculos.Remove(placaFormatada);

                    Console.WriteLine($"O veículo {placaFormatada} foi removido e o preço total foi de: R$ {valorTotal:F2}");
                }
                else
                {
                    Console.WriteLine("Quantidade de horas inválida. Por favor, digite um número inteiro e positivo.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var v in veiculos)
                {
                    Console.WriteLine(v);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}