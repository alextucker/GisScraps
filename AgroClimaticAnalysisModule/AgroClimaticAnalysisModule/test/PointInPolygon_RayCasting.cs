using System;
using NUnit.Framework;
using AreaDefinitionModule;
namespace AgroClimaticAnalysisModule
{
	[TestFixture()]
	public class PointInPolygon_RayCasting
	{
		[Test()]
		public void RayCasting_SimpleDiamond_Pass ()
		{
			Polygon p = new Polygon();
			p.AddCoord(0,1);
			p.AddCoord(1,0);
			p.AddCoord(-1,0);
			p.AddCoord(0,-1);
			Console.WriteLine("w---t");
			try {
				PointInPolygon pip = new PointInPolygon(p, 0, 0);
				bool result = pip.Verify();
				Assert.AreEqual(true, result);
			} catch (Exception e) {
				Console.WriteLine("Exception:  " + e.Message);
				Assert.Fail("No exception expected");
			}
		}
	}
}

