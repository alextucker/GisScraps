using System;
using NUnit.Framework;
namespace AreaDefinitionModule
{
	[TestFixture()]
	public class Coord_Creation
	{
		[Test()]
		public void Coord_Construct ()
		{
			Coord c = new Coord(1,2);
			Assert.AreEqual(1,c.X);
			Assert.AreEqual(2,c.Y);
		}
	}
}

