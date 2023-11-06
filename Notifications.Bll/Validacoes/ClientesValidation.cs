using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Bll.Validacoes
{
    public class ClientesValidation : AbstractValidator<Clientes>
    {
        public ClientesValidation()
        {

            RuleFor(cliente => cliente.Nome)
         .NotEmpty()
         .WithMessage("O campo nome não pode estar vazio.")
         .Length(3, 10)
         .WithMessage("O campo nome deve ter entre 3 e 10 caracteres.")
         .Must(nome => !nome.Equals("Carlos"))
         .WithMessage("Nome 'Carlos' não é permitido.");

            RuleFor(pessoa => pessoa.Nome)
              .Length(3, 10)
              .WithMessage("O campo nome deve ter entre 3 e 10 caracteres.");

            RuleFor(pessoa => pessoa.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("O campo email deve ser um endereço de e-mail válido.");

        }
    }
}
