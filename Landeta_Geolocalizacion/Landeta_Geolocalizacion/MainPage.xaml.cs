using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Plugin.Geolocator;

namespace Landeta_Geolocalizacion
{
    public partial class MainPage : ContentPage
    {
        double latitud;
        double longitud;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Localizar()
        {
            var localizar = CrossGeolocator.Current;
            localizar.DesiredAccuracy = 50;
            if (localizar.IsGeolocationAvailable)
            {
                if (localizar.IsGeolocationEnabled)
                {
                    if (!localizar.IsListening)
                    {
                        await localizar.StartListeningAsync(TimeSpan.FromSeconds(1), 5);
                    }
                    localizar.PositionChanged += (cambio, args) =>
                    {
                        var loc = args.Position;
                        lon.Text = loc.Longitude.ToString();
                        longitud = double.Parse(lon.Text);
                        lat.Text = loc.Latitude.ToString();
                        latitud = double.Parse(lon.Text);
                    };
                }
            }
        }

        private async void MostrarMapa(object sender, EventArgs e)
        {
            MapLaunchOptions options = new MapLaunchOptions { Name = "Mi posición actual" };
            await Map.OpenAsync(latitud, longitud, options);

        }
    }
}
