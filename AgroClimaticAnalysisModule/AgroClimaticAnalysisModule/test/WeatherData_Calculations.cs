using System;
using NUnit.Framework;
namespace AgroClimaticAnalysisModule
{
	[TestFixture()]
	public class WeatherData_Calculations
	{
		[Test()]
		public void WeatherData_AvgTemp_Simple ()
		{
			WeatherData wd = new WeatherData();
			double result = wd.CalculateAvgTemp(1,1);
			Assert.AreEqual(1, result);
		}
		
		[Test()]
		public void WeatherData_AvgTemp_Complex ()
		{
			WeatherData wd = new WeatherData();
			double result = wd.CalculateAvgTemp(23,15);
			Assert.AreEqual(19, result);
		}
	}
}

