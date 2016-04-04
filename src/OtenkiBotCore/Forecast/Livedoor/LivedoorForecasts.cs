using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OtenkiBotCore.Forecast.Livedoor
{
    [DataContract]
    public class LivedoorForecasts
    {
        [DataMember(Name = "location")]
        public Location Location { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "link")]
        public Uri Link { get; set; }

        [DataMember(Name = "publicTime")]
        public string PublicTime { get; set; }

        [DataMember(Name = "description")]
        public Description Description { get; set; }

        [DataMember(Name = "forecasts")]
        public List<Forecasts> AllForecasts { get; set; }

        [DataMember(Name = "pinpointLocations")]
        public List<LinkGroup> AllPinpointLocations { get; set; }

        [DataMember(Name = "copyright")]
        public Copyright Copyright { get; set; }
    }

    [DataContract]
    public class Location
    {
        [DataMember(Name = "area")]
        public string Area { get; set; }

        [DataMember(Name = "prefecture")]
        public string Prefecture { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }
    }

    [DataContract]
    public class Description
    {
        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "publicTime")]
        public string PublicTime { get; set; }
    }

    [DataContract]
    public class Forecasts
    {
        [DataMember(Name = "date")]
        public string Date { get; set; }

        [DataMember(Name = "dateLabel")]
        public string DateLabel { get; set; }

        [DataMember(Name = "telop")]
        public string Telop { get; set; }

        [DataMember(Name = "image")]
        public Image Image { get; set; }

        [DataMember(Name = "temperature")]
        public Temperature Temperature { get; set; }
    }

    [DataContract]
    public class Image
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "link")]
        public Uri Link { get; set; }

        [DataMember(Name = "url")]
        public Uri Url { get; set; }

        [DataMember(Name = "width")]
        public int Width { get; set; }

        [DataMember(Name = "height")]
        public int Height { get; set; }
    }

    [DataContract]
    public class Temperature
    {
        [DataMember(Name = "min")]
        public TemperatureRange Min { get; set; }

        [DataMember(Name = "max")]
        public TemperatureRange Max { get; set; }
    }

    [DataContract]
    public class TemperatureRange
    {
        [DataMember(Name = "celsius")]
        public string Celsius { get; set; }

        [DataMember(Name = "fahrenheit")]
        public string Fahrenheit { get; set; }
    }

    [DataContract]
    public class LinkGroup
    {
        [DataMember(Name = "link")]
        public Uri Link { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }

    [DataContract]
    public class Copyright
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "link")]
        public Uri Link { get; set; }

        [DataMember(Name = "image")]
        public Image Image { get; set; }

        [DataMember(Name = "provider")]
        public List<LinkGroup> Providers { get; set; }
    }
}