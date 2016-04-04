using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtenkiBotCore.Forecast.Yahoo
{
    public interface ICustomForecastCreator
    {
        List<CustomForecast> Create(List<YahooForecast> list);
    }
}
