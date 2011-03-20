using System;
using NUnit.Framework;

namespace AreaDefinitionModule
{
	[TestFixture()]
	public class Polygon_Creation
	{
		[Test()]
		public void Polygon_Add3Coords ()
		{
			// Create Coords to add to Polygon
			Coord a = new Coord(1,2);
			Coord b = new Coord(3,4);
			Coord c = new Coord(5,6);
			
			// Create poly and add coords
			Polygon poly = new Polygon();
			poly.AddCoord(a);
			poly.AddCoord(b);
			poly.AddCoord(c);
			
			// Check coords
			Assert.AreEqual(a,poly.coords[0]);
			Assert.AreEqual(b,poly.coords[1]);
			Assert.AreEqual(c,poly.coords[2]);
		}
		
		[Test()]
		public void Polygon_Add3Points () 
		{
			// Create poly and add points
			Polygon poly = new Polygon();
			poly.AddCoord(1,2);
			poly.AddCoord(3,4);
			poly.AddCoord(5,6);
			
			// Create coords from poly
			Coord a = (Coord)poly.coords[0];
			Coord b = (Coord)poly.coords[1];
			Coord c = (Coord)poly.coords[2];
			
			// Examine coords and assert
			Assert.AreEqual(1, a.X);
			Assert.AreEqual(2, a.Y);
			Assert.AreEqual(3, b.X);
			Assert.AreEqual(4, b.Y);
			Assert.AreEqual(5, c.X);
			Assert.AreEqual(6, c.Y);
		}
		
	}
}

