using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViVo;
using ViVo.ViewModels;

namespace PassaKey.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        protected LoginViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            RoleLista = Utils.roles;
        }

        #region Campos

        private List<string> _roleLista;
        public List<string> RoleLista
        {
            get => _roleLista;
            set => SetProperty(ref _roleLista, value);
        }

        private string _cpf;
        public string Cpf
        {
            get => _cpf;
            set => SetProperty(ref _cpf, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private string _role;
        public string Role
        {
            get => _role;
            set => SetProperty(ref _role, value);
        }
        #endregion

        private DelegateCommand logarCommand;
        public DelegateCommand LogarCommand => logarCommand ?? (logarCommand = new DelegateCommand(async () => await LogarCommandExecute(), () => !IsBusy));

        private DelegateCommand criarCommand;
        public DelegateCommand CriarCommand => criarCommand ?? (criarCommand = new DelegateCommand(async () => await CriarCommandExecute(), () => !IsBusy));

        private async Task LogarAsync()
        {            
            try
            {
                IsBusy = true;
                if (Role == "Tutor")
                {
                    await NavigationService.NavigateAsync("/MainTutorView");
                }
                else if (Role == "Neto")
                {
                    await NavigationService.NavigateAsync("/MainNetoView");
                }
                else if (Role == "Idoso")
                {
                    await NavigationService.NavigateAsync("/MainIdosoView");
                }
                else
                {
                    await PageDialogService.DisplayAlertAsync("Alerta", "Selecione um tipo de usuário", "OK");
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
        private async Task LogarCommandExecute()
        {
            await LogarAsync();
        }

        private async Task CriarAsync()
        {
            try
            {
                IsBusy = true;
                await NavigationService.NavigateAsync("CadastroView");
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
        private async Task CriarCommandExecute()
        {
            await CriarAsync();
        }
    }
}