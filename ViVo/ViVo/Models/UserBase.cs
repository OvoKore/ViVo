using System;

namespace ViVo.Models
{
    public class UserBase
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTimeOffset Nascimento { get; set; }
        public string Sexo { get; set; }
        public string Celular { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Endereco { get; set; }
        public string EnderecoNumero { get; set; }
        public string EnderecoComplemento { get; set; }
        public string Email { get; set; }
        public string ConfirmarEmail { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }
    }
}