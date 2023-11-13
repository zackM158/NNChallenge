using System;
namespace NNChallenge.Interfaces
{
    public interface IWeatherForcastVO
    {
        /// <summary>
        /// Name of the city
        /// </summary>
        string City { get; }
        /// <summary>
        /// Array of weather forecast etries
        /// </summary>
        IHourWeatherForecastVO[] HourForecast { get; }

        /// <summary>
        /// Current Forecast
        /// </summary>
        IHourWeatherForecastVO CurrentForecast { get; set; }
    }

    public interface IHourWeatherForecastVO
    {
        /// <summary>
        /// date of forecast
        /// </summary>
        DateTime Date { get; }
        /// <summary>
        /// temerature in Celcius
        /// </summary>
        float TemperatureCelcius { get; }
        /// <summary>
        /// Temperture in Fahrenheit
        /// </summary>
        float TemperatureFahrenheit { get; }
        /// <summary>
        /// url for picture
        /// </summary>
        string ForecastPitureURL { get; }

        /// <summary>
        /// Description of weather
        /// </summary>
        string Condition { get; set; }
    }
}
