using System;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections;
using AreaDefinitionModule;

namespace AgroClimaticAnalysisModule
{

//			string sql = 	"CREATE TABLE stations(" +
//							"id integer primary key autoincrement," +
//							"climwat_id string," +
//							"station_name string," +
//							"country_id string," +
//							"country_name string," +
//							"latitude real," +
//							"longitude real," +
//							"altitude real);";
			
//			string sql = 	"CREATE TABLE weather_data(" +
//							"id integer primary key autoincrement," +
//							"station_id integer," +
//							"month integer," +
//							"temp_max real," +
//							"temp_min real," +
//							"humidity real," +
//							"wind real," +
//							"sun real," +
//							"radiation real," +
//							"eto real," +
//							"rain real," +
//							"eff_rain real," + 
//							"FOREIGN KEY (station_id) REFERENCES stations(id));";
	
	public class ClimateDatabase
	{	
		// Defaul connection
		public string connection = "URI=file:climate.db";
		
		public SqliteConnection conn;
		public SqliteCommand command;
		
		
		public ClimateDatabase ()
		{
		}
		
		public static void Main() 
		{
//			ClimateDatabase db = new ClimateDatabase();
//			int row = db.AddMetStation("ID22", "Station1", "ZackLand", "United States", 12.1, 13.4, 14.5);
//			Console.WriteLine(row);
//			db.AddWeatherData(10,1,24.4,18.2,2,3,4,5,6,7,8);
			
			ClimateDatabase db = new ClimateDatabase();
			try {
				db.AddWeatherData(1,2,3,4,5,6,7,8,9,10,11);
			} catch (Exception e) {
				Console.WriteLine(e.Message);	
			}
		}
		
		public int AddMetStation(string climwat_id, string station_name, string country_id, 
		                          string country_name, double latitude, double longitude, 
		                          double altitude)
		{
			// Standardize all strings to uppercase
			string climwat = climwat_id.ToUpper().Trim();
			string station = station_name.ToUpper().Trim();
			string c_id = country_id.ToUpper().Trim();
			string c_name = country_name.ToUpper().Trim();
			
			string sql =	"INSERT INTO stations(" +
				"climwat_id, station_name, country_id, country_name, latitude, longitude, altitude)" +
				" VALUES ('" + climwat + "', '" + station + "', '"+ c_id +"', '"
					+ c_name +"', "+ latitude +", "+ longitude +", "+ altitude+" );";
			
			try {
				this.OpenConnection();
				this.ExecuteNonQuery(sql);
				
				sql = "SELECT * from stations order by id desc limit 1";
				SqliteDataReader reader = this.ExecuteQuery(sql);
				int rowid = 1;
				while (reader.Read()) {
					rowid = reader.GetInt32(0);
				}
			
				// Close Connections
				reader.Close();
				reader = null;
				this.CloseConnection();
				
				return rowid;
			} catch (Exception e) { // Cannot connect to DB
				throw e;
			}	
		}
		
		public MetStation GetMetStation(string stationName){
			try {
				this.OpenConnection();
				string query = "SELECT * FROM stations WHERE station_name='" + stationName.Trim().ToUpper() + "'";

				MetStation station = null;
				SqliteDataReader reader = this.ExecuteQuery(query);	
				
				while (reader.Read())
				{
					station = new MetStation(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), 
		                                    reader.GetString(3), reader.GetString(4), reader.GetDouble(5), 
		                                    reader.GetDouble(6), reader.GetDouble(7));
				}
				
				// Close Reader and Connection.
				// Important to do it here because GetWeatherData will Open/Close
				// Its own DB connection
				this.CloseConnection();
				reader.Close();
				reader = null;
				
				// No rows returned
				if (station == null) {
					throw new Exception("No MetSations match those parameters.");	
				} else {
					// Get weather station data
					ArrayList dataList = this.GetWeatherData(station.rowid);
					station.weatherData = dataList;

					return station;	
				}
			} catch (Exception e) { // Could not connect to DB
				throw e;	
			}
		}
		
