namespace UnityEditor.Exposer
{
	using UnityEngine;
	using System;
	using System.Reflection;

	public class GameObjectInspector
	{
		private object Instance { get; set; }

        private Type ActualType { get; set; }

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
			MethodInfo methodInfo = ActualType.GetMethodAll("OnPreviewGUI");
			methodInfo.Invoke(Instance, new object[] {r, background});
		}
	}
}