using System;
using System.Collections;
namespace AreaDefinitionModule
{
	public class Polygon
	{
		public ArrayList coords = new ArrayList();
		public Polygon ()
		{
			
		}
		
		public virtual void AddCoord(Coord c) {	
			coords.Add(c);
		}
		
		public virtual void AddCoord(double x, double y) {
			Coord c = new Coord(x,y);
			this.coords.Add(c);
		}
		
	}
}

