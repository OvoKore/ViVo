using FluentValidation;
using System;
using ViVo.Models;

namespace ViVo.Validators
{
    class UserBaseValidator : AbstractValidator<UserBase>
    {
        public UserBaseValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome tem que ter entre 8 a 20 digitos.").Length(8, 50).WithMessage("Nome de 8 a 20 digitos.");
            RuleFor(x => x.Cpf).Must(Utils.CpfValidator).WithMessage("CPF inválido.");
            RuleFor(x => x.Nascimento).NotEmpty().NotEqual(DateTime.Today).WithMessage("A data de nascimento é obrigatório.");
            RuleFor(x => x.Sexo).NotEmpty().WithMessage("O sexo é obrigatório.");
            RuleFor(x => x.Celular).NotEmpty().WithMessage("O celular é obrigatório.").Length(14).WithMessage("Exemplo de número de celular válido: (XX)XXXXX-XXXX.");
            RuleFor(x => x.Cep).NotEmpty().WithMessage("O CEP é obrigatório.").Length(9).WithMessage("Exemplo de CEP válido: XXXXX-XXX.");
            RuleFor(x => x.Estado).NotEmpty().WithMessage("O estado é obrigatório.").Length(2).WithMessage("Somente a sigla do estado.");
            RuleFor(x => x.Cidade).NotEmpty().WithMessage("A cidade é obrigatório.").Length(2, 30).WithMessage("Cidade de 2 a 30 digitos.");
            RuleFor(x => x.Bairro).NotEmpty().WithMessage("O bairro é obrigatório.").Length(2, 30).WithMessage("Bairro de 2 a 30 digitos.");
            RuleFor(x => x.Endereco).NotEmpty().WithMessage("O endereço é obrigatório.").Length(2, 30).WithMessage("Endereço de 2 a 30 digitos.");
            RuleFor(x => x.EnderecoNumero).NotEmpty().WithMessage("O número do endereço é obrigatório.").Length(1,7).WithMessage("Número do endereço de 1 a 7 digitos.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email inválido.");
            RuleFor(x => x.ConfirmarEmail).Equal(x => x.Email).WithMessage("O email e a confirmação não estão iguais.");
            RuleFor(x => x.Senha).Must(Utils.SenhaValidator).WithMessage("Senha tem que conter 8 ou mais dígitos, 1 número, 1 caractere especial e 1 letra maiúscula.");
            RuleFor(x => x.ConfirmarSenha).Equal(x => x.Senha).WithMessage("A senha e a confirmação não estão iguais.");
        }
    }
}