namespace UnityEditor.Exposer
{
	using UnityEngine;
	using System;
	using System.Reflection;
	
	public class PreviewGUI
	{		
		private static Type ActualType { get; set; }

		static PreviewGUI()
		{
            //Type previewGUIType = typeof(UnityEditor.Editor).Assembly.GetType("PreviewGUI", true);
            //Type previewGUIType = Type.GetType("PreviewGUI, UnityEditor", true);
            //Debug.Log(previewGUIType.AssemblyQualifiedName);

			ActualType = Type.GetType("PreviewGUI, UnityEditor", true);
		}

        public static void BeginScrollView(Rect position, Vector2 scrollPosition, Rect viewRect, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar)
        {
            MethodInfo methodInfo = ActualType.GetMethodAll("BeginScrollView");
            methodInfo.Invoke(new object[] { position, scrollPosition, viewRect, horizontalScrollbar, verticalScrollbar });
        }

        public static int CycleButton(int selected, GUIContent[] options)
        {
            MethodInfo methodInfo = ActualType.GetMethodAll("CycleButton");
            return methodInfo.Invoke<int>(new object[] { selected, options });
        }

        public static Vector2 EndScrollView()
        {
            MethodInfo methodInfo = ActualType.GetMethodAll("EndScrollView");
            return methodInfo.Invoke<Vector2>();
        }
		
		public static Vector2 Drag2D(Vector2 scrollPosition, Rect position)
		{
            MethodInfo methodInfo = ActualType.GetMethodAll("Drag2D");
			return methodInfo.Invoke<Vector2>(new object[] {scrollPosition, position});
		}
	}
}