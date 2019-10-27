using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Threading.Tasks;
using ViVo.Views;
using Xamarin.Forms;

namespace ViVo.ViewModels
{
    public class ConfigViewModel : ViewModelBase
    {
        private DelegateCommand sairCommand;
        public DelegateCommand SairCommand => sairCommand ?? (sairCommand = new DelegateCommand(async () => await SairCommandExecute(), () => !IsBusy));
        protected ConfigViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
        }

        private async Task SairAsync()
        {
            try
            {
                IsBusy = true;
                await NavigationService.NavigateAsync("/LoginView");
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

        private async Task SairCommandExecute()
        {
            await SairAsync();
        }
    }
}