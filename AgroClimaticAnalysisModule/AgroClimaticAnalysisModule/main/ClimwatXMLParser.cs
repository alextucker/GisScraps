using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Xml.XPath;
using System.Xml.Linq;

namespace AgroClimaticAnalysisModule
{
	public class ClimwatXMLParser
	{
		public ClimwatXMLParser ()
		{
			
			
		}
		
		public void ParseXML() 
		{
			ClimateDatabase db = new ClimateDatabase();
			int rowid = 0;
			foreach (XElement stationElement in XElement.Load("newaab").Elements("Station")) 
			{
					Console.WriteLine("Station ID:  " + stationElement.Element("StationID").Value);
				Console.WriteLine("Station Name:  " + stationElement.Element("StationName").Value);
					Console.WriteLine("Country ID:  " + stationElement.Element("CountryID").Value);
					Console.WriteLine("CountryName:  " + stationElement.Element("CountryName").Value);
					Console.WriteLine("Latitude:  " + stationElement.Element("Latitude").Value);
					Console.WriteLine("Longitude:  " + stationElement.Element("Longitude").Value);
					Console.WriteLine("Altitude:  " + stationElement.Element("Altitude").Value);
					Console.WriteLine(".......................");
					
				string stationid = (string)stationElement.Element("StationID").Value;
				string stationname = (string)stationElement.Element("StationName").Value;
				string countryid = (string)stationElement.Element("CountryID").Value;
				string countryname = (string)stationElement.Element("CountryName").Value;
				double latitude = double.Parse(stationElement.Element("Latitude").Value);
				double longitude = double.Parse(stationElement.Element("Longitude").Value);
				double altitude = double.Parse(stationElement.Element("Altitude").Value);
				
				//ClimateDatabase db = new ClimateDatabase();
				rowid = db.AddMetStation(stationid, stationname, countryid, countryname,latitude,longitude,altitude);
				
				
					// Loop thourough months and get weather data
					foreach (XElement months in stationElement.Elements("Months"))
					{
						
						foreach (XElement month in months.Elements("Month"))
						{
							Console.WriteLine("Month:  " + month.Attribute("id").Value);
							Console.WriteLine("    TempMax: " + month.Element("TempMax").Value);
							Console.WriteLine("    TempMin: " + month.Element("TempMin").Value);
							Console.WriteLine("    Humidity: " + month.Element("Humidity").Value);
							Console.WriteLine("    Wind: " + month.Element("Wind").Value);
							Console.WriteLine("    Sunshine: " + month.Element("Sunshine").Value);
							Console.WriteLine("    Radiation: " + month.Element("Radiation").Value);
							Console.WriteLine("    Eto: " + month.Element("ETo").Value);
							Console.WriteLine("    Rain: " + month.Element("Rain").Value);
							Console.WriteLine("    EffRain: " + month.Element("EffRain").Value);
						
							int monthid = int.Parse(month.Attribute("id").Value);
							double tempmax = double.Parse(month.Element("TempMax").Value);
							double tempmin = double.Parse(month.Element("TempMin").Value);
							double humidity = double.Parse(month.Element("Humidity").Value);
							double wind = double.Parse(month.Element("Wind").Value);
							double sunshine = double.Parse(month.Element("Sunshine").Value);
							double radiation = double.Parse(month.Element("Radiation").Value);
							double eto = double.Parse(month.Element("ETo").Value);
							double rain = double.Parse(month.Element("Rain").Value);
							double effrain = double.Parse(month.Element("EffRain").Value);
						
							db.AddWeatherData(rowid,monthid,tempmax,tempmin,humidity,wind,sunshine,radiation,eto,rain,effrain);
						
						}
					Console.WriteLine("=================================");
					}
			}	
			
		}
			
	}
}

