using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViVo.Models;
using ViVo.Validators;

namespace ViVo.ViewModels
{
    public class CadastrarIdosoViewModel : ViewModelCadastrarBase
    {
        protected CadastrarIdosoViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            PaginaNome = "Idoso";
            SangueLista = Utils.sangues;
        }

        #region Campos

        private List<string> _sangueLista;
        public List<string> SangueLista
        {
            get => _sangueLista;
            set => SetProperty(ref _sangueLista, value);
        }

        private string _sangue;
        public string Sangue
        {
            get => _sangue;
            set => SetProperty(ref _sangue, value);
        }

        private string _cpfTutor;
        public string CpfTutor
        {
            get => _cpfTutor;
            set => SetProperty(ref _cpfTutor, value);
        }


        private string _doenca;
        public string Doenca
        {
            get => _doenca;
            set => SetProperty(ref _doenca, value);
        }

        private string _medicacao;
        public string Medicacao
        {
            get => _medicacao;
            set => SetProperty(ref _medicacao, value);
        }

        private string _atividade;
        public string Atividade
        {
            get => _atividade;
            set => SetProperty(ref _atividade, value);
        }

        private string _observacao;
        public string Observacao
        {
            get => _observacao;
            set => SetProperty(ref _observacao, value);
        }

        #endregion

        private DelegateCommand cadastrarCommand;
        public new DelegateCommand CadastrarCommand => cadastrarCommand ?? (cadastrarCommand = new DelegateCommand(async () => await CadastrarCommandExecute(), () => !IsBusy));

        private async Task CadastrarAsync()
        {
            try
            {
                IsBusy = true;

                UserIdoso _userBase = new UserIdoso()
                {
                    Nome = this.Nome,
                    Cpf = this.Cpf,
                    Nascimento = this.Nascimento,
                    Sexo = this.Sexo,
                    Celular = this.Celular,
                    Cep = this.Cep,
                    Estado = this.Estado == null ? null : this.Estado.Sigla,
                    Cidade = this.Cidade == null ? null : this.Cidade.Nome,
                    Bairro = this.Bairro,
                    Endereco = this.Endereco,
                    EnderecoNumero = this.EnderecoNumero,
                    Email = this.Email,
                    ConfirmarEmail = this.ConfirmarEmail,
                    Senha = this.Senha,
                    ConfirmarSenha = this.ConfirmarSenha,
                    Sangue = this.Sangue,
                    CpfTutor = this.CpfTutor
                };

                var resultadoValidacao = new UserIdosoValidator().Validate(_userBase);
                if (resultadoValidacao.IsValid)
                {
                    await PageDialogService.DisplayAlertAsync(string.Empty, "Cadastro concluido", "OK");
                    await NavigationService.NavigateAsync($"/NavigationPage/Main{PaginaNome}View");
                }
                else
                {
                    await PageDialogService.DisplayAlertAsync("Campos obrigatórios", string.Join("\n", resultadoValidacao.Errors), "OK");
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
    }
}