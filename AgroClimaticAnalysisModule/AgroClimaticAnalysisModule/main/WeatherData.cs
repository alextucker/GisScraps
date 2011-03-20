using System;
namespace AgroClimaticAnalysisModule
{
	public class WeatherData
	{
		public int rowid = 0;
		public int stationRowID = 0;
		
		public int month;
		public double tempMax;
		public double tempMin;
		public double tempAvg;
		public double humidity;
		public double wind;
		public double sun;
		public double radiation;
		public double eto;
		public double rain;
		public double effRain;
		
		// Plain Constructor
		public WeatherData() { }
		
		// Constructor for use with DB
		public WeatherData (int rowid, int stationRowID, int month, 
		                    double tempMax, double tempMin, double humidity,
		                    double wind, double sun, double radiation, 
		                    double eto, double rain, double effRain)
		{
			this.rowid = rowid;
			this.stationRowID = stationRowID;
			this.month = month;
			this.tempMax = tempMax;
			this.tempMin = tempMin;
			this.humidity = humidity;
			this.wind = wind;
			this.sun = sun;
			this.radiation = radiation;
			this.eto = eto;
			this.rain = rain;
			this.effRain = effRain;
			this.tempAvg = CalculateAvgTemp(this.tempMin, this.tempMax);
		}
		
		// Constructor for use without DB
		public WeatherData (int month, 
		                    double tempMax, double tempMin, double humidity,
		                    double wind, double sun, double radiation, 
		                    double eto, double rain, double effRain)
		{
			this.month = month;
			this.tempMax = tempMax;
			this.tempMin = tempMin;
			this.humidity = humidity;
			this.wind = wind;
			this.sun = sun;
			this.radiation = radiation;
			this.eto = eto;
			this.rain = rain;
			this.effRain = effRain;
			this.tempAvg = CalculateAvgTemp(this.tempMin, this.tempMax);
		}
		
		public double CalculateAvgTemp(double min, double max)
		{
			return (min + max) / 2;
		}
	}
}

