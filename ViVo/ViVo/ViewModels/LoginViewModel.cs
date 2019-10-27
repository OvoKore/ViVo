
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Threading.Tasks;
using ViVo.ViewModels;

namespace PassaKey.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private int role;
        public int Role
        {
            get => role;
            set => SetProperty(ref role, value);
        }

        private DelegateCommand signInCommand;
        public DelegateCommand SignInCommand => signInCommand ?? (signInCommand = new DelegateCommand(async () => await SignInCommandExecute(), () => !IsBusy));

        private DelegateCommand createCommand;
        public DelegateCommand CreateCommand => createCommand ?? (createCommand = new DelegateCommand(async () => await CreateCommandExecute(), () => !IsBusy));


        protected LoginViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
        }

        private async Task LoadSignInAsync()
        {
            try
            {
                IsBusy = true;
                role = new Random().Next(3);
                if (role == 1)
                {
                    await NavigationService.NavigateAsync("/MainIdosoView");
                }
                else if (role == 2)
                {
                    await NavigationService.NavigateAsync("/MainNetoView");
                }
                else if (role == 3)
                {
                    await NavigationService.NavigateAsync("/MainTutorView");
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

        private async Task SignInCommandExecute()
        {
            await LoadSignInAsync();
        }

        private async Task CreateInAsync()
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

        private async Task CreateCommandExecute()
        {
            await CreateInAsync();
        }
    }
}