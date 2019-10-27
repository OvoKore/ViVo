using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Threading.Tasks;

namespace ViVo.ViewModels
{
    public class CadastrarTutorViewModel : ViewModelBase
    {
        private DelegateCommand cadastrarCommand;
        public DelegateCommand CadastrarCommand => cadastrarCommand ?? (cadastrarCommand = new DelegateCommand(async () => await CadastrarCommandExecute(), () => !IsBusy));
        protected CadastrarTutorViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
            Title = "Cadastrar Tutor";
        }

        private async Task CadastrarInAsync()
        {
            try
            {
                IsBusy = true;
                await PageDialogService.DisplayAlertAsync(string.Empty, "Cadastro concluido", "OK");
                await NavigationService.NavigateAsync("/MainTutorView");
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
            await CadastrarInAsync();
        }
    }
}
