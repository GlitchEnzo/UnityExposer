namespace UnityEditor.Exposer
{
	using UnityEngine;
	using System;
	using System.Reflection;
	
	public class PreviewGUI
	{		
		public static Type ActualType { get; private set; }

		static PreviewGUI()
		{
			ActualType = Type.GetType("PreviewGUI, UnityEditor", true);
		}
		
		public static Vector2 Drag2D(Vector2 scrollPosition, Rect position)
		{
			//Type previewGUIType = typeof(UnityEditor.Editor).Assembly.GetType("PreviewGUI", true);
			//Type previewGUIType = Type.GetType("PreviewGUI, UnityEditor", true);
			//Debug.Log(previewGUIType.AssemblyQualifiedName);

			MethodInfo methodInfo = ActualType.GetMethod("Drag2D", BindingFlags.Public | BindingFlags.Static);
			return (Vector2)methodInfo.Invoke(null, new object[] {scrollPosition, position});
		}
	}
}