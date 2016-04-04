
namespace OtenkiBotCore.Forecast.Yahoo
{
    public class CustomForecast : YahooForecast
    {
        public string Day { get; set; }
        public string Forecast { get; set; }
        public Temperature Temperature { get; set; }
        public int RelativeDay { get; set; }
    }

    public class Temperature
    {
        public string Max { get; set; }
        public string Min { get; set; }
    }
}
