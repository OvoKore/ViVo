using PassaKey.ViewModels;
using Prism;
using Prism.Ioc;
using ViVo.ViewModels;
using ViVo.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ViVo
{
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("/NavigationPage/LoginView");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainIdosoView, MainViewModel>();
            containerRegistry.RegisterForNavigation<MainTutorView, MainViewModel>();
            containerRegistry.RegisterForNavigation<MainNetoView, MainViewModel>();
            containerRegistry.RegisterForNavigation<LoginView, LoginViewModel>();
            containerRegistry.RegisterForNavigation<CadastroView, CadastroViewModel>();
            containerRegistry.RegisterForNavigation<CadastrarIdosoView, CadastrarIdosoViewModel>();
            containerRegistry.RegisterForNavigation<CadastrarTutorView, CadastrarTutorViewModel>();
            containerRegistry.RegisterForNavigation<CadastrarNetoView, CadastrarNetoViewModel>();
            containerRegistry.RegisterForNavigation<HomeIdosoView, HomeIdosoViewModel>();
            containerRegistry.RegisterForNavigation<HomeNetoView, HomeNetoViewModel> ();
            containerRegistry.RegisterForNavigation<HomeTutorView, HomeTutorViewModel> ();
            containerRegistry.RegisterForNavigation<ListaIdosoView, ListaIdosoViewModel> ();
            containerRegistry.RegisterForNavigation<MapView, MapViewModel>();
            containerRegistry.RegisterForNavigation<ConfigView, ConfigViewModel>();
        }
    }
}
