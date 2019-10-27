using Prism.Navigation;
using Prism.Services;

namespace ViVo.ViewModels
{
    public class ListaIdosoViewModel : ViewModelBase
    {
        protected ListaIdosoViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
        }
    }
}
