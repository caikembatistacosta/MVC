using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BLL.Validators.Pet
{
    internal class PetValidator : AbstractValidator<Entities.Pet>
    {
        public void ValidateID()
        {
            RuleFor(c => c.ID).NotNull().WithMessage("ID deve ser informado.");
        }

        public void ValidateNome()
        {
            RuleFor(c => c.Nome).NotNull().WithMessage("Nome deve ser informado.")
                                .MinimumLength(3).WithMessage("Pet deve conter ao menos 3 caracteres.")
                                .MaximumLength(30).WithMessage("Pet não pode conter mais de 30 caracteres.");
        }

        public void ValidateRaca()
        {
            RuleFor(c => c.Raca).NotNull().WithMessage("Raça deve ser informada.")
                               .MinimumLength(3).WithMessage("Raça deve conter ao menos 3 caracteres.")
                               .MaximumLength(20).WithMessage("Pet não pode conter mais de 20 caracteres.");
        }

        public void ValidateCor()
        {
            RuleFor(c => c.Cor).NotNull().WithMessage("Cor deve ser informada.")
                               .MinimumLength(3).WithMessage("Cor deve conter ao menos 3 caracteres.")
                               .MaximumLength(20).WithMessage("Cor não pode conter mais de 20 caracteres.");
        }

        public void ValidatePeso()
        {
            RuleFor(c => c.Peso).NotNull().WithMessage("Peso deve ser informada.")
                                .GreaterThanOrEqualTo(0.5).WithMessage("Peso deve ser ao menos 0.5")
                                .LessThanOrEqualTo(150).WithMessage("Peso máximo de 150kg.");
                              
        }

    }
}
