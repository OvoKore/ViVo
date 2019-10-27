using ViVo.Controls;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace ViVo.Views
{
    public partial class MainIdosoView : Xamarin.Forms.TabbedPage
    {
        public MainIdosoView()
        {
            InitializeComponent();

            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSmoothScrollEnabled(false);

            Children.Add(new CustomNavigationPage(new HomeIdosoView()));
            Children.Add(new CustomNavigationPage(new MapView()));
            Children.Add(new CustomNavigationPage(new ConfigView()));
        }
    }
}