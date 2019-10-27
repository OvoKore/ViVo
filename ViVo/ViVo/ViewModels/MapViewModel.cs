using Prism.Navigation;
using Prism.Services;

namespace ViVo.ViewModels
{
    public class MapViewModel : ViewModelBase
    {
        protected MapViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
        }
    }
}
