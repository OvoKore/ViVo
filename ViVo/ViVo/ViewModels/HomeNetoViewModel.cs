using Prism.Navigation;
using Prism.Services;

namespace ViVo.ViewModels
{
    public class HomeNetoViewModel : ViewModelBase
    {
        protected HomeNetoViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
        }
    }
}
