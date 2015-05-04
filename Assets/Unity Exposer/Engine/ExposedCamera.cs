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
		        Type cameraType = typeof (Camera);

		        PropertyInfo propertyInfo = cameraType.GetProperty("PreviewCullingLayer", BindingFlags.NonPublic | BindingFlags.Static);
		        return (int)propertyInfo.GetGetMethod().Invoke(null, null);
		    }
		}
	}
}