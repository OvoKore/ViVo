using ViVo.Controls;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace ViVo.Views
{
    public partial class MainTutorView : Xamarin.Forms.TabbedPage
    {
        public MainTutorView()
        {
            InitializeComponent();

            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSmoothScrollEnabled(false);

            Children.Add(new CustomNavigationPage(new HomeTutorView()));
            Children.Add(new CustomNavigationPage(new MapView()));
            Children.Add(new CustomNavigationPage(new ConfigView()));
        }
    }
}