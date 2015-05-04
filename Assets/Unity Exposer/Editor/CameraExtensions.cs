namespace UnityExposer.Editor
{
	using UnityEngine;
	using System;
	using System.Collections;
	using System.Reflection;
	
	public class CameraExtensions
	{		
		public static int GetPreviewCullingLayer()
		{
			Type cameraType = typeof(UnityEngine.Camera);

			PropertyInfo propertyInfo = cameraType.GetProperty("PreviewCullingLayer", BindingFlags.NonPublic | BindingFlags.Static);
			return (int)propertyInfo.GetGetMethod().Invoke(null, null);
		}
	}
}