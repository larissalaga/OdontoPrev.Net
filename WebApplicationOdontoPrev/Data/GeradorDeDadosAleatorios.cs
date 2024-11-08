using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationOdontoPrev.Models;

namespace WebApplicationOdontoPrev.Data.GeradorDeDadosAleatorios
{
    public class GeradorDePacientes
    {
        private static readonly string[] PrimeiroNomes = { "João", "Maria", "Carlos", "Ana", "Pedro", "Laura", "Roberto", "Camila", "Lucas", "Alice", "Daniel", "Sofia", "Matheus", "Isabela", "André", "Manuela", "Thiago", "Beatriz", "Gustavo", "Luiza" };
        private static readonly string[] Sobrenomes = { "Silva", "Santos", "Oliveira", "Souza", "Pereira", "Ferreira", "Costa", "Rodrigues", "Almeida", "Nascimento", "Lima", "Araújo", "Cardoso", "Gomes", "Martins", "Barros", "Vieira", "Ribeiro", "Teixeira", "Mendes" };
        private static readonly string[] DominiosEmail = { "exemplo.com", "email.com", "teste.com", "dominio.com" };
        private static readonly string[] Sexos = { "m", "f" };
        private static readonly Random Random = new Random();

        public Paciente GerarPacienteAleatorio(int quantidade = 100)
        {
            var primeiroNome = PrimeiroNomes[Random.Next(PrimeiroNomes.Length)];
            var sobrenome = Sobrenomes[Random.Next(Sobrenomes.Length)];
            var nome = $"{primeiroNome} {sobrenome}";
            var email = $"{primeiroNome.ToLower()}.{sobrenome.ToLower()}{Random.Next(100, 999)}@{DominiosEmail[Random.Next(DominiosEmail.Length)]}";
            var cpf = GerarCPF();
            var dataNascimento = GerarDataNascimento();
            var telefone = GerarTelefone();
            var sexo = GerarSexo();

            return new Paciente
            {
                DsEmail = email,
                DsSexo = sexo,
                NmPaciente = nome,
                NrCpf = cpf,
                NrTelefone = telefone,
                DtNascimento = dataNascimento
            };
        }

        public List<Paciente> GerarPacientesAleatorios(int quantidade = 100)
        {
            var usuariosAleatorios = new List<Paciente>();

            for (int i = 0; i < quantidade; i++)
            {
                var primeiroNome = PrimeiroNomes[Random.Next(PrimeiroNomes.Length)];
                var sobrenome = Sobrenomes[Random.Next(Sobrenomes.Length)];
                var nome = $"{primeiroNome} {sobrenome}";
                var email = $"{primeiroNome.ToLower()}.{sobrenome.ToLower()}{Random.Next(100, 999)}@{DominiosEmail[Random.Next(DominiosEmail.Length)]}";
                var cpf = GerarCPF();
                var dataNascimento = GerarDataNascimento();
                var telefone = GerarTelefone();
                var sexo = GerarSexo();

                usuariosAleatorios.Add(new Paciente
                {
                    DsEmail = email,
                    DsSexo = sexo,
                    NmPaciente = nome,
                    NrCpf = cpf,
                    NrTelefone = telefone,
                    DtNascimento = dataNascimento
                });
            }

            return usuariosAleatorios;
        }

        private string GerarCPF()
        {
            int[] cpf = new int[11];

            // Gerar os primeiros 9 dígitos do CPF
            for (int i = 0; i < 9; i++)
            {
                cpf[i] = Random.Next(10);
            }

            // Calcular o primeiro dígito verificador
            cpf[9] = CalcularDigitoVerificador(cpf, 10);

            // Calcular o segundo dígito verificador
            cpf[10] = CalcularDigitoVerificador(cpf, 11);

            // Retornar o CPF formatado
            return string.Join("", cpf.Take(9)) + "-" + string.Join("", cpf.Skip(9));
        }

        private int CalcularDigitoVerificador(int[] cpf, int peso)
        {
            int soma = 0;

            for (int i = 0; i < peso - 1; i++)
            {
                soma += cpf[i] * (peso - i);
            }

            int resto = soma % 11;

            return resto < 2 ? 0 : 11 - resto;
        }

        private DateOnly GerarDataNascimento()
        {
            // Gerar uma data aleatória entre 01/01/1950 e 31/12/2023
            DateTime dataInicial = new DateTime(1950, 1, 1);
            DateTime dataFinal = new DateTime(2023, 12, 31);
            
            int range = (dataFinal - dataInicial).Days;
            DateOnly dataAleatoria = DateOnly.FromDateTime(dataInicial.AddDays(Random.Next(range)));
            return dataAleatoria;
        }

        private string GerarTelefone()
        {
            // Gerar código de área (xx)
            int ddd = Random.Next(11, 99);

            // Gerar número do telefone (xxxxx-xxxx)
            int numero1 = Random.Next(10000, 99999); // Primeira parte com 5 dígitos
            int numero2 = Random.Next(1000, 9999);   // Segunda parte com 4 dígitos

            return $"({ddd}){numero1}-{numero2}";
        }

        private string GerarSexo()
        {
            // Selecionar "m" ou "f" aleatoriamente
            return Sexos[Random.Next(Sexos.Length)];
        }
    }
}