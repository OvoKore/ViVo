using Xamarin.Forms;

namespace ViVo.Controls
{
    public class CustomNavigationPage : NavigationPage
    {
        public CustomNavigationPage(Page root) : base(root)
        {
            Title = root.Title;
            IconImageSource = root.IconImageSource;
        }

        public CustomNavigationPage()
        {

        }
    }
}