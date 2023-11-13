
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using NNChallenge.Constants;
using NNChallenge.Droid.Adapters;
using NNChallenge.Interfaces;
using NNChallenge.Services;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NNChallenge.Droid
{
    [Activity(Label = "ForecastActivity")]
    public class ForecastActivity : Activity, IWeatherForcastVO
    {
        public string City { get; set; }

        public IHourWeatherForecastVO[] HourForecast { get; set; }
        public IHourWeatherForecastVO CurrentForecast { get; set; }

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_forecast);


            WeatherForecastService weatherForecastService = new WeatherForecastService();
            City = Intent.GetStringExtra(ApplicationConstants.SelectedCity);

            TextView cityTextView = FindViewById<TextView>(Resource.Id.cityTextView);
            cityTextView.Text = ApplicationConstants.Loading;

            var forecastsWithCurrent = await weatherForecastService.GetForecastForCityAsync(City);

            if(forecastsWithCurrent == null)
            {
                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                builder.SetMessage(ApplicationConstants.ErrorMessage)
                       .SetTitle(ApplicationConstants.ErrorTitle)
                       .SetPositiveButton(ApplicationConstants.ErrorButton, (s, args) =>
                       {
                           base.OnBackPressed();
                       });

                AlertDialog dialog = builder.Create();
                dialog.Show();
                return;
            }


            HourForecast = forecastsWithCurrent.Forecasts;
            CurrentForecast = forecastsWithCurrent.Current;

            ListView listView = FindViewById<ListView>(Resource.Id.forecastList);
            Forecastdapter adapter = new Forecastdapter(this, HourForecast);
            listView.Adapter = adapter;

            cityTextView.Text = City;

            if(CurrentForecast != null)
            {
                TextView currentTempTextView = FindViewById<TextView>(Resource.Id.currentTempTextView);
                currentTempTextView.Text = $"{CurrentForecast.TemperatureCelcius}°C / {CurrentForecast.TemperatureFahrenheit}°F";
            }
        }

    }
}
