using System;
using AreaDefinitionModule;
using System.Collections;
using System.Collections.Generic;
namespace AgroClimaticAnalysisModule
{
	public class PointInPolygon
	{
		double testX = 0;
		double testY = 0;
		
		Polygon poly = null;
			
		List<double> listX = new List<double>();
		List<double> listY = new List<double>();
		
		public PointInPolygon (Polygon p, double x, double y)
		{
			try {
				this.SetPolygon(p);
				this.testX = x;
				this.testY = y;
			} catch (Exception e) {
				Console.WriteLine("Derp");
				throw e;	
			}
		}
		
		private void SetPolygon(Polygon p) 
		{
			if (p.coords.Count < 3) {
				Console.WriteLine("Derp");
				throw new Exception("Polygon must have atleast 3 vertacies.");
			} else {
				this.poly = p;	
			}
		}
		
		public void SplitPoly(Polygon p)
		{
			foreach (Coord c in p.coords) {
				this.listX.Add(c.X);
				this.listY.Add(c.Y);
			}
		}
		
		public bool Verify() 
		{
			this.SplitPoly(this.poly);
			
			// Implementation of PNPOLY.
			// Credits: http://www.ecse.rpi.edu/Homepages/wrf/Research/Short_Notes/pnpoly.html
			int i, j = 0;
			for (i=0, j=this.listX.Count-1; i < this.listX.Count; j = i++)
			{
				if ( ((this.listY[i] > this.testY) != (this.listY[j] > this.testY) &&
				      (this.testX < (this.listX[j] - this.listX[i]) * (this.testY - this.listY[i]) / 
				      (this.listY[j] - this.listY[i]) + this.listX[i])  ) )
				{
					return false;
				}
			}
			return true;
		}
		
		
	}
}

