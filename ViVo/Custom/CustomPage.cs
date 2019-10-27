using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ViVo.Custom
{
    class CustomPage : NavigationPage
    {
        public CustomNavigationPage(Page root) : base(root)
        {
            Title = root.Title;
            IconImageSource = root.IconImageSource;
        }

        public CustomNavigationPage()
        {

        }
    {
    }
}