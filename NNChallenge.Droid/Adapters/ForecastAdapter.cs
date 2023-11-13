using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NNChallenge.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NNChallenge.Droid.Adapters
{
    public class Forecastdapter : BaseAdapter<IHourWeatherForecastVO>
    {
        private readonly Activity _context;
        private readonly IHourWeatherForecastVO[] _customObjects;

        public Forecastdapter(Activity context, IHourWeatherForecastVO[] customObjects)
        {
            _context = context;
            _customObjects = customObjects;
        }

        public override int Count => _customObjects.Length;

        public override long GetItemId(int position) => position;

        public override IHourWeatherForecastVO this[int position] => _customObjects[position];

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.forecast_list_item, null);

            TextView celciusTextView = view.FindViewById<TextView>(Resource.Id.celsiusTextView);
            TextView farenheitTextView = view.FindViewById<TextView>(Resource.Id.farenheitTextView);
            TextView descriptionTextView = view.FindViewById<TextView>(Resource.Id.descriptionTextView);
            TextView dateTextView = view.FindViewById<TextView>(Resource.Id.dateTextView);
            TextView timeTextView = view.FindViewById<TextView>(Resource.Id.timeTextView);
            ImageView forecastImage = view.FindViewById<ImageView>(Resource.Id.forecastImage);

            celciusTextView.Text = _customObjects[position].TemperatureCelcius.ToString() + "°C";
            farenheitTextView.Text = _customObjects[position].TemperatureFahrenheit.ToString() + "°F";
            descriptionTextView.Text = _customObjects[position].Condition;

            var forecastDate = _customObjects[position].Date;
            dateTextView.Text = forecastDate.ToString("MMMM d, yyyy");
            timeTextView.Text = forecastDate.ToString("h:mm tt");
            LoadImage("https:" +  _customObjects[position].ForecastPitureURL, forecastImage);
            return view;
        }

        private void LoadImage(string imageUrl, ImageView imageView)
        {
            try
            {
                //this might need to be uncommented for emulators
                //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

                using (var webClient = new WebClient())
                {
                    byte[] imageBytes = webClient.DownloadData(new Uri(imageUrl));
                    var bitmap = Android.Graphics.BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                    imageView.SetImageBitmap(bitmap);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading image: {ex.Message}");
            }
        }
    }
}