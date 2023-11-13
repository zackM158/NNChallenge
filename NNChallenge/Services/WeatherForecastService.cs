using Newtonsoft.Json;
using NNChallenge.Extensions;
using NNChallenge.Interfaces;
using NNChallenge.Models;
using NNChallenge.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NNChallenge.Services
{
    public class WeatherForecastService : IWeatherForcastService
    {
        string baseUrl = @"https://api.weatherapi.com/v1/forecast.json";
        string apiKey = "898147f83a734b7dbaa95705211612";
        int days = 3;
        bool aqiEnabled = false;
        bool alertsEnabled = false;

        static HttpClient client = new HttpClient();

        private string GetUrl(string city)
        {
            var stringBuilder = new StringBuilder(baseUrl);
            stringBuilder.Append("?key=" + apiKey);
            stringBuilder.Append("&q=" + city);
            stringBuilder.Append("&days=" + days.ToString());
            stringBuilder.Append("&aqi=" + (aqiEnabled ? "yes" : "no"));
            stringBuilder.Append("&alerts=" + (alertsEnabled ? "yes" : "no"));

            return stringBuilder.ToString();
        }

        private async Task<WeatherForecastResponse> GetWeatherForecastResponse(string city)
        {
            WeatherForecastResponse response;
            var url = GetUrl(city);

            HttpResponseMessage httpResponse = await client.GetAsync(url);

            if (httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<WeatherForecastResponse>(content);
                response.IsSuccessful = true;
            }
            else
            {
                response = new WeatherForecastResponse()
                {
                    IsSuccessful = false
                };
            }

            return response;
        }

        public async Task<ForecastsWithCurrent> GetForecastForCityAsync(string city)
        {
            var response = await GetWeatherForecastResponse(city);
            var forecasts = response.ConvertToHourWeatherForecastVOs();
            if (forecasts == null) return null;

            var current = response.Current.ConvertToHourWeatherForecastVO();
            var forecastsWithCurrent = new ForecastsWithCurrent(forecasts.ToArray(), current);

            return forecastsWithCurrent;
        }
    }
}
