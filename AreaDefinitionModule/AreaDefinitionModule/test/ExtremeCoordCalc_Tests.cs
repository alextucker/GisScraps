using System;
using NUnit.Framework;
namespace AreaDefinitionModule
{
	[TestFixture()]
	public class ExtremeCoordCalc_Tests
	{
		[Test()]
		public void ExtremeCoordCalc_Constructor_A ()
		{
			// Create simple poly
			Polygon p = new Polygon();
			p.AddCoord(1,2);
			p.AddCoord(3,4);
			
			// Create ExtremeCoordcalc
			ExtremeCoordCalc calc = new ExtremeCoordCalc(p);
			
			// Grab the coords from the original poly
			Coord a = (Coord)calc.original.coords[0];
			Coord b = (Coord)calc.original.coords[1];
			
			// Assert
			Assert.AreEqual(1,a.X);
			Assert.AreEqual(2,a.Y);
			Assert.AreEqual(3,b.X);
			Assert.AreEqual(4,b.Y);
			Assert.AreEqual(50, calc.bound);	
		}
		
		[Test()]
		public void ExtremeCoordCalc_Constructor_B ()
		{
			// Create simple poly
			Polygon p = new Polygon();
			p.AddCoord(1,2);
			p.AddCoord(3,4);
			
			Double newbound = 10;
			
			// Create ExtremeCoordcalc
			ExtremeCoordCalc calc = new ExtremeCoordCalc(p, newbound);
			
			// Grab the coords from the original poly
			Coord a = (Coord)calc.original.coords[0];
			Coord b = (Coord)calc.original.coords[1];
			
			// Assert
			Assert.AreEqual(1,a.X);
			Assert.AreEqual(2,a.Y);
			Assert.AreEqual(3,b.X);
			Assert.AreEqual(4,b.Y);
			Assert.AreEqual(10, calc.bound);
		}
		
		[Test()]
		public void ExtremeCoordCalc_FindMinMax_SimpleDiamond() 
		{
			// Create a simple diamond poly around the axis
			Polygon p = new Polygon();
			p.AddCoord(0,1); // North
			p.AddCoord(2,0); // East
			p.AddCoord(0,-3); // South
			p.AddCoord(-4,0); // West
			
			ExtremeCoordCalc calc = new ExtremeCoordCalc(p);
			calc.FindMinMax(calc.original);
			
			// Assert
			Assert.AreEqual(1, calc.maxY);
			Assert.AreEqual(2, calc.maxX);
			Assert.AreEqual(-3, calc.minY);
			Assert.AreEqual(-4, calc.minX);
		}
		
		[Test()]
		public void ExtremeCoordCalc_ExtremePoly_SimpleDiamond() 
		{
			// Create a simple diamond poly around the axis
			Polygon p = new Polygon();
			p.AddCoord(0,1); // North
			p.AddCoord(2,0); // East
			p.AddCoord(0,-3); // South
			p.AddCoord(-4,0); // West
			
			ExtremeCoordCalc calc = new ExtremeCoordCalc(p);
			Polygon extreme = calc.GetExtremeBounds();
			
			// Grab coords off extreme poly
			Coord a = (Coord)extreme.coords[0];
			Coord b = (Coord)extreme.coords[1];
			Coord c = (Coord)extreme.coords[2];
			Coord d = (Coord)extreme.coords[3];
			
			// Assert
			Assert.AreEqual(-54, a.X);
			Assert.AreEqual(51, a.Y);
			Assert.AreEqual(52, b.X);
			Assert.AreEqual(51, b.Y);
			Assert.AreEqual(52, c.X);
			Assert.AreEqual(-53, c.Y);
			Assert.AreEqual(-54, d.X);
			Assert.AreEqual(-53, d.Y);
		}
		
		[Test()]
		//[ExpectedException(typeof(System.Exception), ExpectedMessage = "Polygon has no points." )]
		public void ExtremeCoordCalc_NoPointPoly()
		{
			// Create a poly and add no points
			Polygon poly = new Polygon();
			
			ExtremeCoordCalc calc = new ExtremeCoordCalc(poly);
			
			try {
				calc.GetExtremeBounds();	
				Assert.Fail("Exception expected");
			} catch (Exception e) {
				
			}
			
		}
		
		
	}
}

