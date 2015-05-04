namespace UnityEditor.Exposer
{
	using UnityEngine;
	using System;
	using System.Reflection;

	public class GameObjectInspector
	{
		public object Instance { get; private set; }

		public Type ActualType { get; private set; }

		/// <summary>
		/// Gets the k top.
		/// 
		/// Defined as: 
		/// private const float kTop = 4f;
		/// </summary>
		/// <value>The k top.</value>
		public float kTop
		{
			get
			{
				FieldInfo fieldInfo = ActualType.GetField("kTop", BindingFlags.NonPublic | BindingFlags.Static);
				return (float)fieldInfo.GetValue(Instance);
			}
		}

		/// <summary>
        /// Initializes a new instance of the <see cref="UnityEditor.Exposer.GameObjectInspector"/> class.
		/// </summary>
		/// <param name="instance">The actual UnityEditor.GameObjectInspector instance.</param>
		public GameObjectInspector(object instance)
		{
			Instance = instance;
			ActualType = instance.GetType();
		}

		public void OnPreviewGUI(Rect r, GUIStyle background)
		{
			MethodInfo methodInfo = ActualType.GetMethod("OnPreviewGUI", BindingFlags.Public | BindingFlags.Instance);
			methodInfo.Invoke(Instance, new object[] {r, background});
		}
	}
}