using Prism.Navigation;
using Prism.Services;

namespace ViVo.ViewModels
{
    public class HomeIdosoViewModel : ViewModelBase
    {
        protected HomeIdosoViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
        }
    }
}
