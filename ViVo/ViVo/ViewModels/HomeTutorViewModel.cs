using Prism.Navigation;
using Prism.Services;

namespace ViVo.ViewModels
{
    public class HomeTutorViewModel : ViewModelBase
    {
        protected HomeTutorViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
        }
    }
}
