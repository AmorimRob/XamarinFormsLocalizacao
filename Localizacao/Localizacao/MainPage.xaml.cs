using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Localizacao
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            StartListening();
        }

        async void StartListening()
        {
            if (CrossGeolocator.Current.IsListening)
                await CrossGeolocator.Current.StopListeningAsync();

            await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(120), 10);

            CrossGeolocator.Current.PositionChanged += PositionChanged;
            CrossGeolocator.Current.PositionError += PositionError;
        }

        private void PositionChanged(object sender, PositionEventArgs e)
        {
            var position = e.Position;
            Console.WriteLine("Latitude: " + position.Latitude + " Longitude: " + position.Longitude);
        }

        private void PositionError(object sender, PositionErrorEventArgs e)
        {
            Console.WriteLine("error");
        }
    }
}
