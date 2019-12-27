using Android.App;
using Android.Content;
using Android.Gms.Common.Apis;
using Android.Gms.Location;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Plugin.Permissions.Abstractions;
using ViVo.Controls;
using ViVo.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.GoogleMaps.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace ViVo.Droid.Renderers
{
    public class CustomMapRenderer : MapRenderer, GoogleMap.IInfoWindowAdapter
    {
        public CustomMapRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
            }
        }

        protected override async void OnMapReady(GoogleMap nativeMap, Map map)
        {
            map.MyLocationButtonClicked += (sender, args) =>
            {
                PedirGps();
            };

            var status = await Utils.PedirPermissaoLocalizacao();
            if (status == PermissionStatus.Granted)
            {
                Map.MyLocationEnabled = true;
                Map.UiSettings.MyLocationButtonEnabled = true;

                Plugin.Geolocator.Abstractions.Position posicao = await Utils.PedirLocalizacao();
                if (posicao != null)
                {
                    Map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(posicao.Latitude, posicao.Longitude), Distance.FromMiles(0.1)));
                }
                else
                {
                    PedirGps();
                }
            }
            base.OnMapReady(nativeMap, map);
        }

        public Android.Views.View GetInfoContents(Marker marker)
        {
            return null;
        }

        public Android.Views.View GetInfoWindow(Marker marker)
        {
            return new Android.Views.View(Context);
        }

        public void PedirGps()
        {
            var googleApiClient = new GoogleApiClient.Builder(Context).AddApi(LocationServices.API).Build();
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
                                callback.Status.StartResolutionForResult((Activity)Context, Utils.REQUEST_CHECK_SETTINGS);
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
    }
}