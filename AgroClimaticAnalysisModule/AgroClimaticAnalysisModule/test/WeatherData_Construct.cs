using System;
using NUnit.Framework;
namespace AgroClimaticAnalysisModule
{
	[TestFixture()]
	public class WeatherData_Construct
	{
		[Test()]
		public void WeatherData_Construct_NoDB ()
		{
			// Set up params for constructor
			int month = 1;
			double tempMin = 2;
			double tempMax = 3;
			double humidity = 4;
			double wind = 5;
			double sun = 6;
			double radiation = 7;
			double eto = 8;
			double rain = 9;
			double effRain = 10;
			
			//Construct
			WeatherData wd = new WeatherData(month, tempMax, tempMin, humidity, wind, sun, radiation, eto, rain, effRain);
			
			// Assert
			Assert.AreEqual(month, wd.month);
			Assert.AreEqual(tempMin, wd.tempMin);
			Assert.AreEqual(tempMax, wd.tempMax);
			Assert.AreEqual(humidity, wd.humidity);
			Assert.AreEqual(wind, wd.wind);
			Assert.AreEqual(sun, wd.sun);
			Assert.AreEqual(radiation, wd.radiation);
			Assert.AreEqual(eto, wd.eto);
			Assert.AreEqual(rain, wd.rain);
			Assert.AreEqual(effRain, wd.effRain);
		}
		
		[Test()]
		public void WeatherData_Construct_WithDB ()
		{
			// Set up params for constructor
			int rowID = 1;
			int stationID = 2;
			int month = 1;
			double tempMin = 2;
			double tempMax = 3;
			double humidity = 4;
			double wind = 5;
			double sun = 6;
			double radiation = 7;
			double eto = 8;
			double rain = 9;
			double effRain = 10;
			
			//Construct
			WeatherData wd = new WeatherData(rowID, stationID, month, tempMax, tempMin, humidity, wind, sun, radiation, eto, rain, effRain);
			
			// Assert
			Assert.AreEqual(rowID, wd.rowid);
			Assert.AreEqual(stationID, wd.stationRowID);
			Assert.AreEqual(month, wd.month);
			Assert.AreEqual(tempMin, wd.tempMin);
			Assert.AreEqual(tempMax, wd.tempMax);
			Assert.AreEqual(humidity, wd.humidity);
			Assert.AreEqual(wind, wd.wind);
			Assert.AreEqual(sun, wd.sun);
			Assert.AreEqual(radiation, wd.radiation);
			Assert.AreEqual(eto, wd.eto);
			Assert.AreEqual(rain, wd.rain);
			Assert.AreEqual(effRain, wd.effRain);
		}
	}
}