		public ArrayList GetMetStation(Polygon extreme) 
		{
			// Set X/Y Min/Max based on extreme coords poly
			// Loop through for more redundancy
			double maxX = 0;
			double minX = 200;
			double maxY = 0;
			double minY = 200;
			
			
			// TODO: Refactor this statement
			foreach (Coord c in extreme.coords)
			{
				// Test min X
				if (c.X < minX) {
					minX = c.X;
				}
				// Test max X
				if (c.X > maxX) {
					maxX = c.X;
				}
				// Test min Y
				if (c.Y < minY) {
					minY = c.Y;
				}
				// Test max Y
				if (c.Y > maxY) {
					maxY = c.Y;
				}	
			}
			
			// Set up Query
			string query = "SELECT * FROM stations WHERE (longitude BETWEEN " + minY + " AND " + maxY + ") AND (latitude BETWEEN " + minX + " AND " + maxX + ");";

			ArrayList list = new ArrayList();
			MetStation station = null;
			try {
				this.OpenConnection();
				SqliteDataReader reader = this.ExecuteQuery(query);
	
				while (reader.Read())
				{
					station = new MetStation(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), 
		                                    reader.GetString(3), reader.GetString(4), reader.GetDouble(5), 
		                                    reader.GetDouble(6), reader.GetDouble(7));
					list.Add(station);
				}
				
				// Close reader and connection
				reader.Close();
				reader = null;
				this.CloseConnection();
				
				// No rows returned
				if (station == null) {
					throw new Exception("No MetSations match those parameters.");	
				} else { // Add weather data to each station
					foreach (MetStation ms in list)
					{
						ms.weatherData = this.GetWeatherData(ms.rowid);
					}
				}
	
				return list;
			} catch (Exception e) {
				throw e;
			}	
		}
		
		public void AddWeatherData(int station_id, int month, double temp_max, double temp_min,
		                           double humidity, double wind, double sun, double radiation,
		                           double eto, double rain, double eff_rain) 
		{		
			string sql =	"INSERT INTO weather_data(" +
				"station_id, month, temp_max, temp_min, humidity, wind, sun, radiation," +
				"eto, rain, eff_rain)" +
				" VALUES (" + station_id + ", " + month + ", "+ temp_max +", "
					+ temp_min +", "+ humidity +", "+ wind +", "+ sun +", " +
					+ radiation + ", " + eto + ", " + rain + ", " + eff_rain + ");";
			
			try {
				this.OpenConnection();
				this.ExecuteNonQuery(sql);
				this.CloseConnection();
			} catch (Exception e) {
				throw e;	
			}
		}
		
		public ArrayList GetWeatherData(int rowid) 
		{
			string query = "SELECT * FROM weather_data WHERE station_id=" + rowid + " ORDER BY month ASC";
			
			try {
				this.OpenConnection();
				
				SqliteDataReader reader = this.ExecuteQuery(query);
				WeatherData data = null;
				ArrayList list = new ArrayList();
				
				while (reader.Read())
				{
					data = new WeatherData(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDouble(3), 
		                       reader.GetDouble(4), reader.GetDouble(5), reader.GetDouble(6), reader.GetDouble(7), 
		                       reader.GetDouble(8), reader.GetDouble(9), reader.GetDouble(10), reader.GetDouble(11));
					list.Add(data);
				}
						
				if (data == null) {
					throw new Exception("No WeatherData matches those parameters.");	
				}
				
				// Close Reader and Connection
				reader.Close();
				reader = null;
				this.CloseConnection();
				
				return list;
				
			} catch (Exception e) { // Cannot connect to DB
				throw e;	
			}	
		}
		
		public SqliteDataReader ExecuteQuery(string query)
		{
			this.command = new SqliteCommand(query.Trim(), this.conn);
			SqliteDataReader reader = this.command.ExecuteReader();
			return reader;
		}
		
		public void ExecuteNonQuery(string query)
		{
			this.command = new SqliteCommand(query.Trim(), this.conn);
			this.command.ExecuteNonQuery();
		}
		
		public void OpenConnection() {
			this.conn = new SqliteConnection(this.connection);
			try  {
				this.conn.Open();
			} catch (Exception e) {
				throw e;	
			}
		}
		
		public void CloseConnection() {
			this.command = null;
			this.conn.Close();
			this.conn = null;
		}
		
		public void TestConn() {
			this.OpenConnection();
			SqliteDataReader r = this.ExecuteQuery("SELECT * FROM stations");
			while (r.Read())
			{
				Console.WriteLine(r.GetString(3));	
			}
			this.CloseConnection();
		}
		
	}
}

