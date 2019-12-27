using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Threading.Tasks;

namespace ViVo.ViewModels
{
    public class ConfigViewModel : ViewModelBase
    {
        protected ConfigViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            IsActiveChanged += HandleIsActiveTrue;
            IsActiveChanged += HandleIsActiveFalse;
        }

        private void HandleIsActiveTrue(object sender, EventArgs args)
        {
            if (IsActive == false) return;
        }

        private void HandleIsActiveFalse(object sender, EventArgs args)
        {
            if (IsActive == true) return;
        }

        public override void Destroy()
        {
            IsActiveChanged -= HandleIsActiveTrue;
            IsActiveChanged -= HandleIsActiveFalse;
        }

        private DelegateCommand sairCommand;
        public DelegateCommand SairCommand => sairCommand ?? (sairCommand = new DelegateCommand(async () => await SairCommandExecute(), () => !IsBusy));
        
        private async Task SairAsync()
        {
            try
            {
                IsBusy = true;
                await NavigationService.NavigateAsync("/NavigationPage/LoginView");
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