using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Gms.Common.Apis;
using Android.Gms.Location;
using Android.OS;
using Android.Runtime;
using Plugin.Permissions;
using Xamarin.Forms;

namespace ViVo.Droid
{
    [Activity(Label = "ViVô", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, bundle);

            Forms.Init(this, bundle);

            DisplayLocationSettingsRequest();

            Xamarin.FormsGoogleMaps.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void DisplayLocationSettingsRequest()
        {
            var googleApiClient = new GoogleApiClient.Builder(this).AddApi(LocationServices.API).Build();
            googleApiClient.Connect();

            var locationRequest = LocationRequest.Create();
            locationRequest.SetPriority(LocationRequest.PriorityHighAccuracy);
            locationRequest.SetInterval(10000);
            locationRequest.SetFastestInterval(10000 / 2);

            var builder = new LocationSettingsRequest.Builder().AddLocationRequest(locationRequest);
            builder.SetAlwaysShow(true);

            var result = LocationServices.SettingsApi.CheckLocationSettings(googleApiClient, builder.Build());
            result.SetResultCallback(async (LocationSettingsResult callback) =>
            {
                switch (callback.Status.StatusCode)
                {
                    case LocationSettingsStatusCodes.Success:
                        {
                            await Utils.PedirPermissaoLocalizacao();
                            break;
                        }
                    case LocationSettingsStatusCodes.ResolutionRequired:
                        {
                            try
                            {
                                callback.Status.StartResolutionForResult(this, Utils.REQUEST_CHECK_SETTINGS);
                                await Utils.PedirPermissaoLocalizacao();
                            }
                            catch (IntentSender.SendIntentException)
                            {
                            }
                            break;
                        }
                }
            });
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            switch (requestCode)
            {
                case Utils.REQUEST_CHECK_SETTINGS:
                    {
                        switch (resultCode)
                        {
                            case Result.Ok:
                                {
                                    break;
                                }
                            case Result.Canceled:
                                {
                                    break;
                                }
                        }
                        break;
                    }
            }
        }
    }
}