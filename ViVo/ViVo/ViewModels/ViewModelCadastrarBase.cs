using FluentValidation;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViVo.Models;
using ViVo.Service;
using ViVo.Validators;

namespace ViVo.ViewModels
{
    public class ViewModelCadastrarBase : ViewModelBase
    {
        protected ViewModelCadastrarBase(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
            Estados = Utils.estados;
            Cidades = new List<Cidade>();
            SexoLista = new List<string>() { "Masculino", "Feminino" };
            EnderecoHabilitado = true;
            Nascimento = DateTime.Today;
            Senha = string.Empty;
            ConfirmarSenha = string.Empty;
            Email = string.Empty;
            ConfirmarEmail = string.Empty;
        }

        #region Campos
        private string _paginaNome;
        public string PaginaNome
        {
            get => _paginaNome;
            set
            {
                SetProperty(ref _paginaNome, value);
                Title = $"Cadastrar {value}";
            }
        }

        private List<Estado> _estados;
        public List<Estado> Estados
        {
            get => _estados;
            set => SetProperty(ref _estados, value);
        }


        private List<Cidade> _cidades;
        public List<Cidade> Cidades
        {
            get => _cidades;
            set => SetProperty(ref _cidades, value);
        }

        private List<string> _sexoLista;
        public List<string> SexoLista
        {
            get => _sexoLista;
            set => SetProperty(ref _sexoLista, value);
        }

        private string _nome;
        public string Nome
        {
            get => _nome;
            set => SetProperty(ref _nome, value);
        }

        private string _cpf;
        public string Cpf
        {
            get => _cpf;
            set => SetProperty(ref _cpf, value);
        }

        private DateTime _nascimento;
        public DateTime Nascimento
        {
            get => _nascimento;
            set => SetProperty(ref _nascimento, value);
        }

        private string _sexo;
        public string Sexo
        {
            get => _sexo;
            set => SetProperty(ref _sexo, value);
        }

        private string _celular;
        public string Celular
        {
            get => _celular;
            set => SetProperty(ref _celular, value);
        }

        private string _cep;
        public string Cep
        {
            get => _cep;
            set => SetProperty(ref _cep, value);
        }

        private Estado _estado;
        public Estado Estado
        {
            get => _estado;
            set
            {
                SetProperty(ref _estado, value);
                Cidades = Utils.cidades.Where(c => c.Estado == value.ID).ToList<Cidade>();
                Cidade = null;
            }
        }

        private Cidade _cidade;
        public Cidade Cidade
        {
            get => _cidade;
            set => SetProperty(ref _cidade, value);
        }

        private string _bairro;
        public string Bairro
        {
            get => _bairro;
            set => SetProperty(ref _bairro, value);
        }

        private string _endereco;
        public string Endereco
        {
            get => _endereco;
            set => SetProperty(ref _endereco, value);
        }

        private string _enderecoNumero;
        public string EnderecoNumero
        {
            get => _enderecoNumero;
            set => SetProperty(ref _enderecoNumero, value);
        }

        private string _enderecoComplemento;
        public string EnderecoComplemento
        {
            get => _enderecoComplemento;
            set => SetProperty(ref _enderecoComplemento, value);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _confirmarEmail;
        public string ConfirmarEmail
        {
            get => _confirmarEmail;
            set => SetProperty(ref _confirmarEmail, value);
        }

        private string _senha;
        public string Senha
        {
            get => _senha;
            set => SetProperty(ref _senha, value);
        }

        private string _confirmarSenha;
        public string ConfirmarSenha
        {
            get => _confirmarSenha;
            set => SetProperty(ref _confirmarSenha, value);
        }

        private bool _enderecoHabilitado;
        public bool EnderecoHabilitado
        {
            get => _enderecoHabilitado;
            set => SetProperty(ref _enderecoHabilitado, value);
        }
        #endregion

        private DelegateCommand cadastrarCommand;
        public DelegateCommand CadastrarCommand => cadastrarCommand ?? (cadastrarCommand = new DelegateCommand(async () => await CadastrarCommandExecute(), () => !IsBusy));

        private async Task CadastrarAsync()
        {
            try
            {
                IsBusy = true;

                UserBase _userBase = new UserBase()
                {
                    Nome = this.Nome,
                    Cpf = this.Cpf,
                    Nascimento = this.Nascimento,
                    Sexo = this.Sexo,
                    Celular = this.Celular,
                    Cep = this.Cep,
                    Estado = this.Estado == null ? null: this.Estado.Sigla,
                    Cidade = this.Cidade == null ? null: this.Cidade.Nome,
                    Bairro = this.Bairro,
                    Endereco = this.Endereco,
                    EnderecoNumero = this.EnderecoNumero,
                    Email = this.Email,
                    ConfirmarEmail = this.ConfirmarEmail,
                    Senha = this.Senha,
                    ConfirmarSenha = this.ConfirmarSenha
                };

                var resultadoValidacao = new UserBaseValidator().Validate(_userBase);
                if (resultadoValidacao.IsValid)
                {
                    await PageDialogService.DisplayAlertAsync(string.Empty, "Cadastro concluido", "OK");
                    await NavigationService.NavigateAsync($"/NavigationPage/Main{PaginaNome}View");
                }
                else
                {
                    await PageDialogService.DisplayAlertAsync("Campos obrigatórios", string.Join("\n", resultadoValidacao.Errors) , "OK");
                }

                
            }
            catch (Exception ex)
            {
                await PageDialogService.DisplayAlertAsync("Erro", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task CadastrarCommandExecute()
        {
            await CadastrarAsync();
        }

        private DelegateCommand consultarCepCommand;
        public DelegateCommand ConsultarCepCommand => consultarCepCommand ?? (consultarCepCommand = new DelegateCommand(async () => await ConsultarCepCommandExecute(), () => !IsBusy));

        private async Task ConsultarCepAsync()
        {
            try
            {
                IsBusy = true;
                Cep cepResposta = await RestService.For<IRestApi>(EndPoints.CepUrl).Cep(this.Cep);
                if (cepResposta != null)
                {
                    Estado = Utils.estados.Where(e => e.Sigla == cepResposta.uf).FirstOrDefault();
                    Cidades = Utils.cidades.Where(c => c.Estado == Estado.ID).ToList<Cidade>();
                    Cidade = Utils.cidades.Where(c => c.Nome == cepResposta.localidade).FirstOrDefault();
                    Bairro = cepResposta.bairro;
                    Endereco = cepResposta.logradouro;
                    EnderecoHabilitado = false;
                }
            }
            catch (Exception ex)
            {
                await PageDialogService.DisplayAlertAsync("Erro", ex.Message, "OK");
                EnderecoHabilitado = true;
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async Task ConsultarCepCommandExecute()
        {
            await ConsultarCepAsync();
        }
    }
}