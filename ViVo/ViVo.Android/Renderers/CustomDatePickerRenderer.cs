using System.ComponentModel;
using Android.Content;
using ViVo.Controls;
using ViVo.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomDatePicker), typeof(CustomDatePickerRenderer))]
namespace ViVo.Droid.Renderers
{
    public class CustomDatePickerRenderer : DatePickerRenderer
    {

        public CustomDatePickerRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Text = "Data de nascimento*";
                Control.SetTextColor(Android.Graphics.Color.ParseColor("#bababa"));
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control.Text != "Data de nascimento*")
            {
                Control.SetTextColor(Android.Graphics.Color.Black);
            }
        }
    }
}