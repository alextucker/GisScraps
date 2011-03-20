using System;
using System.Collections;

// Declare Enums

public enum ClimaticDivison {
	Tropics,
	SubtropicWinterRainfall,
	SubtropicSummerRainfall,
	Temperate
}



namespace AgroClimaticAnalysisModule
{
	public class MetStation
	{
		public int rowid;
		
		public string climwatID;
		public string stationName;
		public string countryID;
		public string countryName;
		public double latitude;
		public double longitude;
		public double altitude;
		public double yearlyTempAvg;
		
		public double avgMinTemp;
		ClimaticDivison climaticDivision;
		
		public ArrayList weatherData = new ArrayList();
		
		//Plain Constructor
		public MetStation() { }
		
		// Constructor for use with data from DB
		public MetStation (int rowid, string climwatID, string stationName, 
		                   string countryID, string countryName, 
		                   double longitude, double latitude, 
		                   double altitude)
		{
			this.rowid = rowid;
			this.climwatID = climwatID;
			this.stationName = stationName;
			this.countryID = countryID;
			this.countryName = countryName;
			this.longitude = longitude;
			this.latitude = latitude;
			this.altitude = altitude;
		}
		
		
		// Constructor for use with data not from DB
		public MetStation (string climwatID, string stationName, 
		                   string countryID, string countryName, 
		                   double longitude, double latitude, 
		                   double altitude)
		{
			this.climwatID = climwatID;
			this.stationName = stationName;
			this.countryID = countryID;
			this.countryName = countryName;
			this.longitude = longitude;
			this.latitude = latitude;
			this.altitude = altitude;
		}
		
		public double AvgTemp (ArrayList data) {
			if (data == null) {
				throw new Exception("No Weather Data");	
			} else if (data.Count != 12) {
				throw new Exception("Weather Data is not over 12 month period.");
			}
			
			double tempAvgCount = 0;
			foreach (WeatherData wd in data) {
				tempAvgCount += wd.tempAvg;
			}
			
			return tempAvgCount/12;
		}
		
		public ClimaticDivison CalcClimaticDivision(double avgTemp, double altitude)
		{
			// Adjust for sea level
			double adjustedTemp = AdjustTempForSeaLevel(avgTemp, altitude); 
			
			
			// TODO: Clarify this division with Raul.
			if (adjustedTemp >= 18) {
				return ClimaticDivison.Tropics;	
			} else if (adjustedTemp < 18) {
				return ClimaticDivison.SubtropicSummerRainfall;	
			}
			
			return ClimaticDivison.Tropics;
		}
		
		public double AdjustTempForSeaLevel(double temp, double altitude) 
		{
			// Adjust for sea level
			double seaLevelAdjust = 0.0065;
			double adjustedTemp = temp - (altitude * seaLevelAdjust);
			return adjustedTemp;
		}
	}
}

