using NNChallenge.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NNChallenge.Models
{
    public class HourWeatherForecastVO : IHourWeatherForecastVO
    {
        public HourWeatherForecastVO(DateTime date, float tempCelcius, float tempFarenheit, string imageUrl)
        {
            Date = date;
            TemperatureCelcius = tempCelcius;
            TemperatureFahrenheit = tempFarenheit;
            ForecastPitureURL = imageUrl;
        }

        public DateTime Date { get; }
        public float TemperatureCelcius { get; }
        public float TemperatureFahrenheit { get; }
        public string ForecastPitureURL { get; }
        public string Condition { get; set; }
    }
}
