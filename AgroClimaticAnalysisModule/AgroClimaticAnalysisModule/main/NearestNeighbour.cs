using System;
using AreaDefinitionModule;
using System.Collections;
namespace AgroClimaticAnalysisModule
{
	public class NearestNeighbour : ISpatialInterpolation
	{
		public NearestNeighbour(Polygon e, Polygon a, double r)
		{
			try {
				this.SetArea(a);
				this.SetExtreme(e);
				this.SetResolution(r);
			} catch (Exception ex) {
			 	throw ex;	
			}
		}
		
		public override ArrayList GenerateCells(Polygon a, double r)
		{
			ArrayList cells = new ArrayList();
			return cells;
		}
		
		
		
	}
}

