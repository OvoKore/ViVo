using Prism.Commands;
using Prism.Navigation;
using System;
using System.Threading.Tasks;

namespace ViVo.ViewModels
{
    public class CadastroViewModel : ViewModelBase
    {
        private DelegateCommand tutorCommand;
        public DelegateCommand TutorCommand => tutorCommand ?? (tutorCommand = new DelegateCommand(async () => await TutorCommandExecute(), () => !IsBusy));

        private DelegateCommand idosoCommand;
        public DelegateCommand IdosoCommand => idosoCommand ?? (idosoCommand = new DelegateCommand(async () => await IdosoCommandExecute(), () => !IsBusy));

        private DelegateCommand netoCommand;
        public DelegateCommand NetoCommand => netoCommand ?? (netoCommand = new DelegateCommand(async () => await NetoCommandExecute(), () => !IsBusy));

        public CadastroViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Cadastro";
        }

        private async Task IdosoAsync()
        {
            try
            {
                IsBusy = true;
                await NavigationService.NavigateAsync("CadastrarIdosoView");

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
        private async Task IdosoCommandExecute()
        {
            await IdosoAsync();
        }

        private async Task NetoAsync()
        {
            try
            {
                IsBusy = true;
                await NavigationService.NavigateAsync("CadastrarNetoView");
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
        private async Task NetoCommandExecute()
        {
            await NetoAsync();
        }

        private async Task TutorAsync()
        {
            try
            {
                IsBusy = true;
                await NavigationService.NavigateAsync("CadastrarTutorView");
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
        private async Task TutorCommandExecute()
        {
            await TutorAsync();
        }
    }
}