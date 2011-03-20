using System;
using NUnit.Framework;
namespace AgroClimaticAnalysisModule
{
	[TestFixture()]
	public class MetStation_Construct
	{
		[Test()]
		public void MetStation_Construct_NoDB ()
		{
			// Set up params for constructor
			string climwatid = "ClimwatID";
			string stationName = "StationName";
			string countryID = "CountryID";
			string countryName = "CountryName";
			double longitude = 1.2;
			double latitude = 3.4;
			double altitude = 5.6;
			
			// Construct
			MetStation ms = new MetStation(climwatid, stationName, countryID, countryName, longitude, latitude, altitude);
			                               
			// Assert
			Assert.AreEqual(climwatid, ms.climwatID);
			Assert.AreEqual(stationName, ms.stationName);
			Assert.AreEqual(countryID, ms.countryID);
			Assert.AreEqual(countryName, ms.countryName);
			Assert.AreEqual(longitude, ms.longitude);
			Assert.AreEqual(latitude, ms.latitude);
			Assert.AreEqual(altitude, ms.altitude);
		}
		
		[Test()]
		public void MetStation_Construct_WithDB ()
		{
			// Set up params for constructor
			int rowID = 1;
			string climwatid = "ClimwatID";
			string stationName = "StationName";
			string countryID = "CountryID";
			string countryName = "CountryName";
			double longitude = 1.2;
			double latitude = 3.4;
			double altitude = 5.6;
			
			// Construct
			MetStation ms = new MetStation(rowID, climwatid, stationName, countryID, countryName, longitude, latitude, altitude);
			                               
			// Assert
			Assert.AreEqual(rowID, ms.rowid);
			Assert.AreEqual(climwatid, ms.climwatID);
			Assert.AreEqual(stationName, ms.stationName);
			Assert.AreEqual(countryID, ms.countryID);
			Assert.AreEqual(countryName, ms.countryName);
			Assert.AreEqual(longitude, ms.longitude);
			Assert.AreEqual(latitude, ms.latitude);
			Assert.AreEqual(altitude, ms.altitude);
		}
	}
}

