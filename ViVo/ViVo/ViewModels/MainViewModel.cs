using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViVo.Controls;
using ViVo.Views;
using Xamarin.Forms;

namespace ViVo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        protected MainViewModel(INavigationService navigationService,
                IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            
        }
    }
}
