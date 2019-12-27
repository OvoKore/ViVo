using Prism.Navigation;
using Prism.Services;

namespace ViVo.ViewModels
{
    public class CadastrarNetoViewModel : ViewModelCadastrarBase
    {
        protected CadastrarNetoViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {            
            PaginaNome = "Neto";
        }
    }
}