using System;
using Cooperchip.MedicalManagement.Domain.Entidade;
using FluentValidation;

namespace Cooperchip.MedicalManagement.Domain.Validations
{
    public class ProntuarioInvasoesValidator : AbstractValidator<Prontuario>
    {
        public ProntuarioInvasoesValidator(){
            Initializer();
        }

        private void Initializer(){
            DataProntuarioValidator();
            NumAtendimentoValidator();
            PacienteIdValidator();
            ProntuarioIdValidator();
        }

        private void ProntuarioIdValidator(){
            RuleFor(v => v.ProntuarioId).NotEmpty().NotNull()
                .WithMessage("Prontuário Não Pode ser Vazio ou Nulo!");
        }

        private void PacienteIdValidator(){
            RuleFor(v => v.PacienteId).NotEmpty().NotNull()
                .WithMessage("Id do Paciente Não Pode ser Vazio ou Nulo!");
        }

        private void NumAtendimentoValidator(){
            RuleFor(v => v.NumAtendimento).NotEmpty().NotNull().NotEqual("0000000")
                .WithMessage("Nº de Atendimento Não Pode ser Vazio ou Nulo!");
        }

        private void DataProntuarioValidator(){
            RuleFor(v => v.DataProntuario).LessThanOrEqualTo(DateTime.Today)
                .WithMessage("A Data do Prontuário não pode ser maior que a data atual.");
        }
    }
}
