namespace UnityEngine.Exposer
{
	using UnityEngine;
	using System;
	using System.Reflection;
	
	public class ExposedCamera
	{		
		public static int PreviewCullingLayer
		{
		    get
		    {
		        Type cameraType = typeof(Camera);

		        PropertyInfo propertyInfo = cameraType.GetPropertyAll("PreviewCullingLayer");
		        return propertyInfo.GetGetMethod().Invoke<int>();
		    }
		}
	}
}