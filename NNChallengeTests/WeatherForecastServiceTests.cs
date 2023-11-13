using NNChallenge.Interfaces;
using NNChallenge.Services;

namespace NNChallengeTests
{
    public class WeatherForecastServiceTests
    {
        private readonly IWeatherForcastService service;
        public WeatherForecastServiceTests()
        {
            service = new WeatherForecastService();
        }


        [Theory]
        [InlineData("London")]
        [InlineData("Mumbai")]
        [InlineData("Seoul")]
        [InlineData("Los Angeles")]
        public async Task GetForecastForCityAsync_WhenCalledWithValidCity_ReturnsArrayOfIHourWeatherForecastVO(string city)
        {
            var forecastsWithCurrent = await service.GetForecastForCityAsync(city);
            Assert.NotNull(forecastsWithCurrent);
            Assert.True(forecastsWithCurrent.Forecasts.Length > 0);
            Assert.True(forecastsWithCurrent.Forecasts.All(f => f.Date.Date >= DateTime.Now.Date && f.Date.Date <= DateTime.Now.AddDays(3).Date));
            Assert.True(forecastsWithCurrent.Forecasts.All(f => f.TemperatureFahrenheit > f.TemperatureCelcius));
            Assert.True(forecastsWithCurrent.Forecasts.All(f => !string.IsNullOrEmpty(f.ForecastPitureURL)));
            Assert.True(forecastsWithCurrent.Forecasts.All(f => !string.IsNullOrEmpty(f.Condition)));
            Assert.NotNull(forecastsWithCurrent.Current);
            Assert.True(forecastsWithCurrent.Current.TemperatureFahrenheit > forecastsWithCurrent.Current.TemperatureCelcius);

        }


        [Fact]
        public async Task GetForecastForCityAsync_WhenCalledWithInvalidCity_ReturnsNull()
        {
            string city = "invalidCity";
            var forecastsWithCurrent = await service.GetForecastForCityAsync(city);
            Assert.Null(forecastsWithCurrent);
        }
    }
}