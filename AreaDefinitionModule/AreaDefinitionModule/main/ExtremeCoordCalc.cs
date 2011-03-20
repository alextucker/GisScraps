using System;
namespace AreaDefinitionModule
{
	public class ExtremeCoordCalc
	{
		public Polygon original;
		
		// Default value
		public double bound = 50;
		
		// Min/Max coords
		public double minX = 100;
		public double maxX = 0;
		public double minY = 100;
		public double maxY = 0;
		
		
		public ExtremeCoordCalc (Polygon p)
		{
			this.original = p;
		}
		
		public ExtremeCoordCalc (Polygon p, double bound)
		{
			this.bound = bound;
			this.original = p;
		}
		
		public Polygon GetExtremeBounds () 
		{
			// Max X, Min X, Max Y and Min Y in the original poly.
			try {
				this.FindMinMax(this.original);
			} catch (Exception e) {
				// If poly has no points, throw it up the stack
				throw e;
			}
			
			
			// Expand bounds
			this.minX += -bound;
			this.maxX += bound;
			this.minY += -bound;
			this.maxY += bound;
			
			// Create new poly
			Polygon extreme =  new Polygon();
			extreme.AddCoord(minX,maxY);
			extreme.AddCoord(maxX,maxY);
			extreme.AddCoord(maxX,minY);
			extreme.AddCoord(minX,minY);
			
			return extreme;
		}
		
		public void FindMinMax(Polygon p) {
			
			// Check if there are no points to the poly
			if (p.coords.Count == 0) {
				throw new System.Exception("Polygon has no points.");	
			}
			
			// Loop through the coords and test each against the max/min conditions
			foreach (Coord c in p.coords) 
			{
				// Test min X
				if (c.X < this.minX) {
					this.minX = c.X;
				}
				
				// Test max X
				if (c.X > this.maxX) {
					this.maxX = c.X;
				}
				
				// Test min Y
				if (c.Y < this.minY) {
					this.minY = c.Y;
				}
				
				// Test max Y
				if (c.Y > this.maxY) {
					this.maxY = c.Y;
				}
			}
		}
		
		
		
	}
}

