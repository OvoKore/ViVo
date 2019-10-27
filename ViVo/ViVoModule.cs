using Prism.Ioc;
using Prism.Modularity;
using ViVo.Views;
using ViVo.ViewModels;

namespace ViVo
{
    public class ViVoModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
        }
    }
}
