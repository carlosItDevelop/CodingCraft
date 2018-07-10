using Cooperchip.MedicalManagement.Domain.Entidade;
using FluentValidation;
using System;

namespace Cooperchip.MedicalManagement.Domain.Validations {
    public class PacienteValidator : AbstractValidator<Paciente>
    {
        public PacienteValidator(){
            Initializer();
        }

        private void Initializer(){
            DataInternacaoValidator();
            //DataNascimentoValidator();
            PesoValidator();
        }

        private void DataInternacaoValidator(){
            RuleFor(v => v.DataInternacao).LessThan(DateTime.Today)
                .WithMessage("A Data de Internação não pode ser no tempo futuro.");
        }

        //private void DataNascimentoValidator(){
        //    RuleFor(v => v.DataNascimento).LessThanOrEqualTo(DateTime.Today)
        //        .WithMessage("A Data de Nascimento não pode ser maior que a data atual.");
        //}

        private void PesoValidator(){
            RuleFor(v => v.Peso).InclusiveBetween(1,200)
                .WithMessage("O peso do paciente deve estar entre 1 e 200 Kg.");
        }
    }
}
