using System;
using NUnit.Framework;
namespace AgroClimaticAnalysisModule
{
	[TestFixture()]
	public class MetStation_Calculations
	{
		[Test()]
		public void MetStation_AvgTemp_NoTempData ()
		{
			MetStation m = new MetStation();
			// Add no weather data
			
			try {
				double avgMin = m.AvgTemp(m.weatherData);
				Assert.Fail("Excepted Exception");
			} catch (Exception e) {
				Console.WriteLine(e.Message);
			}
		}
		
		[Test()]
		public void MetStation_AvgTemp_LessThan12Months ()
		{
			MetStation m = new MetStation();
			WeatherData wd = new WeatherData();
			// Add less than 12 weather data points
			for (int i = 1; i <= 2; i++) {
				m.weatherData.Add(wd);	
			}
			
			try {
				double avgMin = m.AvgTemp(m.weatherData);
				Assert.Fail("Excepted Exception");
			} catch (Exception e) {
				Console.WriteLine(e.Message);
			}
		}
		
		[Test()]
		public void MetStation_AvgTemp_MoreThan12Months ()
		{
			MetStation m = new MetStation();
			WeatherData wd = new WeatherData();
			// Add less than 12 weather data points
			for (int i = 1; i <= 13; i++) {
				m.weatherData.Add(wd);	
			}
			
			try {
				double avgMin = m.AvgTemp(m.weatherData);
				Assert.Fail("Excepted Exception");
			} catch (Exception e) {
				Console.WriteLine(e.Message);
			}
		}
		
		[Test()]
		public void MetStation_AvgTemp_12Months ()
		{
			MetStation m = new MetStation("a", "b", "c", "d", 1, 2, 3);
			WeatherData wd = new WeatherData();
			wd.tempAvg = 2;
			// Add less than 12 weather data points
			for (int i = 1; i <= 12; i++) {
				m.weatherData.Add(wd);	
			}
			
			try {
				double avgMin = m.AvgTemp(m.weatherData);
			} catch (Exception e) {
				Console.WriteLine(e.Message);
				Assert.Fail("No Exception Expected");
			}
		}
		
		[Test()]
		public void MetStation_AvgTemp_AvgTestSimple ()
		{
			MetStation m = new MetStation();
			WeatherData wd = new WeatherData();
			wd.tempAvg = 2;
			// Add less than 12 weather data points
			for (int i = 1; i <= 12; i++) {
				m.weatherData.Add(wd);	
			}
			
			try {
				double avgMin = m.AvgTemp(m.weatherData);
				Assert.AreEqual(2, avgMin);
			} catch (Exception e) {
				Console.WriteLine(e.Message);
				Assert.Fail("No Exception Expected");
			}
		}
		
		[Test()]
		public void MetStation_SeaLevelAdjust_ZeroAltitude() 
		{
			// Dumby MetStation
			MetStation ms = new MetStation("a", "b", "c", "d", 1,2,0);
			double altitude = 0;
			double temp = 5;
			double adjusted = ms.AdjustTempForSeaLevel(temp, altitude);
			Assert.AreEqual(temp, adjusted);
		}
		
		[Test()]
		public void MetStation_SeaLevelAdjust_TenAltitude() 
		{
			// Dumby MetStation
			MetStation ms = new MetStation("a", "b", "c", "d", 1,2,0);
			double altitude = 10;
			double temp = 5;
			double adjusted = ms.AdjustTempForSeaLevel(temp, altitude);
			Assert.AreEqual(4.935, adjusted);
		}
		
		[Test()]
		public void MetStation_SeaLevelAdjust_HundredAltitude() 
		{
			// Dumby MetStation
			MetStation ms = new MetStation("a", "b", "c", "d", 1,2,0);
			double altitude = 100;
			double temp = 5;
			double adjusted = ms.AdjustTempForSeaLevel(temp, altitude);
			Assert.AreEqual(4.35, adjusted);
		}
		
		[Test()]
		public void MetStation_SeaLevelAdjust_NegTenAltitude() 
		{
			// Dumby MetStation
			MetStation ms = new MetStation("a", "b", "c", "d", 1,2,0);
			double altitude = -10;
			double temp = 5;
			double adjusted = ms.AdjustTempForSeaLevel(temp, altitude);
			Assert.AreEqual(5.065, adjusted);
		}
		
		[Test()]
		public void MetStation_SeaLevelAdjust_NegHundredAltitude() 
		{
			// Dumby MetStation
			MetStation ms = new MetStation("a", "b", "c", "d", 1,2,0);
			double altitude = -100;
			double temp = 5;
			double adjusted = ms.AdjustTempForSeaLevel(temp, altitude);
			Assert.AreEqual(5.65, adjusted);
		}
		
	}
}

