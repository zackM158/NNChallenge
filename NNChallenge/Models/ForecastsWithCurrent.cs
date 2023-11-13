using NNChallenge.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NNChallenge.Models
{
    public class ForecastsWithCurrent
    {
        public ForecastsWithCurrent(IHourWeatherForecastVO[] forecasts, IHourWeatherForecastVO current)
        {
            Forecasts = forecasts;
            Current = current;
        }

        public IHourWeatherForecastVO[] Forecasts { get; set; }
        public IHourWeatherForecastVO Current { get; set; }
    }
}
