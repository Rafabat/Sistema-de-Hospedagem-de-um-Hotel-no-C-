using System;
using System.Collections.Generic;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa>? Hospedes { get; set; }
        public Suite? Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido(Pronto)
            if (Suite != null && hospedes.Count > Suite.Capacidade)
            {
                throw new Exception("A capacidade da suíte é menor do que o número de hóspedes sendo cadastrados.");
            }

            Hospedes = hospedes;
        }


        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes (propriedade Hospedes) (Pronto)
            return Hospedes?.Count ?? 0;
        }

        public decimal CalcularValorDiaria()
        {
            // Verifica se a propriedade Suite é nula antes de acessá-la
            if (Suite != null)
            {
                // Retorna o valor da diária(Pronto)
                // Cálculo: DiasReservados X Suite.ValorDiaria(Pronto)
                decimal valor = DiasReservados * Suite.ValorDiaria;

                // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%((Pronto)
                if (DiasReservados >= 10)
                {
                    valor *= 0.9m; // Aplica o desconto de 10%
                }

                return valor;
            }
            else
            {
                // Caso a propriedade Suite seja nula, retorna 0
                return 0;
            }
        }
    }
}
