using System;
using System.Collections;
using AreaDefinitionModule;

namespace AgroClimaticAnalysisModule
{
	public abstract class ISpatialInterpolation
	{	
		
		private Polygon exteme = null;
		private Polygon area = null;
		private double resolution = 0;
		
		public virtual void SetExtreme(Polygon p)
		{
			if (p.coords.Count < 3) {
				throw new Exception("Polygon requires 3 or more vertacies");	
			} else {
				this.exteme = p;	
			}
		}
		
		public virtual void SetArea(Polygon p) 
		{
			if (p.coords.Count < 3)
			{
				throw new Exception("Polygon requires 3 or more vertacies");	
			} else {
				this.area = p;	
			}
		}
		
		public virtual void SetResolution(double r)
		{
			if (r <= 0)
			{
				throw new Exception("Resolution must be greated than zero");	
			} else {
				this.resolution = r;
			}	
		}
		
		public abstract ArrayList GenerateCells(Polygon a, double r);
		
		
	}
}

