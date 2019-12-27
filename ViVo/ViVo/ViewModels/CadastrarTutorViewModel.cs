using Prism.Navigation;
using Prism.Services;

namespace ViVo.ViewModels
{
    public class CadastrarTutorViewModel : ViewModelCadastrarBase
    {
        protected CadastrarTutorViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            PaginaNome = "Tutor";
        }
    }
}